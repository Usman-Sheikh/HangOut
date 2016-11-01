using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HangOut.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} length must be at between {2} & {1} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} length must be at between {2} & {1} characters long.", MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string OpenTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string CloseTime { get; set; }
        [Required]
        [StringLength(50)]
        public string BuildingNo { get; set; }
        [Required]
        [StringLength(50)]
        public string RoadName { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
        
        public List<CommentsViewModel> Comments { get; set; }

    }

    public class FoodViewModel : PlaceViewModel
    {
        [DisplayName("Restaurant Type")]
        public int RestType { get; set; }
    }
    public class HospitalViewModel : PlaceViewModel
    {
        [DisplayName("Public")]
        public bool IsPublic { get; set; }
    }
    public class HotelViewModel : PlaceViewModel
    {
        [DisplayName("Daily Rent")]
        public int DailyRent { get; set; }
        public IEnumerable<BookingViewModel> Booking { get; set; }
    }
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public List<CommentsViewModel> Replies { get; set; }
    }

    public class BookingViewModel
    {
        public int PlaceId { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfRooms { get; set; }
        public bool BookingConfirmed { get; set; }
    }
}
