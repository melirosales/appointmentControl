using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace appointmentControl.Backend.BussinessLogic
{
    public class Encryption
    {
        private readonly string  keyEncrypt;
        public Encryption(string key)
        {
            this.keyEncrypt = key;
        }
 
        public virtual string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            string saltAndPassword = String.Concat(password, saltkey);
 
            var algorithm = HashAlgorithm.Create(passwordFormat);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name");

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }
  
    }
}