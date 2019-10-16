using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Har.AspNetCore.Mvc.Alerts.Services
{
    public class AlertService : IAlertService
    {
        private readonly HttpContext _context;
        private readonly ITempDataDictionaryFactory _factory;
        private readonly ILogger<AlertService> _logger;

        public AlertService(IHttpContextAccessor contextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory,
            ILogger<AlertService> logger)
        {
            _factory = tempDataDictionaryFactory;
            _context = contextAccessor.HttpContext;
            _logger = logger;
        }

        private void PrepareTempData(AlertType alertType, string title, string message, bool encode = true)
        {
            var tempData = _factory.GetTempData(_context);
            var messages = tempData.ContainsKey(AlertDefaults.AlertListKey)
                ? JsonSerializer.Deserialize<IList<AlertMessage>>(tempData[AlertDefaults.AlertListKey].ToString())
                : new List<AlertMessage>();
            messages.Add(new AlertMessage()
            {
                AlertType = alertType,
                Encode = encode,
                Message = message,
                Title = title
            });

            tempData[AlertDefaults.AlertListKey] = JsonSerializer.Serialize(messages);
        }

        public void ErrorAlert(string title, string message, bool encode = true)
        {
            Alert(AlertType.Error, title, message, encode);
        }

        public void ErrorAlert(Exception exception, bool logException = true)
        {
            if (exception == null)
            {
                return;
            }

            if (logException)
            {
                _logger.LogError(exception, exception.Message);
            }

            Alert(AlertType.Error, exception.HelpLink, exception.Message);
        }

        public void InfoAlert(string title, string message, bool encode = true)
        {
            Alert(AlertType.Info, title, message, encode);
        }

        public void Alert(AlertType type, string title, string message, bool encode = true)
        {
            PrepareTempData(type, title, message, encode);
        }

        public void SuccessAlert(string title, string message, bool encode = true)
        {
            Alert(AlertType.Success, title, message, encode);
        }

        public void WarningAlert(string title, string message, bool encode = true)
        {
            Alert(AlertType.Warning, title, message, encode);
        }
    }
}
