using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using McSaas.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace McSaas.Web.Controllers
{
    public class BasicFunController : McSaasControllerBase
    {
        public IActionResult Index()
        {
            //MyGlobalModuleTypeString = "";
            return View();
            //  await _signInManager.SignOutAsync();
            //return RedirectToAction("Index");
        }
        public ActionResult RedirectToBasicFunHome()
        {
            return RedirectToAction("Index", "BasicFun");
        }

    }
}
