using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models
{
    public enum PostingType
    {
        Driver, Rider
    }

    public class PostingModel
    {
        public int ID { get; set; }
        public PostingType PostingType { get; set; }
        public String Name { get; set; }
        public String Departure { get; set; }
        public String Arrival { get; set; }
        public DateTime Date { get; set; }
    }
}