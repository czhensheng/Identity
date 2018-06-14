using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (ModelState.IsValid)
            {
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]    
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name,
                            details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    //创建一个标识该用户的ClaimsIdentity对象。ClaimsIdentity类是IIdentity接口的ASP.NET Identity实现
                    //创建Cookie，浏览器会在后继的请求中发送这个Cookie
                    System.Security.Claims.ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                                DefaultAuthenticationTypes.ApplicationCookie);
                    //签出用户，这通常意味着使标识已认证用户的Cookie失效
                    AuthManager.SignOut();
                    //签入用户，这通常意味着要创建用来标识已认证请求的Cookie
                    AuthManager.SignIn(new AuthenticationProperties
                    {//配置认证过程
                        //IsPersistent属性设置为true，以使认证Cookie在浏览器中是持久化的，意即用户在开始新会话时，不必再次进行认证
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}