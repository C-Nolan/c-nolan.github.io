using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RideShare.Models;

namespace RideShare.DAL
{
    public class RideShareInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RideShareContext>
    {
        protected override void Seed(RideShareContext context)
        {
            var postings = new List<PostingModel>
            {
                new PostingModel{PostingType=PostingType.Driver,Name="Reed Harris",Departure="College Station",Arrival="Dallas",Date=DateTime.Parse("2015-01-01")},
                new PostingModel{PostingType=PostingType.Driver,Name="Reed Harris",Departure="Dallas",Arrival="College Station",Date=DateTime.Parse("2015-01-08")},
                new PostingModel{PostingType=PostingType.Rider,Name="Christopher Nolan",Departure="College Station",Arrival="Houston",Date=DateTime.Parse("2015-01-08")}
            };

            postings.ForEach(p => context.Postings.Add(p));
            context.SaveChanges();
        }
    }
}