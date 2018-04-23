using System.Web.Mvc;
using ComboBoxLargeDataBase.Model;

namespace ComboBoxLargeDataBase.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(DataHelper.Persons);
        }
        public ActionResult ComboBoxPartial() {
            return PartialView("ComboBoxPartial", DataHelper.Persons);
        }
    }
}
