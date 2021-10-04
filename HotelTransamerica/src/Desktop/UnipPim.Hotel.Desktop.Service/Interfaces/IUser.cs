using System.Collections.Generic;
using System.Net;

namespace UnipPim.Hotel.Desktop.Service.Interfaces
{
    public interface IUser
    {
        string GetEmail();
        IEnumerable<Cookie> GetCookie();

        void AddEmail(string email);
        void AddCookie(IEnumerable<Cookie> cookie);
    }
}
