using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Onboarding.Models;
using Newtonsoft.Json;

namespace Onboarding.Controllers
{
    public class CustomerController : Controller
    {
        private TOTPEntities db;

        public CustomerController()
        {
            db = new TOTPEntities();
        }

        // GET: Customer
        public JsonResult GetCustomer()
        {
            try
            {
                var customerList = db.Customer.Select( x=> new { x.ID,x.Name, x.Address } ).ToList();
                return new JsonResult { Data= customerList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}",e.Data);
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                
            }
        }

        //Create Customer
        public JsonResult CreateCustomer(Customer customer)
        {
            try
            {
                db.Customer.Add(customer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Create Customer Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Customer created", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Update Customer
        public JsonResult UpdateCustomer(Customer customer)
        {
            try
            {
                Customer dbCustomer = db.Customer.Where(x => x.ID == customer.ID).SingleOrDefault();
                dbCustomer.Name = customer.Name;
                dbCustomer.Address = customer.Address;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Customer details updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        //GetUpdate Customer
        public JsonResult GetUpdateCustomer(int id)
        {
            try
            {
                Customer customer = db.Customer.Where(x => x.ID == id).SingleOrDefault();
                return new JsonResult { Data = customer, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Customer Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Delete Customer
        public JsonResult DeleteCustomer(int id)
        {
            try
            {
                var customer = db.Customer.Where(x => x.ID == id).SingleOrDefault();
                if (customer!= null)
                {
                    db.Customer.Remove(customer);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Deletion Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return new JsonResult { Data = "Success Customer Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult Index()
        {
            return View();
        }

        
    }
}