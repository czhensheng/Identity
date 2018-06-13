using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Users.Models
{
    /// <summary>
    /// 用户类，派生于IdentityUser
    /// IdentityUser 命名空间是 Microsoft.AspNet.Identity.EntityFramework
    /// IdentityUser提供了基本的用户表示 可以在它的派生在中添加属性和方法
    /// IdentityUser类内置的属性
    /// IdentityUser类只提供了对用户基本信息的访问：用户名、E-mail、电话、哈希口令、角色成员等等。如果希望存储用户的各种附加信息，就需要在IdentityUser派生的类上添加属性，并将它用于表示应用程序中的用户
    /// </summary>
    public class AppUser : IdentityUser
    {
        // 这里将放置附加属性
    }
}