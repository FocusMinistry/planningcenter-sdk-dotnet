using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;
using PlanningCenter.Api.QueryObjects;
using PlanningCenter.Api.Models.Internal;

namespace PlanningCenter.Api.Sets {
    public class PeopleSet : BaseSet<Person> {
        public PeopleSet(PlanningCenterOptions options, PlanningCenterToken token) : base(options, token) {

        }

        /// <summary>
        /// Get all the people in PCO
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<Person>>> FindAsync() {
            return await base.FindAsync($"/people/v2/people?include=addresses,emails,phone_numbers,field_data,households");
        }

        /// <summary>
        /// Get all the people in PCO
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<Person>>> SearchAsync(string searchTerm) {
            return await base.FindAsync($"/people/v2/people?where[search_name_or_email_or_phone_number]={searchTerm}&include=addresses,emails,phone_numbers,field_data,households");
        }

        /// <summary>
        /// Get all the people in a household
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<List<Person>>> FindByHouseholdAsync(int householdId) {
            return await base.FindAsync($"/people/v2/households/{householdId}/people?include=addresses,emails,phone_numbers,field_data,households");
        }

        /// <summary>
        /// Get record for the logged in user
        /// </summary>
        /// <returns>A collection of people</returns>
        public async Task<IPlanningCenterRestResponse<Person>> MeAsync() {
            return await base.GetAsync($"/people/v2/me?include=addresses,emails,phone_numbers,field_data,households");
        }

        /// <summary>
        /// Get the person by ID in PCO
        /// </summary>
        /// <param name="personID">The person id</param>
        /// <returns>A person from PCO</returns>
        public async new Task<IPlanningCenterRestResponse<Person>> GetAsync(string personID) {
            return await base.GetAsync($"/people/v2/people/{personID}?include=addresses,emails,phone_numbers,field_data,households");
        }

        public async Task<IPlanningCenterRestResponse<Person>> CreateAsync(Person entity) {
            return await base.PostAsync<InternalPerson, Person>(new InternalPerson(entity), "/people/v2/people");
        }

        public async Task<IPlanningCenterRestResponse<Person>> UpdateAsync(Person entity) {
            return await base.PatchAsync<InternalPerson, Person>(new InternalPerson(entity), $"/people/v2/people/{entity.Id}");
        }
    }
}