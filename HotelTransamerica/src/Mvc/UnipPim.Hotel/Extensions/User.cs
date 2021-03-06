using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using UnipPim.Hotel.Dominio.Interfaces;

namespace UnipPim.Hotel.Extensions
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string UserName => _accessor.HttpContext.User.Identity.Name;

        public Guid UserId => IsAuthentication() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;

        public IEnumerable<Claim> FindClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext FindHttpContext()
        {
            return _accessor.HttpContext;
        }

        public string GetUserEmail()
        {
            return IsAuthentication() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public bool HasRoles(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public bool IsAuthentication()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

    }

    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal is null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst("Email");
            return claim?.Value;
        }        
    }
}
