﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyThuVienEntities1 : DbContext
    {
        public QuanLyThuVienEntities1()
            : base("name=QuanLyThuVienEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CT_PhieuMuon> CT_PhieuMuon { get; set; }
        public virtual DbSet<CT_PhieuTra> CT_PhieuTra { get; set; }
        public virtual DbSet<DocGia> DocGia { get; set; }
        public virtual DbSet<LoaiDG> LoaiDG { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyen { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuon { get; set; }
        public virtual DbSet<PhieuPhat> PhieuPhat { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }
    }
}