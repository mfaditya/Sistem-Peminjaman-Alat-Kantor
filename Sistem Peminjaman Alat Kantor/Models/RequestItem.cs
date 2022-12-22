﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class RequestItem
    {
        //public RequestItem(int Id, int UserId, int ItemId, DateTime StartDate, DateTime EndDate, int Quantity, int StatusId)
        //{
        //    this.Id = Id;
        //    this.UserId = UserId;
        //    this.ItemId = ItemId;
        //    this.StartDate = StartDate;
        //    this.EndDate = EndDate;
        //    this.Quantity = Quantity;
        //    this.StatusId = StatusId;
        //}
        //public RequestItem()
        //{

        //}

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Account ?Accounts { get; set; }
        [JsonIgnore]
        public virtual Item ?Items { get; set; }
        [JsonIgnore]
        public virtual ReturnItem ?ReturnItems { get; set; }
        [JsonIgnore]
        public virtual Status ?Status { get; set; }
    }
}
