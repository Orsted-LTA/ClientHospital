using ClientHospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using ClientHospital.viewModels;
using System.Net.Http;
using System.Text;
using System.Reflection;
using static System.Net.WebRequestMethods;


namespace ClientHospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var dantoc = await httpClient.GetAsync("https://localhost:7196/api/DanToc");
            var phongkham = await httpClient.GetAsync("https://localhost:7196/api/PhongKham");
            var nghe = await httpClient.GetAsync("https://localhost:7196/api/NgheNghiep");
            var quoctich = await httpClient.GetAsync("https://localhost:7196/api/QuocTich");

            if (dantoc.IsSuccessStatusCode && phongkham.IsSuccessStatusCode && nghe.IsSuccessStatusCode)
            {
                var contentdt = await dantoc.Content.ReadAsStringAsync();
                var contentpk = await phongkham.Content.ReadAsStringAsync();
                var contentn = await nghe.Content.ReadAsStringAsync();
                var contentqt = await quoctich.Content.ReadAsStringAsync();


                var dantocs = JsonConvert.DeserializeObject<List<DanTocModel>>(contentdt);
                var phongkhams = JsonConvert.DeserializeObject<List<PhongKhamModel>>(contentpk);
                var nghes = JsonConvert.DeserializeObject<List<NgheNghiepModel>>(contentn);
                var quoctichs = JsonConvert.DeserializeObject<List<QuocTichModel>>(contentqt);
  

                var viewModel = new ViewModel
                {
                    HoSo = new HoSoViewModel(),
                    DanTocs = dantocs,
                    PhongKhams = phongkhams,
                    NgheNghieps = nghes,
                    QuocTichs = quoctichs,
                };
                
                return View(viewModel);
            }
            else
            {
                return View("Error"); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitData(HoSoViewModel hoSo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Tạo HttpClient
                    var httpClient = _httpClientFactory.CreateClient();

                    // Chuyển đối tượng HoSoViewModel thành JSON
                    var jsonHoSo = JsonConvert.SerializeObject(hoSo);

                    // Gửi dữ liệu đến API hoặc endpoint tương ứng để lưu vào cơ sở dữ liệu
                    var response = await httpClient.PostAsync("https://localhost:7196/api/DangKyKham", new StringContent(jsonHoSo, Encoding.UTF8, "application/json"));

                    // Kiểm tra kết quả trả về từ API
                    if (response.IsSuccessStatusCode)
                    {
                        // Nếu thành công, bạn có thể chuyển hướng hoặc hiển thị thông báo thành công
                        return RedirectToAction("Index"); // Chuyển hướng đến trang chính hoặc trang thông báo thành công
                    }
                    else
                    {
                        // Nếu không thành công, bạn có thể xử lý lỗi hoặc hiển thị thông báo lỗi
                        ModelState.AddModelError("", "Có lỗi xảy ra khi gửi dữ liệu.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    ModelState.AddModelError("", "Có lỗi xảy ra khi xử lý dữ liệu: " + ex.Message);
                }
            }

            // Nếu có lỗi xảy ra, hoặc dữ liệu không hợp lệ, bạn cần trả về lại view với model và hiển thị thông báo lỗi
            var viewModel = new ViewModel
            {
                HoSo = hoSo,
                DanTocs = await GetDanTocsAsync(),
                PhongKhams = await GetPhongKhamsAsync(),
                NgheNghieps = await GetNgheNghiepsAsync(),
                QuocTichs = await GetQuocTichsAsync(),
            };

            return View("Index", viewModel); // Trả về view Index với model và hiển thị thông báo lỗi
        }

        private async Task<List<DanTocModel>> GetDanTocsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7196/api/DanToc");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DanTocModel>>(content);
            }
            else
            {
                // Xử lý lỗi hoặc trả về một danh sách rỗng
                return new List<DanTocModel>();
            }
        }
        private async Task<List<PhongKhamModel>> GetPhongKhamsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7196/api/PhongKham");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PhongKhamModel>>(content);
            }
            else
            {
                // Xử lý lỗi hoặc trả về một danh sách rỗng
                return new List<PhongKhamModel>();
            }
        }
        private async Task<List<NgheNghiepModel>> GetNgheNghiepsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7196/api/NgheNghiep");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<NgheNghiepModel>>(content);
            }
            else
            {
                // Xử lý lỗi hoặc trả về một danh sách rỗng
                return new List<NgheNghiepModel>();
            }
        }
        private async Task<List<QuocTichModel>> GetQuocTichsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7196/api/QuocTich");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<QuocTichModel>>(content);
            }
            else
            {
                // Xử lý lỗi hoặc trả về một danh sách rỗng
                return new List<QuocTichModel>();
            }
        }
    }
}
