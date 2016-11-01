using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class RealEstateController : PlaceController<RealEstate>
    {
        protected override IQueryable<RealEstate> Items => Database.RealEstates.OrderBy(x => x.Id);
        protected override DbSet<RealEstate> Table => Database.RealEstates;

        protected override void OnSaveChanges(RealEstate model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}