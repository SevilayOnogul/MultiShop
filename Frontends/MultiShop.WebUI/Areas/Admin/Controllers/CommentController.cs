using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();

            // 1. Adım: Yorumları Çek
            var responseMessage = await client.GetAsync("https://localhost:7275/api/Comments");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

            // 2. Adım: Ürünleri Çek 
            var productResponse = await client.GetAsync("http://localhost:7070/api/Products");
            if (productResponse.IsSuccessStatusCode)
            {
                var productData = await productResponse.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);

                // 3. Adım: Eşleştirme Yap
                foreach (var comment in comments)
                {
                    var matchedProduct = products.FirstOrDefault(x => x.ProductId == comment.ProductId);
                    if (matchedProduct != null)
                    {
                        comment.ProductName = matchedProduct.ProductName;
                    }
                }
            }

            return View(comments);
        }

        [HttpGet]
        [Route("CreateComment")]

        public IActionResult CreateComment()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateComment")]

        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7275/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteComment/{id}")]

        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7275/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();

            // 1. Önce Yorumu Getir
            var responseMessage = await client.GetAsync("https://localhost:7275/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);

                // 2. Yorumun içindeki ProductId'yi kullanarak Ürün Adını Getir
                // Port numarasını Catalog API portuna göre (örn: 7070) güncelle
                var productResponse = await client.GetAsync("http://localhost:7070/api/Products/" + values.ProductId);

                if (productResponse.IsSuccessStatusCode)
                {
                    var productData = await productResponse.Content.ReadAsStringAsync();
                    // JObject kullanarak tüm DTO'yu oluşturmadan hızlıca ProductName çekebilirsin
                    var product = JsonConvert.DeserializeObject<dynamic>(productData);
                    ViewBag.ProductName = product.productName;
                }

                return View(values);
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7275/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}