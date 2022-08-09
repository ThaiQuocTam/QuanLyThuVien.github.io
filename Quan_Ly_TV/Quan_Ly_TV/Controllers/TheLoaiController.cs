using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();
        [HttpGet]
        public ActionResult DanhSachTL(string filter)
        {
            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    List<TheLoai> dsTL = db.TheLoai.Where(m => m.MaTheLoai.ToLower().Contains(filter) ||
                    m.TenTheLoai.ToLower().Contains(filter)).ToList();
                    ViewBag.PM = filter.ToString();
                    return View(dsTL);
                }
                else
                {
                    return View(db.TheLoai.ToList());
                }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }          
        }

        public ActionResult themTL()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themTL(TheLoai model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int check = db.TheLoai.Count(m => m.MaTheLoai == model.MaTheLoai);
                    if (check > 0)
                    {
                        TempData["thongbao"] = "Mã thể loại đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        db.TheLoai.Add(model);
                        db.SaveChanges();
                        TempData["thongbao"] = "Thêm thể loại mới thành công";
                        return View();
                    }
                }
                else
                {
                    TempData["thongbao"] = "Chưa nhập đủ ";
                    return View();
                }
            }
            catch
            {
                TempData["thongbao"] = "Lỗi, vui lòng nhập đầy đủ thông tin";
            }
            return View(model);
        }

        public ActionResult xoaTL(string maTL)
        {
            var TLcanxoa = db.TheLoai.SingleOrDefault(m => m.MaTheLoai.ToLower() == maTL.ToLower());
            db.TheLoai.Remove(TLcanxoa);
            db.SaveChanges();

            TempData["ThongBao"] = "Xóa thành công thể loại  " + TLcanxoa.TenTheLoai;
            return RedirectToAction("DanhSachTL");
        }

        public ActionResult suaTL(int maTL)
        {
            var TLcansua = db.TheLoai.SingleOrDefault(m => m.IdTL == maTL);
            return View(TLcansua);
        }

        [HttpPost]
        public ActionResult suaTL(TheLoai model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.TenTheLoai))
                {
                    var TLcansua = db.TheLoai.SingleOrDefault(m => m.MaTheLoai == model.MaTheLoai);
                    TLcansua.TenTheLoai = model.TenTheLoai;
                    db.SaveChanges();
                    TempData["thongbao"] = "Sửa thông tin thành công";

                    return View();
                }
                else
                {
                    TempData["thongbao"] = "Chưa nhập đủ thông tin";
                    return View();
                }
            }
            catch
            {
                TempData["thongbao"] = "Lỗi, kiểm tra lại";
            }
            return View();
        }
    }
}