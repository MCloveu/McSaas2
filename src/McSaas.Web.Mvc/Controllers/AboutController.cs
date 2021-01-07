using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using McSaas.Controllers;

namespace McSaas.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : McSaasControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
