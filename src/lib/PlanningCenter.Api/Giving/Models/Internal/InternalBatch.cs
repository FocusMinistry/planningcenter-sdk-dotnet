using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Giving.Models.Internal {
    internal class InternalBatch : BaseModel {
        public InternalBatch() {
            Type = "Batch";
        }

        public InternalBatch(Batch entity) : this() {
            Description = entity.Description;
            BatchGroup = entity.BatchGroup;
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("batch_group")]
        public Relationship<BatchGroup> BatchGroup { get; set; }
    }
}
