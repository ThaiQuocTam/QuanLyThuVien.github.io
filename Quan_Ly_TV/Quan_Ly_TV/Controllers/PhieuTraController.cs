using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class PhieuTraController : Controller
    {
        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();
        
        [HttpGet]
        public ActionResult DsPhieuTra(string filter)
        {

            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    List<CT_PhieuTra> dsPT = db.CT_PhieuTra.Where(m => m.MaPhieuTra.ToLower().Contains(filter) ||
                    m.MaPhieuMuon.ToLower().Contains(filter) == true ||
                    m.MaDocGia.ToLower().Contains(filter) == true ||
                    m.TenDocGia.Contains(filter) == true ||
                    m.TenSach.ToLower().Contains(filter)).ToList();
                    ViewBag.PT = filter.ToString();
                    return View(dsPT);
                }
                else
                {
                    return View(db.CT_PhieuTra.ToList());
                }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }
        }


        public ActionResult TraSach(int idPM)
        {
            ViewBag.ID = idPM;
            return View();
        }

        [HttpPost]
        public ActionResult TraSach(CT_PhieuTra model, int idPM)
        {
            var CTPMcanxoa = db.CT_PhieuMuon.Find(idPM);
            ViewBag.MaPT = model.MaPhieuTra;
            ViewBag.MaPM = model.MaPhieuMuon;
            ViewBag.MaDG = model.MaDocGia;
            ViewBag.TenDG = model.TenDocGia;
            ViewBag.TenSach = model.TenSach;
            ViewBag.Soluong = model.SoLuong;
            ViewBag.Hantra = model.HanTra;
            ViewBag.NGTT = model.NgayTraThucTe;
            ViewBag.Ghichu = model.GhiChu;
            if (!string.IsNullOrEmpty(model.MaPhieuTra))
            {
                    int check = db.CT_PhieuTra.Count(m => m.MaPhieuTra == model.MaPhieuTra);
                    if(check == 0)
                    {
                    if (model.NgayTraThucTe != null)
                    {
                        var sach = db.Sach.SingleOrDefault(m => m.TenSach.ToLower() == model.TenSach.ToLower());
                        sach.SoLuong = sach.SoLuong + model.SoLuong;
                        db.CT_PhieuTra.Add(model);
                        db.CT_PhieuMuon.Remove(CTPMcanxoa);
                        db.SaveChanges();
                        TempData["thongbao"] = "Trả sách  " + model.TenSach + " thành công || Số lượng : " + model.SoLuong;
                        return View();
                    }
                    else
                    {
                        TempData["thongbao"] = "Chưa nhập đủ thông tin";

                        return View();
                    }
                    }
                    else
                    {
                        TempData["thongbao"] = "Mã phiếu trả đã tồn tại";
                        return View();
                    }
                    
                
            }
            else
            {
                TempData["thongbao"] = "Chưa nhập mã phiếu trả";
                return View();
            }
        }

        public ActionResult xoaPT(int id)
        {
            var PTcanxoa = db.CT_PhieuTra.SingleOrDefault(m=>m.IdCTPhieuTra == id);
            db.CT_PhieuTra.Remove(PTcanxoa);
            db.SaveChanges();
            TempData["error"] = "Xóa phiếu trả thành công";

            return RedirectToAction("DsPhieuTra");
        }
    }
}