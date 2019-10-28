using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.Extensions;
using PlanningCenter.Api.Exceptions;
using PlanningCenter.Api.Sets;
using PlanningCenter.Api.Realms;

namespace PlanningCenter.Api {
    public class PlanningCenterClient {
        public PlanningCenterClient(PlanningCenterOptions options, PlanningCenterToken token) {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
            People = new PeopleSet(options, token);
            MaritalStatuses = new MaritalStatusSet(options, token);
            Households = new HouseholdSet(options, token);
            Emails = new EmailSet(options, token);
            FieldDefinitions = new FieldDefinitionSet(options, token);
            PhoneNumbers = new PhoneNumberSet(options, token);
            Addresses = new AddressSet(options, token);
            Campuses = new CampusSet(options, token);
            Giving = new GivingRealm(options, token);
        }

        public GivingRealm Giving { get; }

        public PeopleSet People { get; }

        public MaritalStatusSet MaritalStatuses { get; }

        public HouseholdSet Households { get; }

        public EmailSet Emails { get; }

        public PhoneNumberSet PhoneNumbers { get; }

        public AddressSet Addresses { get; }

        public CampusSet Campuses { get; }

        public FieldDefinitionSet FieldDefinitions { get; set; }

        /// <summary>
        /// Gets the url that should be sent via browser to authorize the planning center user and get consent
        /// </summary>
        /// <param name="options">Options to set things like client id and secret</param>
        /// <param name="returnUrl">The url to return to when consent is chosen</param>
        /// <param name="scopes">The scopes for the authorization to identify the rights of subsequent calls. NOTE: list should be space separated</param>
        /// <returns>A url to be sent via browser for the user to give consent to application</returns>
        public static Uri GetAuthorizationUrl(PlanningCenterOptions options, string returnUrl, string scopes, string state = null) {
            System.Text.StringBuilder loginUrl = new System.Text.StringBuilder();
            loginUrl.Append(options.ApiUrl).Append("/oauth/authorize");
            loginUrl.Append($"?client_id={options.ClientID}&response_type=code&redirect_uri={returnUrl}&scope={scopes}");
            if (!string.IsNullOrEmpty(state)) {
                loginUrl.Append($"&state={state}");
            }
            return new Uri(loginUrl.ToString());
        }

        /// <summary>
        /// Exchange the authorization code from PCO login for an access token
        /// </summary>
        /// <param name="options">The Planning Center Options for Client ID and Secret</param>
        /// <param name="authCode">The code received from PCO login</param>
        /// <param name="redirectUrl">The url to redirect to that was used on auth code login</param>
        /// <returns>A PCO Access Token</returns>
        public static async Task<IPlanningCenterRestResponse<PlanningCenterToken>> ExchangeAuthTokenAsync(PlanningCenterOptions options, string authCode, string redirectUrl) {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;

            try {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", authCode),
                    new KeyValuePair<string, string>("client_id", options.ClientID),
                    new KeyValuePair<string, string>("client_secret", options.ClientSecret),
                    new KeyValuePair<string, string>("redirect_uri", redirectUrl),
                });

                return await GetTokenAsync(options.ApiUrl, content);
            }
            catch (Exception e) {
                throw new ApiAccessException("Error Getting Auth Token", e);
            }
        }

        /// <summary>
        /// Refresh the current PCO access token
        /// </summary>
        /// <param name="options">The Planning Center Options for Client ID and Secret</param>
        /// <param name="refreshToken">The refresh token that was received from an access token call</param>
        /// <returns>A PCO Access Token</returns>
        public static async Task<IPlanningCenterRestResponse<PlanningCenterToken>> RefreshAccessTokenAsync(PlanningCenterOptions options, string refreshToken, string scope) {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11;
            try {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken),
                    new KeyValuePair<string, string>("client_id", options.ClientID),
                    new KeyValuePair<string, string>("client_secret", options.ClientSecret),
                    new KeyValuePair<string, string>("scope", scope)
                });

                return await GetTokenAsync(options.ApiUrl, content);
            }
            catch (Exception e) {
                throw new ApiAccessException("Error Refreshing Token", e);
            }
        }

        private static async Task<PlanningCenterRestResponse<PlanningCenterToken>> GetTokenAsync(string url, FormUrlEncodedContent content) {
            using (var httpClient = new HttpClient()) {
                var response = await httpClient.PostAsync($"{url}/oauth/token", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                var pcResponse = new PlanningCenterRestResponse<PlanningCenterToken> {
                    StatusCode = response.StatusCode,
                    RequestValue = Newtonsoft.Json.JsonConvert.SerializeObject(content),
                    JsonResponse = responseContent
                };

                if (!string.IsNullOrEmpty(responseContent) && responseContent.Contains("error")) {
                    var responseError = responseContent.FromJson<dynamic>();
                    pcResponse.ErrorMessage = responseError.error_description;
                }
                else {
                    pcResponse.Data = responseContent.FromJson<PlanningCenterToken>();
                }
                return pcResponse;
            }
        }
    }
}
