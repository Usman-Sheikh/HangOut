using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class ClinicController : PlaceController<Clinic>
    {
        protected override IQueryable<Clinic> Items => Database.Clinics.OrderBy(x=>x.Id);
        protected override DbSet<Clinic> Table => Database.Clinics;
        protected override void OnSaveChanges(Clinic model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}