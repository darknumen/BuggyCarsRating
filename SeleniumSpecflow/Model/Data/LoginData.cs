

namespace SeleniumSpecflow.Model.Data
{
    public class LoginData
    {
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;

        public LoginData WithUsername(string username)
        {
            this.Username = username;
            return this;
        }

        public LoginData WithPassword(string password)
        {
            this.Password = password;
            return this;
        }
    }
}
