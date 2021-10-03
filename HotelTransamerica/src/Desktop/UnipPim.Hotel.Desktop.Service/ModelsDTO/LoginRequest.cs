namespace UnipPim.Hotel.Desktop.Service.ModelsDTO
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
