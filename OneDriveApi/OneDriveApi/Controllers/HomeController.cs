using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OneDriveDeneme_23_02_2018.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string code)
       {
            if (!string.IsNullOrEmpty(code))
            {
                Task.Factory.StartNew(() =>
                {
                    GetAccessToken(code).Wait();
                });
            }

            return View();
        }

        public ActionResult Auth()
        {
            var signOut = ApiManager.OneApi.GetAuthenticationUri().ToString();
            return Redirect(signOut);
        }

        public async Task<string> GetAccessToken(string code)
       {
            ApiManager.OneApi.AuthorizationToken = code;
            var x = await ApiManager.OneApi.GetAccessToken();
            return x.AccessToken.ToString();
        }

        public  ActionResult Upload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content"), Path.GetFileName(file.FileName));
                    Task.Factory.StartNew(() =>
                    {
                        var ondri = ApiManager.OneApi.GetDriveRoot();
                        ApiManager.OneApi.UploadFile(path, ondri.Result).Wait();
                    });
                    // file.SaveAs(path);
                }
            }

            return View();
        }


        public ActionResult Delete(string itemPath)
        {
            itemPath = "1.jpg";

            if (!string.IsNullOrEmpty(itemPath))
            {
                Task.Factory.StartNew(() =>
                {
                    ApiManager.OneApi.Delete(itemPath).Wait();
                });
            }
            return View("Index");
        }

        public ActionResult GetItem(string itemPath)
        {
            itemPath = "deneme.docx";
            if (!string.IsNullOrEmpty(itemPath))
            {
                Task.Factory.StartNew(() =>
                {
                    ApiManager.OneApi.GetItem(itemPath).Wait();

                });
            }
            return View("Index");
        }

        public ActionResult GetDrive()
        {
            Task.Factory.StartNew(() =>
            {
                ApiManager.OneApi.GetAllDriveRootChildren().Wait();
            });

            return View("Index");
        }

        public ActionResult Rename(string sourceItemPath, string destinationItemPath)
        {
            if ((!string.IsNullOrEmpty(sourceItemPath)) &&
                (!string.IsNullOrEmpty(destinationItemPath)))
            {
                sourceItemPath = "modal 2.png";
                destinationItemPath = "renamed modal 2.png";

                Task.Factory.StartNew(() =>
                {
                    ApiManager.OneApi.Rename(sourceItemPath, destinationItemPath).Wait();
                });
            }
            return View("Index");
        }

        public ActionResult Copy(string sourceItem, string destinationItem, string destinationName)
        {
            if ((!string.IsNullOrEmpty(sourceItem)) &&
                 (!string.IsNullOrEmpty(destinationItem)) && (!string.IsNullOrEmpty(destinationName)))
            {
                sourceItem = "deneme.docx";
                destinationItem = "Documents";
                destinationName = "copied deneme.docx";

                Task.Factory.StartNew(() =>
                {
                    ApiManager.OneApi.Copy(sourceItem, destinationItem, destinationName).Wait();
                });
            }

            return View("Index");
        }

        public ActionResult Move(string sourceItem, string destinationItem)
        {
            if ((!string.IsNullOrEmpty(sourceItem)) &&
                 (!string.IsNullOrEmpty(destinationItem)))
            {
                sourceItem = "deneme.docx";
                destinationItem = "Documents";

                Task.Factory.StartNew(() =>
                {
                    ApiManager.OneApi.Move(sourceItem, destinationItem).Wait();
                });
            }

            return View("Index");
        }
    }
}