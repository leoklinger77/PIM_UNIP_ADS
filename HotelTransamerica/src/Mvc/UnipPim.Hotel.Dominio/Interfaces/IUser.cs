using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace UnipPim.Hotel.Dominio.Interfaces
{
    public interface IUser
    {
        string UserName { get; }
        Guid UserId { get; }
        string GetUserEmail();        
        bool IsAuthentication();
        bool HasRoles(string role);        
        IEnumerable<Claim> FindClaims();
        HttpContext FindHttpContext();
    }
}
