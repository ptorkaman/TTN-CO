﻿using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Parishes", Schema = "TTN")]

    public class Parish : BaseClass<int> 
    {
        public int RegionId { get; set; }
        public string ParishName { get; set; }
       


    }
}
