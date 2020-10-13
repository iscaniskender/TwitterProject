using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Concrete;
using Cammon.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Twetter.UI.Views.Home
{
    public class ConnectionController : Controller
    {
        ConnectionMenager connection = new ConnectionMenager();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddConnection(DtoConnection conn)
        {
            connection.Create(conn);

            return Json(true);
        }
    }
}
