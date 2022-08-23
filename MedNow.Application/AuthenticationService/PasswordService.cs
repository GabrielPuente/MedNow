using Scrypt;

namespace MedNow.Application.AuthenticationService
{
    public static class PasswordService
    {
        private static readonly ScryptEncoder encoder = new();

        public static string Encrypt(string password)
        {
            return encoder.Encode(password);
        }

        public static bool CheckPassword(string password, string hashPassword)
        {
            return encoder.Compare(password, hashPassword);
        }
    }
}
