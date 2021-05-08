using System.Threading.Tasks;
using netflix.Models.TokenAuth;
using netflix.Web.Controllers;
using Shouldly;
using Xunit;

namespace netflix.Web.Tests.Controllers
{
    public class HomeController_Tests: netflixWebTestBase
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