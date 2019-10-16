using System;

namespace Har.AspNetCore.Mvc.Alerts.Services
{
    public interface IAlertService
    {
        void Alert(AlertType type, string title, string message, bool encode = true);

        void SuccessAlert(string title, string message, bool encode = true);

        void WarningAlert(string title, string message, bool encode = true);

        void ErrorAlert(string title, string message, bool encode = true);

        void ErrorAlert(Exception exception, bool logException = true);

        void InfoAlert(string title, string message, bool encode = true);
    }
}
