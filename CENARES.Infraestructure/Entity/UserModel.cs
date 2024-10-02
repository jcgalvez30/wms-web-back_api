
namespace CENARES.Infraestructure.Entity
{
    public class UserModel
    {
        private string _username;
        private string _email;
        private string _nombres;
        private string _apellidos;
        private bool _typeuser;
        private string _domainname;
        private string _token;

        public UserModel(string username, string email, string token, string nombres, string apellidos, string domainname, bool typeuser)
        { 
            this._username = username;
            this._email = email;
            this._nombres = nombres;
            this._apellidos = apellidos;
            this._domainname = domainname;
            this._token = token;
            this._typeuser = typeuser;

        }

        public string Username { get => _username; set => _username = value; }
        public string Email { get => _email; set => _email = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public bool TypeUser{ get => _typeuser; set => _typeuser = value; }
        public string DomainName { get => _domainname; set => _domainname = value; }
        public string Token { get => _token; set => _token = value; }
    }
}
