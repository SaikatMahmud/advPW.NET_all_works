using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Asg.EF.Models;

namespace ZeroHunger_Asg.Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["user"];
            if (user != null && user.Type.Equals("Admin")) return true;
            return false;

        }
    }
}