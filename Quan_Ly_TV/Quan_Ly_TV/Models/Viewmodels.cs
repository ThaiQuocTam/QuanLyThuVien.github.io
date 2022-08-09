using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_Ly_TV.Models
{
    public class Viewmodels
    {
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string HinhAnh { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public Sach sach { get; set; }
        public PhieuMuon phieumuon { get; set; }
        public CT_PhieuMuon ctpm { get; set; }
        public IEnumerable<Sach> dsSach { get; set; }
        public string Masach { get; set; }
        public int? TongSoLuong { get; set; }
    }
}