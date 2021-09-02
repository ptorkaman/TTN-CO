using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Login
{
    public class LoginViewModel
    {
        [JsonProperty(PropertyName = "username")]
        [Required]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "password")]
        [Required]
        public string Password { get; set; }
    }
    public class SendSmsViewModel
    {
        [JsonProperty(PropertyName = "username")]
        [Required]
        public string UserName { get; set; }
        public int Id { get; set; }
    }
    public class StackSms
    {
        public long Id { get; set; }
 

        public string ToNumber { get; set; }
        public string Text { get; set; }
        public string Provider { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}