using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class PharmacyController : PlaceController<Pharmacy>
    {
        protected override IQueryable<Pharmacy> Items => Database.Pharmacies.OrderBy(x => x.Id);
        protected override DbSet<Pharmacy> Table => Database.Pharmacies;

        protected override void OnSaveChanges(Pharmacy model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}