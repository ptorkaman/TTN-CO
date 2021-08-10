﻿using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("UserWarhouse", Schema = "TTN")]

    public class UserWarhouse : BaseClass<int> 
    {
        public int UserId { get; set; }
        public int WareouseId { get; set; }

        

    }
}