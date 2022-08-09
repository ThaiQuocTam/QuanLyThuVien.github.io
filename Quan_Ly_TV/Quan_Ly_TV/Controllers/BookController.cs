using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();

        [HttpGet]
        public ActionResult ListBook(string filter)
        {
            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    List<Sach> dsDG = db.Sach.Where(m => m.MaSach.ToLower().Contains(filter) ||
                    m.TenSach.ToLower().Contains(filter) == true ||
                    m.TacGia.Contains(filter)).ToList();
                    ViewBag.keyword = filter.ToString();
                    return View(dsDG);
                }
                else
                {
                    return View(db.Sach.ToList());
                }
            }

            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }

            
        }

        public ActionResult themmoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themmoi(Sach model, HttpPostedFileBase AnhBia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int check = db.Sach.Count(m => m.MaSach == model.MaSach);
                    if (check > 0)
                    {
                        TempData["thongbao"] = "Mã sách đã tồn tại";
                        return View(model);
                    }
                    else
                    {
                        try
                        {
                            if(AnhBia != null && AnhBia.ContentLength > 0)
                            {
                                string rootFolder = Server.MapPath("/Data/");
                                string pathEmail = rootFolder + AnhBia.FileName;
                                AnhBia.SaveAs(pathEmail);
                                
                                model.AnhBia = "/Data/" + AnhBia.FileName;

                            }
                            db.Sach.Add(model);
                            db.SaveChanges();
                            TempData["thongbao"] = "Thêm sách mới thành công";
                            return View();
                        }
                        catch
                        {
                            TempData["thongbao"] = "chưa nhập đủ dữ liệu";
                            return View();
                        }
                        
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
                TempData["thongbao"] = "Lỗi, kiểm tra lại";
            }
            return View(model);
        }

        public ActionResult xoaSach(int id)
        {
            var Scanxoa = db.Sach.SingleOrDefault(m=>m.IdSach == id);
            db.Sach.Remove(Scanxoa);
            db.SaveChanges();
            TempData["thongbao"] = "Xóa sách thành công";
            return RedirectToAction("ListBook");
        }

        public ActionResult suaSach(int id)
        {
            var Scansua = db.Sach.SingleOrDefault(m => m.IdSach == id);
            return View(Scansua);
        }

        [HttpPost]
        public ActionResult suaSach(Sach model, HttpPostedFileBase AnhBia)
        {
            var Scansua = db.Sach.SingleOrDefault(m => m.IdSach == model.IdSach);
            try
            {
                if (AnhBia != null && AnhBia.ContentLength > 0)
                {
                    string rootFolder = Server.MapPath("/Data/");
                    string pathEmail = rootFolder + AnhBia.FileName;
                    AnhBia.SaveAs(pathEmail);

                    model.AnhBia = "/Data/" + AnhBia.FileName;
                    Scansua.AnhBia = model.AnhBia;
                }
                Scansua.TenSach = model.TenSach;
                Scansua.TheLoai = model.TheLoai;
                Scansua.TacGia = model.TacGia;
                Scansua.NgayXuatBan = model.NgayXuatBan;
                Scansua.SoLuong = model.SoLuong;
                db.SaveChanges();
                TempData["thongbao"] = "Sửa thông tin sách thành công";
                return View(model);
            }
            catch
            {
                TempData["thongbao"] = "Lỗi, kiểm tra lại";
            }
            return View(model);
        }
    }
}