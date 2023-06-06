using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        string BaseURI = "http://localhost:5001/";

        public async Task<IActionResult> Index()
        {
            List<WebAPI.Models.Produk> datas = new List<WebAPI.Models.Produk>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseURI);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync("Produk/list");
                    if (Res.IsSuccessStatusCode)
                    {
                        var Result = Res.Content.ReadAsStringAsync().Result;
                        datas = JsonConvert.DeserializeObject<List<WebAPI.Models.Produk>>(Result);
                    }

                }
            }
            catch (Exception ex)
            {               
                Console.WriteLine(ex.Message);
            }

            return View(datas);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<WebAPI.Models.Produk> produks = new List<WebAPI.Models.Produk>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage resp = await client.GetAsync("Produk/list");
                if (resp.IsSuccessStatusCode)
                {
                    var Result = resp.Content.ReadAsStringAsync().Result;
                    produks = JsonConvert.DeserializeObject<List<WebAPI.Models.Produk>>(Result);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WebAPI.Models.Produk obj)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.PostAsJsonAsync(BaseURI + "Produk/add", obj).Result;
                if (Res.IsSuccessStatusCode)
                {
                    ViewBag.msg = "New Data Submitted";
                    ModelState.Clear();
                }
                else ViewBag.msg = "Submit Data Failed";

            }
            return View();

        }

        public async Task<IActionResult> Edit(int? id)
        {
            WebAPI.Models.Produk _produk = new WebAPI.Models.Produk();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Produk/get/?produk_id=" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var Result = Res.Content.ReadAsStringAsync().Result;
                    _produk = JsonConvert.DeserializeObject<WebAPI.Models.Produk>(Result);

                }
            }
            return View(_produk);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WebAPI.Models.Produk obj)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.PutAsJsonAsync(BaseURI + "Produk/edit", obj).Result;
                if (Res.IsSuccessStatusCode)
                    ViewBag.msg = "Data Updated";
                else ViewBag.msg = "Update Data Failed";

            }
            return View();

        }

        public async Task<IActionResult> Delete(int? id)
        {
            WebAPI.Models.Produk _produk = new WebAPI.Models.Produk();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("Produk/get/?produk_id=" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var Result = Res.Content.ReadAsStringAsync().Result;
                    _produk = JsonConvert.DeserializeObject<WebAPI.Models.Produk>(Result);

                }
            }
            return View(_produk);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WebAPI.Models.Produk obj)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURI);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.DeleteAsync(BaseURI + "Produk/delete?id=" + obj.id).Result;
                if (Res.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Data Deleted";
                }
                else ViewBag.msg = "Delete Data Failed";

            }
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}