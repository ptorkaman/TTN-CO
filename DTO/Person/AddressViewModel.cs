using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Person
{
    public class AddressViewModel
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public Guid Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city_id")]
        public long CityId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("zoneNumber")]
        public string ZoneNumber { get; set; }

        [JsonProperty("createdBy")]
        public long? CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedBy")]
        public long? UpdatedBy { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        public long PersonId { get; set; }
    }
}
