﻿using System.ComponentModel;
using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("SenderReciver", Schema = "TTN")]

    public class SenderReciver : BaseClass<int> 
    {
        public int CityId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public ClassType Type { get; set; }
    }

    public enum ClassType
    {
        [Description("Sender")]
        Sender =1
        ,
        [Description("Reciever")]

        Reciever = 2
    }
}