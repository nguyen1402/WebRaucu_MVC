using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Webbanraucu_Ass.Extention;
using Webbanraucu_Ass.ModelsView;

namespace Webbanraucu_Ass.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var _gioHang = HttpContext.Session.Get<List<GioHang>>("GioHangs");
            return View(_gioHang);
        }
    }
}
