using Orders.Infrastructure;
using System.Web.Services;

namespace Orders.WebServices
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Test : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            var repo = new ProductRepository();
            repo.Test();
            return "Hello World";
        }
    }
}
