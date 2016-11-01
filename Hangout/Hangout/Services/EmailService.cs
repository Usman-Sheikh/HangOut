using System;
using System.Net;
using System.Net.Mail;
using HangOut.Models;

namespace HangOut.Services
{
    public static class OutlookEmailService
    {
        public static void SendEmail(string toAddress, string subject, string emailBody)
        {
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                Credentials = new NetworkCredential("msalmanh100@outlook.com", "Welcome@01"),
                EnableSsl = true
            };
            client.Send("msalmanh100@outlook.com", toAddress, subject, emailBody);
        }

        public static void SendBookingEmail(BookingViewModel bookingViewModel, string toAddress)
        {
            string body = $"You have successfully booked from {bookingViewModel.CheckinDate} to {bookingViewModel.CheckoutDate} for";
            body += $"{bookingViewModel.NumberOfRooms} rooms for {bookingViewModel.NumberOfAdults} adults and {bookingViewModel.NumberOfChildren} children.";
            SendEmail(toAddress,"Booking Confirmed", body);
        }
    }
}