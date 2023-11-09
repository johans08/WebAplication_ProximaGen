using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebAplication_ProximaGen.Logica
{
    public class Cifrados
    {
        public string ConvertirMD5(string input)
        {
            try
            {
                byte[] contrasenna = UTF8Encoding.UTF8.GetBytes(input);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                contrasenna = md5.ComputeHash(contrasenna);
                return Convert.ToBase64String(contrasenna, 0, contrasenna.Length);
            }
            catch (Exception)
            {

                return input;
            }
            
        }
    }
}