using System;
using System.Collections.Generic;

namespace UnipPim.Hotel.Models
{
    public class UserResponseLogin
    {
        public string AccessToken { get; set; }        
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

    public class UserToken
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
