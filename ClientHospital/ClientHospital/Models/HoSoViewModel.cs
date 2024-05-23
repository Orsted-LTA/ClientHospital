using System.ComponentModel.DataAnnotations;

namespace ClientHospital.Models
{
    public class HoSoViewModel
    {
        public string MaHoSo { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập CCCD.")]
        public string CCCD { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ đệm.")]
        [MaxLength(120, ErrorMessage = "Họ đệm không được vượt quá 120 ký tự.")]
        public string HoDem { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        [MaxLength(10, ErrorMessage = "Tên không được vượt quá 10 ký tự.")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [MaxLength(12, ErrorMessage = "Số điện thoại không được vượt quá 12 ký tự.")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [MaxLength(70, ErrorMessage = "Email không được vượt quá 70 ký tự.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        [MaxLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string Duong { get; set; }

        public string IdPhuong { get; set; }
        public DateTime? NgayTaoHoSo { get; set; } = DateTime.Now;
        public DateTime NgayKham { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn phòng.")]
        public int IdPhong { get; set; }
        public DateTime NgayTao { get; set; }
        public int? IdQuocTich { get; set; } = null;
        public int? IdDanToc { get; set; } = null;
        public int? IdNgheNghiep { get; set; } = null;
        public string GioKham { get; set; } = "";
    }
}
