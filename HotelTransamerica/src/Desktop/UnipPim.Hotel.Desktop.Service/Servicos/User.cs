using System.Collections.Generic;
using System.Net;
using UnipPim.Hotel.Desktop.Service.Interfaces;

namespace UnipPim.Hotel.Desktop.Service.Servicos
{
    public class User : IUser
    {
        private IEnumerable<Cookie> _cookies;
        private string _email;

        public User() { }

        public User(IEnumerable<Cookie> cookies)
        {
            _cookies = cookies;
        }

        public IEnumerable<Cookie> GetCookie()
        {
            return _cookies;
        }

        public void AddCookie(IEnumerable<Cookie> cookie)
        {
            _cookies = cookie;
        }

        

        public string GetEmail()
        {
            return _email;
        }

        public void AddEmail(string email)
        {
            _email = email;
        }
    }
}
