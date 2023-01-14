namespace CityInfo.Application.MailService
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}