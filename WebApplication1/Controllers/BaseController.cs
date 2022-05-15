using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
      
    }
    public static class UsermangerToken
    {
        public static string GetLoginId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

           return  principal.FindFirstValue (ClaimTypes.NameIdentifier);
        }
    }
}
