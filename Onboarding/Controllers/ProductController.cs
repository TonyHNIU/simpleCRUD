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
    public class ProductController : Controller
    {
        private TOTPEntities db;

        public ProductController()
        {
            db = new TOTPEntities();
        }

        // GET: Customer
        public JsonResult GetProduct()
        {
            try
            {
                var productList = db.Product.Select(x=>new { x.ID, x.Name, x.Price }).ToList();
                return new JsonResult { Data = productList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
        }

        //Create Customer
        public JsonResult CreateProduct(Product product)
        {
            try
            {
                db.Product.Add(product);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Create Product Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Product created", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //Update Customer
        public JsonResult UpdateProduct(Product product)
        {
            try
            {
                Product dbProduct = db.Product.Where(x => x.ID == product.ID).SingleOrDefault();
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Product details updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        //GetUpdate Customer
        public JsonResult GetUpdateProduct(int id)
        {
            try
            {
                Product product = db.Product.Where(x => x.ID == id).SingleOrDefault();
                return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Product Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Delete Product
        public JsonResult DeleteProduct(int id)
        {
            try
            {
                var product = db.Product.Where(x => x.ID == id).SingleOrDefault();
                if (product != null)
                {
                    db.Product.Remove(product);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write("Exception Occured /n {0}", e.Data);
                return new JsonResult { Data = "Deletion Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            return new JsonResult { Data = "Success Product Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult Index()
        {
            return View();
        }


    }
}