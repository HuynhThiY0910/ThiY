using HuynhThiY.Context;
using HuynhThiY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuynhThiY.Controllers
{
    public class PaymentController : Controller
    {
        webBanhangEntities objwebBanhangEntities = new webBanhangEntities();
        // GET: Payment
        public ActionResult Index()
        {

            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Orderr objOrderr = new Orderr();
                objOrderr.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrderr.UserId = int.Parse(Session["idUser"].ToString());
                objOrderr.CreatedOnUtc = DateTime.Now;
                objOrderr.Status = 1;
                objwebBanhangEntities.Orderrs.Add(objOrderr);
                objwebBanhangEntities.SaveChanges();
                int intOrderId = objOrderr.Id;

                List<OrdelDetail> lstOrderDetail = new List<OrdelDetail>();

                foreach (var item in lstCart)
                {
                    OrdelDetail obj = new OrdelDetail();
                    obj.OrderId = intOrderId;
                    obj.Quantity = item.Quantity;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objwebBanhangEntities.OrdelDetails.AddRange(lstOrderDetail);
                objwebBanhangEntities.SaveChanges();
            }

            return View();
        }
    }
}