using ClientHospital.Models;
using System.ComponentModel.DataAnnotations;

namespace ClientHospital.viewModels
{
    public class ViewModel
    {
        public HoSoViewModel HoSo { get; set; }
        public List<DanTocModel> DanTocs { get; set; }
        public List<PhongKhamModel> PhongKhams { get; set; }
        public List<NgheNghiepModel> NgheNghieps { get; set; }
        public List<QuocTichModel> QuocTichs { get; set; }
    }
}
