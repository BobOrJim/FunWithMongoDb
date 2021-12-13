using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;


namespace Shared.Model
{
    public class RecieptModel
    {
        [BsonId]
        public int Id { get; set; } //tryed to use int as Id, but have to set it with some counter for it to work
        public string BusinessName { get; set; }
        public ProductModel Product { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
