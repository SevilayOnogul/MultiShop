using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index(string culture, string returnUrl)
        {
            // Kullanıcının seçtiği dili çerezlere ekliyoruz
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            // Kullanıcıyı kaldığı sayfaya geri gönderiyoruz
            return LocalRedirect(returnUrl);
        }
    }
}