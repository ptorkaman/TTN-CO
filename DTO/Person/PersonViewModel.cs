using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Person
{
    public class PersonViewModel
    {

        [JsonProperty("id")]

        public long Id { get; set; }
        [JsonProperty("code")]
        public Guid Code { get; set; }
        [JsonProperty("first_name")]
        [Required]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        [Required]
        public string LastName { get; set; }
        [JsonProperty("national_code")]
        [Required]
        public string NationalCode { get; set; }
        [JsonProperty("identity")]
        [Required]
        public string Identity { get; set; }
        [JsonProperty("father_name")]
        [Required]
        public string FatherName { get; set; }
        [JsonProperty("birth_date")]
        public DateTime? BirthDate { get; set; }
        [JsonProperty("gender_id")]
        [Required]
        public byte GenderId { get; set; }
        [JsonProperty("marriage_id")]
        [Required]
        public byte MarriageId { get; set; }
        [JsonProperty("millitary_id")]
        public byte? MillitaryId { get; set; }

    }
}
