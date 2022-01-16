using IntimeVisitor.Bussiness.Concrete;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using IntimeVisitor.WebUI.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntimeVisitor.WebUI.Controllers
{
   // [LoginAuth]
    public class AddressController : Controller
    {
        IntimeVisitorContext context = new IntimeVisitorContext();
        AddressManager addressManager = new AddressManager(new AddressDAL());
        // GET: Address
        public ActionResult Address()
        {
            //var AdressList = context.Addresses.Where(v=>v.IsDeleted==false).ToList();
            var AdressList = addressManager.GetAllAsList();
            return View(AdressList);
        }


        public ActionResult GetAddress(Guid id) 
        {
            //var ads = context.Addresses.Find(id);
            var ads = addressManager.Get(id);
            return View("GetAddress",ads);
        }


        public ActionResult UpdateAddress(Address adrs)
        {
            //var ads = context.Addresses.Find(adrs.Id);
            //ads.Country = adrs.Country;
            //ads.City = adrs.City;
            //ads.District = adrs.District;
            //// brc.AddressId = brnc.AddressId;
            //ads.PostalCode = adrs.PostalCode;
            //ads.Openaddress =adrs.Openaddress;
            //ads.ModifiedDate = DateTime.Now;
            //context.SaveChanges();

            addressManager.Update(adrs);
            return RedirectToAction("Address");
        }

        [HttpPost]
        public ActionResult AddressAdd(Address address)
        {
            try
            {
                //context.Addresses.Add(address);
                //address.IsDeleted = false;
                //context.SaveChanges();
                addressManager.Add(address);
            }
            catch (Exception)
            {
                return RedirectToAction("Address");
            }
            return RedirectToAction("Address");
        }


        public ActionResult SoftDelete(Guid id)
        {
            //var deleteAddress = context.Addresses.SingleOrDefault(m => m.Id == id);
            //deleteAddress.IsDeleted = true;
            //deleteAddress.DeletedDate = DateTime.Now;     

            //context.SaveChanges();
            addressManager.Delete(id);
            context.SaveChanges();
            return RedirectToAction("Address");
        }
    }
}