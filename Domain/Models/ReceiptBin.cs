﻿using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("ReceiptBin", Schema = "TTN")]

    public class ReceiptBin : BaseClass<int> 
    { 
        public long ReceiptId { get; set; }
        public int BinId { get; set; }
        

    }
}