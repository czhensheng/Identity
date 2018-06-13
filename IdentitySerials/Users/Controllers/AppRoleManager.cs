using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Infrastructure;
using Users.Models;

namespace Users.Controllers
{
    public class AppRoleManager : RoleManager<AppRole>, IDisposable
    {

        public AppRoleManager(RoleStore<AppRole> store) : base(store) { }

        public static AppRoleManager Create(
                IdentityFactoryOptions<AppRoleManager> options,
                IOwinContext context)
        {
            //让OWIN启动类能够为每一个访问Identity数据的请求创建实例
            return new AppRoleManager(new
                    RoleStore<AppRole>(context.Get<AppIdentityDbContext>()));
        }
    }
}