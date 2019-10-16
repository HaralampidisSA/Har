namespace Har.AspNetCore.Mvc.Alerts
{
    public class AlertMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public AlertType AlertType { get; set; }
        public bool Encode { get; set; }
    }
}
