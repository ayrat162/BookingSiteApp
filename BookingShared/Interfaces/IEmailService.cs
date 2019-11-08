namespace BookingBLL
{
    public interface IEmailService
    {
        void SendEmail(string name, string email, string message);
    }
}