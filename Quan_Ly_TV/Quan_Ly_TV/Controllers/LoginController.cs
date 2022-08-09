using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string Username, string Password)
        {
            Session["name"] = Username;
            ViewBag.pass = Password;
            int demNV = db.Login.Count(m => m.UserName.ToLower() == Username.ToLower() && m.PassWord == Password && m.PhanQuyen == 1); 
            if (demNV > 0)
            {
                Session["AdminNV"] = Username.ToString();              
                return RedirectToAction("DsDocGia", "DocGia");
            }
            else
            {
                TempData["Error"] = "Sai mật khẩu hoặc tài khoản";
                return View();
            }
            
        }

        public ActionResult LoginQL()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginQL(string Username, string Password)
        {
            int demQL = db.Login.Count(m => m.UserName.ToLower() == Username.ToLower() && m.PassWord == Password && m.PhanQuyen == 2);
            if (demQL > 0)
            {
                Session["AdminQL"] = Username.ToString();
                return RedirectToAction("HomeAdmin", "Home");
            }
            else
            {
                TempData["Error"] = "Sai mật khẩu hoặc tài khoản";
                return View();
            }
        }



        public ActionResult Logout()
        {
            if (Session["AdminNV"] != null)
            {
                Session.Remove("AdminNV");
                return RedirectToAction("LoginAdmin");

            }
            if(Session["AdminQL"] != null)
            {
                Session.Remove("AdminQL");
                return RedirectToAction("LoginQL");
            }
            else
            {
                return RedirectToAction("LoginAdmin");
            }
                       
        }
    }
}