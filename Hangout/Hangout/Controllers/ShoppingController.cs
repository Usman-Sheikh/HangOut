using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class ShoppingController : PlaceController<Shopping>
    {
        protected override DbSet<Shopping> Table => Database.Shoppings;
        protected override IQueryable<Shopping> Items => Database.Shoppings.OrderBy(x => x.Id);

        protected override void OnSaveChanges(Shopping model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}