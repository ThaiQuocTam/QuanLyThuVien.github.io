//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_Ly_TV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_PhieuTra
    {
        public int IdCTPhieuTra { get; set; }
        public string MaPhieuTra { get; set; }
        public string MaPhieuMuon { get; set; }
        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public Nullable<System.DateTime> HanTra { get; set; }
        public Nullable<System.DateTime> NgayTraThucTe { get; set; }
        public string GhiChu { get; set; }
        public string TenSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual PhieuMuon PhieuMuon { get; set; }
    }
}
