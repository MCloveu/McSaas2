using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using McSaas.Controllers;

namespace McSaas.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : McSaasControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }

    //public DataService dataService { get; set; }

    //public class DataService      
    //{        private IRepository repos { get; set; }
    //    public DataService(IRepository repo) {  repos = repo;  }

    //    public IEnumerable<string> GetData(){  return repos.GetData();     }    
    //}
}
