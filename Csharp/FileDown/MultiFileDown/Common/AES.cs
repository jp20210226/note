using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace MultiFileDown.Common
{
    public static class AES
    {
        public static byte[] AESDecrypt(byte[] source, string password, string iv = "                ")
        {
            RijndaelManaged managed = new RijndaelManaged {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] destinationArray = new byte[0x10];
            int length = bytes.Length;
            if (length > destinationArray.Length)
            {
                length = destinationArray.Length;
            }
            Array.Copy(bytes, destinationArray, length);
            managed.Key = destinationArray;
            byte[] buffer3 = Encoding.UTF8.GetBytes(iv);
            managed.IV = buffer3;
            return managed.CreateDecryptor().TransformFinalBlock(source, 0, source.Length);
        }

        public static byte[] AESEncrypt(byte[] source, string password, string iv = "                ")
        {
            RijndaelManaged managed = new RijndaelManaged {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 0x80,
                BlockSize = 0x80
            };
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] destinationArray = new byte[0x10];
            int length = bytes.Length;
            if (length > destinationArray.Length)
            {
                length = destinationArray.Length;
            }
            Array.Copy(bytes, destinationArray, length);
            managed.Key = destinationArray;
            byte[] buffer3 = Encoding.UTF8.GetBytes(iv);
            managed.IV = new byte[0x10];
            return managed.CreateEncryptor().TransformFinalBlock(source, 0, source.Length);
        }

        public static string GetRandomString(int length = 0x10, string custom = "", bool useNum = true, bool useLow = true, bool useUpp = true, bool useSpe = false)
        {
            byte[] data = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(data);
            Random random = new Random(BitConverter.ToInt32(data, 0));
            string str = null;
            string str2 = custom;
            
            if (useLow)
            {
                str2 = str2 + "abcdefghijklmnopqrstuvwxyz";
            }
            if (useUpp)
            {
                str2 = str2 + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (useNum)
            {
                str2 = str2 + "0123456789";
            }
            if (useSpe)
            {
                str2 = str2 + "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            }
            for (int i = 0; i < length; i++)
            {
                str = str + str2.Substring(random.Next(0, str2.Length - 1), 1);
            }
            return str;
        }
    }
}

