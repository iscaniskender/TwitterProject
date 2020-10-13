using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using Cammon.Dto;
using Microsoft.AspNetCore.Mvc;
using Twetter.UI;

namespace Twetter.UI.Controllers
{
    public class LoginController : Controller
    {
        private IUserServices _services;
        public LoginController(IUserServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Loginpost(DtoUser entity)
        {
            {
                int data = 0;
                var sorgu = _services.LoginControl(entity);
                if (sorgu != null)
                {
                    data = 1;
                    HttpContext.Session.SetObjectAsJson("loggerUser",sorgu);
                }
                else
                {
                    data = 0;
                }
                return Json(data);
            }   
        }
        public IActionResult Register()
        {
            return View();
        }
        
        public IActionResult RegisterPost(DtoUser entity)

        {
            int data=0;
            if(_services.RegisterControl(entity)==null)
            {
                data = 1;
                _services.Create(entity);    
            }
            else
            {
                data = 0;
            }
                return Json(data);
        }
    }
}
