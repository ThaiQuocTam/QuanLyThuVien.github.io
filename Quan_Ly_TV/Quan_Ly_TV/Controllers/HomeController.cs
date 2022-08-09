using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class HomeController : Controller
    {
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();
        // GET: Home
        public ActionResult HomeAdmin()
        {
            if (Session["AdminQL"] != null || Session["AdminQL"] != null)
            {
                List<CT_PhieuMuon> ctpm = db.CT_PhieuMuon.ToList();
                List<Sach> dsSach = db.Sach.ToList();
                var topSach = from ct in ctpm
                            join ds in dsSach on ct.MaSach equals ds.MaSach into tbl
                            group ct by new
                            {
                                masach = ct.MaSach,
                                tenSach = ct.Sach.TenSach,
                                hinhanh = ct.Sach.AnhBia,
                                theLoai = ct.Sach.TheLoai,
                                tacgia = ct.Sach.TacGia,

                            }
                            into gr
                            orderby gr.Sum(s => s.SoLuong) descending
                            select new Viewmodels
                            {
                                Masach = gr.Key.masach,
                                TenSach = gr.Key.tenSach,
                                HinhAnh = gr.Key.hinhanh,
                                TheLoai = gr.Key.theLoai,
                                TacGia = gr.Key.tacgia,
                                TongSoLuong = gr.Sum(s => s.SoLuong)
                            };
                return View(topSach.ToList());
            }
            else
            {
                Session.Remove("AdminNV");
                return RedirectToAction("LoginQL", "Login");
            }
        }

        public ActionResult themTK()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themTK(string UserName, string PassWord, int PhanQuyen)
        {
            int check = db.Login.Count(m => m.UserName.ToLower() == UserName.ToLower());
            if(check > 0)
            {
                ViewBag.themTK = "Tên tài khoản đã tồn tại";
                return View();
            }
            else
            {
                db.Login.Add(new Login() {
                    UserName = UserName,
                    PassWord = PassWord,
                    PhanQuyen = PhanQuyen
                });
                db.SaveChanges();
                ViewBag.themTK = "Thêm tài khoản thành công";
                return View();
            }
        }
    }
}