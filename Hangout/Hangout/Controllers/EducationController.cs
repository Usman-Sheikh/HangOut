using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class EducationController : PlaceController<Education>
    {
        protected override IQueryable<Education> Items => Database.Educations.OrderBy(x=>x.Id);
        protected override DbSet<Education> Table => Database.Educations;

        protected override void OnSaveChanges(Education model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}