using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Person
{
    public class PersonAddressViewModel
    {

        [JsonProperty("id")]

        public long Id { get; set; }
        [JsonProperty("address_id")]

        public long AddressId { get; set; }
        [JsonProperty("person_id")]

        public long PersonId { get; set; }

    }
}
