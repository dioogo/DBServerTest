using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBServerTest.Startup))]
namespace DBServerTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
