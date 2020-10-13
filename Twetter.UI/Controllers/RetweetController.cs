using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Concrete;
using Cammon.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Twetter.UI.Controllers
{
    public class RetweetController : Controller
    {
        RetweetMenager rt = new RetweetMenager();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult rtoperation(DtoRetweet entity)
        {
            rt.Create(entity);

            return Json(true);
        }
    }
}
