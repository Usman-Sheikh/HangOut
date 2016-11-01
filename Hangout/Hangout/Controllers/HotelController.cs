using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HangOut.Models;
using HangOut.Services;
using Microsoft.AspNet.Identity;
namespace HangOut.Controllers
{
    public class HotelController : BasePlaceController<Hotel, HotelViewModel>
    {
        protected override DbSet<Hotel> Table => Database.Hotels;
        protected override IQueryable<Hotel> Items => Database.Hotels.OrderBy(x => x.Id);

        protected override void OnSaveChanges(Hotel model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }

        protected override void onLoad(HotelViewModel model)
        {
            model.Booking = MapperConfig.Map<IQueryable<Booking>, IEnumerable<BookingViewModel>>(Database.Bookings);
            base.onLoad(model);
        }

        public ActionResult SaveBooking(BookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                Booking booking = new Booking()
                {
                    CheckinDate = bookingViewModel.CheckinDate,
                    CheckoutDate = bookingViewModel.CheckoutDate,
                    PlaceId = bookingViewModel.PlaceId,
                    UserId = User.Identity.GetUserId(),
                    NumberOfRooms = bookingViewModel.NumberOfRooms,
                    NumberOfAdults = bookingViewModel.NumberOfAdults,
                    NumberOfChildren = bookingViewModel.NumberOfChildren
                };
                Database.Bookings.Add(booking);
                Database.SaveChanges();
                var toAddress = UserManager.GetEmailAsync(User.Identity.GetUserId()).Result;
                OutlookEmailService.SendBookingEmail(bookingViewModel,toAddress);
            }
            return RedirectToAction("Details", new { id = bookingViewModel.PlaceId });
        }
    }
}