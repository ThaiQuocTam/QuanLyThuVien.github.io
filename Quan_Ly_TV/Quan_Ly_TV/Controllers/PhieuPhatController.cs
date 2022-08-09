using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class PhieuPhatController : Controller
    {
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();


        [HttpGet]
        public ActionResult DsPhieuPhat(string filter)
        {

            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    List<PhieuPhat> dsPP = db.PhieuPhat.Where(m => m.MaPhieuPhat.ToLower().Contains(filter) ||
                    m.MaPhieuMuon.ToLower().Contains(filter) == true ||
                    m.MaDocGia.ToLower().Contains(filter)).ToList();
                    ViewBag.PP = filter.ToString();
                    return View(dsPP);
                }
                else
                {
                    return View(db.PhieuPhat.ToList());
                }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }
        }
        // GET: PhieuPhat
        public ActionResult LapPhieuPhat(string maPM)
        {
            int checkpp = db.PhieuPhat.Count(m => m.MaPhieuMuon == maPM);
            if(checkpp > 0)
            {
                @TempData["thongbao"] = "Độc giả đang phạt";
                return RedirectToAction("DanhSachPM", "PhieuMuon");
            }
            else
            {
                ViewBag.maPm = maPM;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult LapPhieuPhat(PhieuPhat model)
        {
            ViewBag.Mapp = model.MaPhieuPhat;
            ViewBag.Mapm = model.MaPhieuMuon;
            ViewBag.MaDG = model.MaDocGia;
            ViewBag.NV = model.NhanVien;
            ViewBag.NgayLP = model.NgayLapPhieu;
            ViewBag.LD = model.LyDoPhat;
            ViewBag.tien = model.TienPhat;

            try{
                if (string.IsNullOrEmpty(model.MaPhieuPhat))
                {
                    TempData["report"] = "Chưa nhập mã phiếu phạt";
                    return View();
                }
                else
                {
                    if(model.NgayLapPhieu == null || model.TienPhat == null || model.LyDoPhat == null)
                    {
                        TempData["report"] = "Chưa nhập đủ thông tin";
                        return View();
                    }
                    else
                    {
                        int checkPP = db.PhieuPhat.Count(m => m.MaPhieuPhat == model.MaPhieuPhat);
                        if(checkPP > 0)
                        {
                            TempData["report"] = "Mã phiếu phạt đã tồn tại";
                            return View();
                        }
                        else
                        {
                            db.PhieuPhat.Add(model);
                            db.SaveChanges();
                            TempData["report"] = "Lập phiếu phạt thành công";
                            return View();
                        }                        
                    }
                }
            }
            catch
            {
                TempData["report"] = "Lỗi, kiểm tra lại";
            }
            return View();
        }

        public ActionResult xoaPP(int id)
        {
            var PPcanxoa = db.PhieuPhat.SingleOrDefault(m => m.Id == id);
            db.PhieuPhat.Remove(PPcanxoa);
            db.SaveChanges();

            TempData["error"] = "Nộp phạt thành công";
            return RedirectToAction("DsPhieuPhat");
        }
    }
}