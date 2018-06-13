using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Users.Models;

namespace Users.Infrastructure
{
    /// <summary>
    /// 创建Entity Framework数据库的上下文，用于对AppUser类进行操作
    /// 上下文类派生于IdentityDbContext<T> T就用户类，如实例中的AppUser
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        //AppIdentityDbContext类的构造器调用了它的基类，其参数是连接字符串的名称，IdentityDb，用于与数据库连接
        public AppIdentityDbContext() : base("IdentityDb")
        {

        }


        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }


        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit
         : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {

        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            // initial configuration will go here
            // 初始化配置将放在这儿
        }
    }
}