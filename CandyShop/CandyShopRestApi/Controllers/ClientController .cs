using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CandyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;
        private readonly MailLogic _logicM;
        private readonly int _passwordMaxLength = 50;
        private readonly int _passwordMinLength = 10;
        private readonly int mailsOnPage = 2;

        public ClientController(ClientLogic logic, MailLogic logicM)
        {
            _logic = logic;
            _logicM = logicM;
            if (mailsOnPage < 1) { 
                mailsOnPage = 5; 
            }
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel { Email = login, Password = password })?[0];

        [HttpGet]
        public (List<MessageInfoViewModel>, bool) GetMessages(int clientId, int page)
        {
            var list = _logicM.Read(new MessageInfoBindingModel { ClientId = clientId, ToSkip = (page - 1) * mailsOnPage, ToTake = mailsOnPage + 1 }).ToList();
            var hasNext = !(list.Count() <= mailsOnPage);
            return (list.Take(mailsOnPage).ToList(), hasNext);
        }

        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }

        private void CheckData(ClientBindingModel model)
        {
            if (!Regex.IsMatch(model.Email, @"gmail"))
            {
                throw new Exception("В качестве логина должна быть указана почта");
            }
            if (model.Password.Length > _passwordMaxLength || model.Password.Length <
            _passwordMinLength || !Regex.IsMatch(model.Password,
            @"^((\w+\d+\W+)|(\w+\W+\d+)|(\d+\w+\W+)|(\d+\W+\w+)|(\W+\w+\d+)|(\W+\d+\w+))[\w\d\W]*$"))
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до { _passwordMaxLength } должен быть и из цифр, букв и небуквенных символов должен состоять");
            }
        }
    }
}
