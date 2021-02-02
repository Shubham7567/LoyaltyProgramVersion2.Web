using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoyaltyProgramVersion2.BLL.Operations;
using LoyaltyProgramVersion2.BLL.Views;

namespace LoyaltyProgramVersion2.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Country/List")]
        public ActionResult CountryList(string search = null)
        {
            CountryOperator country = new CountryOperator();
            List<CountryListView> list = country.Search(search);
            return View(list);
        }
        [Route("Country/Add")]
        public ActionResult AddCountry()
        { 
            CountryOperator country = new CountryOperator();
            country.Add();
            return View(country);
        }
        [Route("Country/Add")]
        [HttpPost]
        public ActionResult AddCountry(CountryOperator model)
        {
            ViewBag.ErrorMessage = String.Empty;
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Form data is not proper.";
                return View(model);
            }
            model.Update();
            return RedirectToAction("CountryList");
        }
        [Route("Country/{id}/Edit")]
        public ActionResult EditCountry(int id) 
        {
            CountryOperator country = new CountryOperator();
            country.Edit(id);
            return View(country);
        }
        [Route("Country/{id}/Edit")]
        [HttpPost]
        public ActionResult EditCountry(int id, CountryOperator country)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Form data is not proper.";
                return View(country);
            }
            country.Update();
            return RedirectToAction("CountryList");
        }
        [Route("Country/{id}/Detail")]
        public ActionResult DetailCountry(int id)
        {
            CountryOperator country = new CountryOperator();
            country.Edit(id);
            return View(country);
        }
        [Route("Country/{id}/Delete")]
        public ActionResult DeleteCountry(int id)
        {
            CountryOperator country = new CountryOperator();
            country.Edit(id);
            return View(country);
        }
        [Route("Country/{id}/Delete")]
        [HttpPost]
        public ActionResult DeleteCountry(int id, CountryOperator country)
        {
            country.Delete(id);
            return RedirectToAction("CountryList");
        }
    }
}