using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CheckVerificationDTO
    {
        public string UserName { get; set; }

        public string NewPassword { get; set; }
        public string VerificationCode { get; set; }
    }
    public class LoginDataDTO
    {
        public LoginDataDTO()
        {
            UserMenus = new List<UserMenuDTO>();
            WareHauses = new List<WarehouseDTO>();
        }
        public string Token { get; set; }
        public IList<UserMenuDTO> UserMenus { get; set; }
        public IList<WarehouseDTO> WareHauses { get; set; }
        public long Id { get; set; }
    }

   
    public class LoginDTO
    {
        [JsonProperty(PropertyName = "username")]
        [Required]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "password")]
        [Required]
        public string Password { get; set; }
    }

    public class SendSmsDTO
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