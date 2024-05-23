using System.ComponentModel.DataAnnotations;

namespace ClientHospital.Models
{
    public class ThongTinModel
    {
        public int id { get; set; }
    }
    public class DanTocModel
    {
        public int id { get; set; }
        [Required]
        public string TenDanToc { get; set; }
    }
    public class PhongKhamModel
    {
        public int id { get; set; }
        [Required]
        public string tenPhongKham { get; set; }
        public int soLuongToiDa { get; set; }
    }
    public class NgheNghiepModel
    {
        public int id { get; set; }
        [Required]
        public string TenNgheNghiep { get; set; }
    }
    public class QuocTichModel
    {
        public int id { get; set; }
        [Required]
        public string TenQuocTich { get; set; }
        public string TenVietTat { get; set; }
    }

    //public class TinhModel
    //{
    //    public string IdTinh { get; set; }
    //    public string TenTinh { get; set; }
    //}
    //public class HuyenModel
    //{
    //    public string IdHuyen { get; set; }
    //    public string TenHuyen { get; set; }
    //}
    //public class PhuongModel
    //{
    //    public string IdPhuong { get; set; }
    //    public string TenPhuong { get; set; }
    //}
}
