﻿using JsonApiSerializer;
using Newtonsoft.Json;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.QueryObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PlanningCenter.Api.Extensions;

namespace PlanningCenter.Api.Sets {
    public class BaseSet<T> where T : new() {
        private readonly PlanningCenterOptions _options;
        private readonly PlanningCenterToken _token;

        public BaseSet(PlanningCenterOptions options, PlanningCenterToken token) {
            _options = options;
            _token = token;
        }

        internal async Task<IPlanningCenterRestResponse<T>> GetAsync(string url) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<T>(response);
            }
        }

        internal async Task<IPlanningCenterRestResponse<List<T>>> FindAsync(string url) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(url);
                return await ConvertResponseAsync<List<T>>(response);
            }
        }

        internal async Task<IPlanningCenterRestResponse<List<T>>> FindAsync(string url, BaseQO qo) {
            using (var http = CreateClient()) {
                var response = await http.GetAsync(BuildURLParametersString(url, qo));
                return await ConvertResponseAsync<List<T>>(response);
            }
        }

        internal async Task<IPlanningCenterRestResponse<T>> PostAsync(T entity, string url) {
            return await PostAsync<T>(entity, url);
        }

        internal async Task<IPlanningCenterRestResponse<S>> PostAsync<S>(S entity, string url) where S : new() {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, new JsonApiSerializerSettings());
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);
                return await ConvertResponseAsync<S>(response);
            }
        }

        internal async Task<IPlanningCenterRestResponse<T>> PatchAsync(T entity, string url) {
            return await PatchAsync<T>(entity, url);
        }

        internal async Task<IPlanningCenterRestResponse<S>> PatchAsync<S>(S entity, string url) where S : new() {
            using (var http = CreateClient()) {
                var jsonContent = JsonConvert.SerializeObject(entity, new JsonApiSerializerSettings());
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json-patch+json");
                var response = await http.PatchAsync(url, content);
                return await ConvertResponseAsync<S>(response);
            }
        }

        internal async Task<IPlanningCenterRestResponse> DeleteAsync(string url) {
            using (var http = CreateClient()) {
                var response = await http.DeleteAsync(url);
                return await ConvertResponseAsync(response);
            }
        }

        private HttpClient CreateClient() {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_options.ApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.access_token);
            return httpClient;
        }

        private async Task<IPlanningCenterRestResponse<S>> ConvertResponseAsync<S>(HttpResponseMessage response) where S : new() {
            var planningCenterResponse = new PlanningCenterRestResponse<S> {
                StatusCode = response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync()
            };

            if (!string.IsNullOrEmpty(planningCenterResponse.JsonResponse) && (int)response.StatusCode > 300) {
                planningCenterResponse.ErrorMessage = planningCenterResponse.JsonResponse;
            }
            else {
                planningCenterResponse.Data = JsonConvert.DeserializeObject<S>(planningCenterResponse.JsonResponse, new JsonApiSerializerSettings());
            }

            return planningCenterResponse;
        }

        private async Task<IPlanningCenterRestResponse> ConvertResponseAsync(HttpResponseMessage response) {
            var planningCenterResponse = new PlanningCenterRestResponse {
                StatusCode = response.StatusCode,
                JsonResponse = await response.Content.ReadAsStringAsync()
            };

            if (!string.IsNullOrEmpty(planningCenterResponse.JsonResponse) && (int)response.StatusCode > 300) {
                planningCenterResponse.ErrorMessage = planningCenterResponse.JsonResponse;
            }

            return planningCenterResponse;
        }

        private string BuildURLParametersString(string uri, BaseQO qo) {
            return $"{ uri}?{qo.ToQueryString()}";
        }
    }
}
