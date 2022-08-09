using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class DocGiaController : Controller
    {
        // GET: DocGia
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();


        [HttpGet]
        public ActionResult DsDocGia(string filter)
        {

            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    List<DocGia> dsDG = db.DocGia.Where(m => m.MaDocGia.ToLower().Contains(filter) ||
                    m.HoTen.ToLower().Contains(filter) == true ||
                    m.DiaChi.ToLower().Contains(filter) == true ||
                    m.SoDienThoai.Contains(filter) == true ||
                    m.Email.ToLower().Contains(filter) == true ||
                    m.LoaiDG.ToLower().Contains(filter)).ToList();
                    ViewBag.PM = filter.ToString();
                    return View(dsDG);
                }
                else
                {
                    return View(db.DocGia.ToList());
                }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }    
        }

        public ActionResult xoaDG(int id)
        {
            var DGcanxoa = db.DocGia.SingleOrDefault(m => m.Id == id);
            
            try{
                int check = db.PhieuMuon.Count(m => m.MaDocGia == DGcanxoa.MaDocGia);
                if(check > 0) {
                    TempData["error"] = "Không thể xóa độc giả còn phiếu mượn";
                    return RedirectToAction("DsDocGia");
                }
                else
                {
                    db.DocGia.Remove(DGcanxoa);
                    TempData["error"] = "Xóa thành công độc giả  " + DGcanxoa.HoTen.ToString();
                    db.SaveChanges();
                    return RedirectToAction("DsDocGia");
                }
            }
            catch
            {
                TempData["error"] = "Loi";
            }

            return RedirectToAction("DsDocGia");
        }

        public ActionResult themDG()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themDG(DocGia model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.MaDocGia))
                {
                    if (ModelState.IsValid)
                    {

                        {
                            int check = db.DocGia.Count(m => m.MaDocGia == model.MaDocGia);
                            if (check > 0)
                            {
                                ViewBag.themDG = "Mã độc giả đã tồn tại";
                                ViewBag.HoTen = model.HoTen;
                                ViewBag.MaDocGia = model.MaDocGia;
                                ViewBag.NgaySinh = model.NgaySinh;
                                ViewBag.DiaChi = model.DiaChi;
                                ViewBag.GioiTinh = model.GioiTinh;
                                ViewBag.SoDienThoai = model.SoDienThoai;
                                ViewBag.Email = model.Email;
                                ViewBag.LoaiDG = model.LoaiDG;
                                return View();

                            }
                            else
                            {
                                db.DocGia.Add(model);
                                db.SaveChanges();
                                ViewBag.themDG = "Thêm Độc Giả mới thành công";
                                return View();
                            }
                        }
                    }
                    else
                    {
                        ViewBag.HoTen = model.HoTen;
                        ViewBag.MaDocGia = model.MaDocGia;
                        ViewBag.NgaySinh = model.NgaySinh;
                        ViewBag.DiaChi = model.DiaChi;
                        ViewBag.GioiTinh = model.GioiTinh;
                        ViewBag.SoDienThoai = model.SoDienThoai;
                        ViewBag.Email = model.Email;
                        ViewBag.LoaiDG = model.LoaiDG;

                        ViewBag.themDG = "Chua nhập đủ thông tin";
                        return View();
                    }

                }
                else
                {
                    ViewBag.HoTen = model.HoTen;
                    ViewBag.MaDocGia = model.MaDocGia;
                    ViewBag.NgaySinh = model.NgaySinh;
                    ViewBag.DiaChi = model.DiaChi;
                    ViewBag.GioiTinh = model.GioiTinh;
                    ViewBag.SoDienThoai = model.SoDienThoai;
                    ViewBag.Email = model.Email;
                    ViewBag.LoaiDG = model.LoaiDG;

                    ViewBag.themDG = "Chưa nhập Mã độc giả";
                    return View();
                }
                
            }
            catch
            {
                ViewBag.themDG = "Lõi, kiểm tra lại";
                ViewBag.HoTen = model.HoTen;
                ViewBag.MaDocGia = model.MaDocGia;
                ViewBag.NgaySinh = model.NgaySinh;
                ViewBag.DiaChi = model.DiaChi;
                ViewBag.GioiTinh = model.GioiTinh;
                ViewBag.SoDienThoai = model.SoDienThoai;
                ViewBag.Email = model.Email;
                ViewBag.LoaiDG = model.LoaiDG;
            }
            return View();
        }

        public ActionResult suaDG(int id)
        {
            var DGcansua = db.DocGia.SingleOrDefault(m => m.Id == id);
            return View(DGcansua);
        }

        [HttpPost]
        public ActionResult suaDG(DocGia model)
        {
            if (model != null)
            {

                var DGcansua = db.DocGia.Single(m => m.Id == model.Id);
                DGcansua.HoTen = model.HoTen;
                DGcansua.NgaySinh = model.NgaySinh;
                DGcansua.DiaChi = model.DiaChi;
                DGcansua.GioiTinh = model.GioiTinh;
                DGcansua.SoDienThoai = model.SoDienThoai;
                DGcansua.Email = model.Email;
                DGcansua.LoaiDG = model.LoaiDG;

                db.SaveChanges();
                ViewBag.Sua = "Sua thông tin thành công";
                return View(model);
            }
            else
            {
                ViewBag.Sua = "Sua thông tin thất bại";
                return View(model);
            }
        }
    }
}