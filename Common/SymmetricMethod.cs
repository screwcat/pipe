using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LTP.Common
{
    /// <summary>
    /// SymmetricMethod 加密解密类
    /// </summary>
    public class SymmetricMethod
    {
        public static string Key = "63691801";
        public static string IV = "55637711";
        public static string base64_encode(string AStr)
        {
            return Convert.ToBase64String(ASCIIEncoding.Default.GetBytes(AStr));
        }

        public static string base64_decode(string ABase64)
        {
            return ASCIIEncoding.Default.GetString(Convert.FromBase64String(ABase64));
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>     
        /// <param name="encryptIV">便移向量,要求为8位</param>  
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey, string encryptIV)
        {
            try
            {//这里不做密钥及偏移向量位数检查 By Arthur
                byte[] rgbKey = ASCIIEncoding.ASCII.GetBytes(encryptKey.Substring(0, 8));//密钥
                byte[] rgbIV;

                if (encryptIV == "" || encryptIV == null)
                {
                    rgbIV = rgbKey;
                }
                else
                {
                    rgbIV = ASCIIEncoding.ASCII.GetBytes(encryptIV.Substring(0, 8));//密钥向量 
                }
                byte[] inputByteArray = Encoding.UTF8.GetBytes(base64_encode(encryptString));

                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();

                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                //从DES算法的加密类对象的CreateEncryptor方法,创建一个加密转换接口对象
                //第一个参数的含义是：对称算法的机密密钥(长度为64位,也就是8个字节)
                // 可以人工输入,也可以随机生成方法是：MyServiceProvider.GenerateKey();
                //第二个参数的含义是：对称算法的初始化向量(长度为64位,也就是8个字节)
                // 可以人工输入,也可以随机生成方法是：MyServiceProvider.GenerateIV()
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock(); //返回串格式：F4180E168E48A4995CB5598CC906624AD9FBBE0B5748E8BE                 
                StringBuilder ret = new StringBuilder();
                foreach (byte b in mStream.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <param name="decryptIV">解密偏移向量.要求为8位,和加密偏移向量相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey, string decryptIV)
        {
            try
            {//这里不做密钥及偏移向量位数检查 By Arthur
                byte[] rgbKey = ASCIIEncoding.ASCII.GetBytes(decryptKey.Substring(0, 8));//密钥
                byte[] rgbIV;

                if (decryptIV == "" || decryptIV == null)
                {
                    rgbIV = rgbKey;
                }
                else
                {
                    rgbIV = ASCIIEncoding.ASCII.GetBytes(decryptIV.Substring(0, 8));//密钥向量 
                }

                Byte[] inputByteArray = new byte[decryptString.Length / 2];
                for (int x = 0; x < decryptString.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }//此处与上面加密输出配套，请注意！！！By Arthur

                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return base64_decode(Encoding.UTF8.GetString(mStream.ToArray()));
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
