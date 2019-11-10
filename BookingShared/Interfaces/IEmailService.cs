using BookingShared.Models;

namespace BookingBLL
{
    public interface IEmailService
    {
        void SendEmail(string name, string email, string message);
        void SendConfirmationEmail(AppUser user);
    }
}