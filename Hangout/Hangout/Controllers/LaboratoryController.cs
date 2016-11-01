using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class LaboratoryController : PlaceController<Laboratory>
    {
        protected override void OnSaveChanges(Laboratory model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
        protected override IQueryable<Laboratory> Items => Database.Laboratories.OrderBy(x => x.Id);
        protected override DbSet<Laboratory> Table => Database.Laboratories;

    }
}