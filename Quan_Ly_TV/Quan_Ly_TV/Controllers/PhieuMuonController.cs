using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quan_Ly_TV.Models;

namespace Quan_Ly_TV.Controllers
{
    public class PhieuMuonController : Controller
    {

        QuanLyThuVienEntities1 db = new QuanLyThuVienEntities1();

        
           
        // GET: PhieuMuon

        [HttpGet]
        public ActionResult DanhSachPM(string filter)
        {
            if (Session["AdminNV"] != null || Session["AdminQL"] != null)
            {
                if (!string.IsNullOrEmpty(filter))

            {
                List<PhieuMuon> dsPM = db.PhieuMuon.Where(m => m.MaDocGia.ToLower().Contains(filter) ||
                m.MaPhieuMuon.ToLower().Contains(filter) == true ||
                m.NhanVien.ToLower().Contains(filter) == true ||
                m.NgayLapPhieu.ToString().Contains(filter)).ToList();
                ViewBag.PM = filter.ToString();
                return View(dsPM);
            }
            else
            {
                List<PhieuMuon> DanhSachPM = db.PhieuMuon.Distinct().ToList();
                return View(DanhSachPM);
            }
            }
            else
            {
                return RedirectToAction("LoginAdmin", "Login");
            }
        }


        public ActionResult lapPM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult lapPM(PhieuMuon model)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.MaPhieuMuon))
                    {
                        ViewBag.themPM = "Chưa nhập mã phiếu mượn";
                        ViewBag.MP = model.MaPhieuMuon;
                        ViewBag.MaDG = model.MaDocGia;
                        return View(model);
                    }
                    else
                    {
                        int check = db.PhieuMuon.Count(m => m.MaPhieuMuon == model.MaPhieuMuon);
                        if (check > 0)
                        {
                            ViewBag.themPM = "Mã phiếu mượn đã tồn tại";
                            ViewBag.MP = model.MaPhieuMuon;
                            ViewBag.MaDG = model.MaDocGia;
                            return View(model);
                        }
                        else
                        {
                            int checkMadg = db.PhieuMuon.Count(m => m.MaDocGia == model.MaDocGia);
                            if (checkMadg > 0)
                            {
                                ViewBag.themPM = "Độc giả " + model.MaDocGia + " đã có phiếu mượn, vui lòng kiểm tra lại";
                                ViewBag.MP = model.MaPhieuMuon;
                                ViewBag.MaDG = model.MaDocGia;
                                return View(model);
                            }
                            else
                            {
                                db.PhieuMuon.Add(model);
                                db.SaveChanges();
                                ViewBag.themPM = "Lập phiếu mượn thành công";
                                return View();
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.themPM = "Chưa nhập đủ thông tin";
                    ViewBag.MP = model.MaPhieuMuon;
                    ViewBag.MaDG = model.MaDocGia;
                    return View(model);
                }
            }
            catch
            {
                ViewBag.themPM = "Lỗi, vui lòng nhập lại";
                ViewBag.MP = model.MaPhieuMuon;
                ViewBag.MaDG = model.MaDocGia;
                return View();
            }
        }

        public ActionResult LapCTPM(string maPM)
        {
            int check = db.PhieuPhat.Count(m => m.MaPhieuMuon == maPM);
            if (check > 0)
            {
                TempData["thongbao"] = "Độc giả đang phạt, không thể mượn sách";
                return RedirectToAction("DanhSachPM");
            }
            else
            {
                if (!string.IsNullOrEmpty(maPM))
                {
                    ViewBag.mapm = maPM.ToString();

                    return View();
                }
                else
                {
                    return RedirectToAction("DanhSachPM");
                }

            }

        }

        [HttpPost]
        public ActionResult LapCTPM(CT_PhieuMuon model, DateTime NgayMuon)
        {
            ViewBag.MaPhieu = model.MaPhieuMuon;
            ViewBag.MaDG = model.MaDocGia;
            ViewBag.HoTen = model.TenDocGia;
            ViewBag.TenSach = model.MaSach;
            ViewBag.SoLuong = model.SoLuong;
            try
            { 
                
                    if (!string.IsNullOrEmpty(model.HanTra.ToString()))
                    {
                        if (NgayMuon.CompareTo(model.HanTra) == -1)
                        {                       
                            if (model.SoLuong > 3)
                            {
                                TempData["report"] = "Mỗi sách chỉ được phép mượn tối đa 3 cuốn";
                                return View();
                            }
                            else
                            {
                                DateTime nm = Convert.ToDateTime(NgayMuon);
                                DateTime nt = Convert.ToDateTime(model.HanTra);

                                TimeSpan time = nt - nm;
                                int sumDay = time.Days;

                                if (sumDay < 15)
                                {
                                    var dem = db.CT_PhieuMuon.Count(m => m.MaPhieuMuon == model.MaPhieuMuon);

                                    if (dem <= 2)
                                    {
                                        var sach = db.Sach.SingleOrDefault(m => m.MaSach == model.MaSach);
                                        if(sach.SoLuong < model.SoLuong)
                                        {
                                            TempData["report"] = "Sách " + sach.TenSach + " đã hết";
                                            return View();                                      
                                        }
                                        else
                                        {

                                            sach.SoLuong = sach.SoLuong - model.SoLuong;
                                            db.CT_PhieuMuon.Add(model);
                                            db.SaveChanges();
                                            TempData["report"] = "Mượn thành công sách : " + sach.TenSach;
                                            return View();
                                                                                    
                                         }                                     
                                    }
                                    else
                                    {
                                        TempData["report"] = "Hết lượt mượn sách";
                                        return View();
                                    }


                                }
                                else
                                {
                                    TempData["report"] = "Hạn trả phải ít hơn 15 ngày";
                                    return View();
                                }

                            }
                        }
                        else
                        {
                            TempData["report"] = "Ngày trả phải lớn hơn ngày mượn";
                            return View();
                        }
                    }
                    else
                    {
                        TempData["report"] = "Chưa nhập đủ dữ liẹu";
                        return View();
                    }
                
            }
            catch
            {
                TempData["report"] = "Lỗi, vui lòng nhập lại";
            }
            return View(model);
        }

        public ActionResult xoaPM(int id)
        {
            try
            {
                var PMcanxoa = db.PhieuMuon.SingleOrDefault(m => m.Id == id);
                int check = db.CT_PhieuMuon.Count(m => m.MaPhieuMuon == PMcanxoa.MaPhieuMuon);
                if (check > 0)
                {
                    TempData["thongbao"] = "Không thể xóa , độc giả " + PMcanxoa.MaDocGia + " chưa trả sách";
                    return RedirectToAction("DanhSachPM");

                }
                else
                {
                    db.PhieuMuon.Remove(PMcanxoa);
                    db.SaveChanges();
                    TempData["thongbao"] = "Xóa phiếu mượn thành công";
                    return RedirectToAction("DanhSachPM");
                }             
                
            }
            catch
            {
                TempData["thongbao"] = "Độc giả đang phạt, không được xóa";
                return RedirectToAction("DanhSachPM");
            }
            
        }

        public ActionResult xemCTPM(string maDG)
        {
            if (!string.IsNullOrEmpty(maDG))
            {
            var MADG = db.CT_PhieuMuon.Where(m => m.MaDocGia == maDG).ToList();
            return View(MADG);
            }
            else
            {
                return RedirectToAction("DanhSachPM");
            }

        }

        public ActionResult keyWord(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                List<CT_PhieuMuon> dsCT = db.CT_PhieuMuon.Where(m => m.MaDocGia.ToLower().Contains(keyWord) ||
                m.MaPhieuMuon.ToLower().Contains(keyWord) == true ||
                m.MaDocGia.ToLower().Contains(keyWord) == true ||
                m.TenDocGia.ToLower().Contains(keyWord) == true ||
                m.SoLuong.ToString().Contains(keyWord) == true ||
                m.HanTra.ToString().Contains(keyWord)).ToList();
                ViewBag.PM = keyWord.ToString();
                return View(dsCT);
            }

            else
            {
                return RedirectToAction("xemCTPM");
            }
        }
    } 
}