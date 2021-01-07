using System.Threading.Tasks;
using McSaas.Models.TokenAuth;
using McSaas.Web.Controllers;
using Shouldly;
using Xunit;

namespace McSaas.Web.Tests.Controllers
{
    public class HomeController_Tests: McSaasWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}