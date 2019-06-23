using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Amw.Core.SDK.Components
{
    /// <summary>
    /// 加密帮助器
    /// </summary>
    public class EncryptHelper
    {
        internal EncryptHelper()
        {
        }

        #region md5

        /// <summary>
        /// MD5,默认32(通用)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Md5(string input)
        {
            return Md5(input, 32);
        }

        /// <summary>
        /// MD5(与Java通用)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length">16|32</param>
        /// <returns></returns>
        public string Md5(string input, int length)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            if (length == 16)
            {
                return sBuilder.ToString().Substring(8, 16);
            }
            if (length == 32)
            {
                return sBuilder.ToString().ToLower();
            }
            return sBuilder.ToString();
        }

        #endregion md5

        /// <summary>
        /// 使用缺省密钥给字符串加密（支持微信）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Sha1(string input)
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var sha1 = SHA1.Create();
            buffer = sha1.ComputeHash(buffer);

            var builder = new StringBuilder();
            foreach (byte iByte in buffer)
            {
                builder.AppendFormat("{0:x2}", iByte);
            }
            return builder.ToString();
        }
        public string Sha256(string input)
        {
            var buffer = Encoding.UTF8.GetBytes(input);
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(buffer);

            var builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            return builder.ToString();
        }
        #region des加密

        /// <summary>
        /// 获取密钥(Key,IV)
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> GetDesKey()
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            var item1 = Convert.ToBase64String(provider.Key);
            var item2 = Convert.ToBase64String(provider.IV);
            return new Tuple<string, string>(item1, item2); ;
        }

        /// <summary>
        /// Des加密方法
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        public string DesEncrypt(string value, string key, string IV)
        {
            string result = value;
            try
            {
                byte[] rgbKey = Convert.FromBase64String(key);
                byte[] rgbIV = Convert.FromBase64String(IV);

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = CipherMode.ECB;
                ICryptoTransform transform = provider.CreateEncryptor(rgbKey, rgbIV);
                byte[] inputByteArray = Encoding.Default.GetBytes(value);

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                cStream.Close();
                result = Convert.ToBase64String(mStream.ToArray());
            }
            catch (Exception ex)
            {
                result = ex.Message;
                //ApplicationContext.Log.Error("DesEncrypt", value + "_" + key + "_" + IV + "_" + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Des解密方法
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        public string DesDecrypt(string value, string key, string IV)
        {
            string result = value;
            try
            {
                byte[] rgbKey = Convert.FromBase64String(key);
                byte[] rgbIV = Convert.FromBase64String(IV);

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Mode = CipherMode.ECB;
                ICryptoTransform transform = provider.CreateDecryptor(rgbKey, rgbIV);
                byte[] inputByteArray = Convert.FromBase64String(value);

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                cStream.Close();
                result = Encoding.Default.GetString(mStream.ToArray());
            }
            catch (Exception)
            {
                //ApplicationContext.Log.Error("DesDecrypt", value + "_" + key + "_" + IV + "_" + ex.Message + "_" + ex.StackTrace);
            }
            return result;
        }

        #endregion des加密

        #region hex加密

        /// <summary>
        /// string TO  hex
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string HexEncrypt(string s)
        {
            string result = string.Empty;
            byte[] arrByte = Encoding.UTF8.GetBytes(s);
            for (int i = 0; i < arrByte.Length; i++)
            {
                result += Convert.ToString(arrByte[i], 16);
                //Convert.ToString(byte, 16)把byte转化成十六进制string
            }
            return result;
        }

        /// <summary>
        /// hex  TO  string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string HexDecrypt(string s)
        {
            string result = string.Empty;
            byte[] arrByte = new byte[s.Length / 2];
            int index = 0;
            for (int i = 0; i < s.Length; i += 2)
            {
                arrByte[index++] = Convert.ToByte(s.Substring(i, 2), 16);
                //Convert.ToByte(string,16)把十六进制string转化成byte
            }
            result = Encoding.UTF8.GetString(arrByte);
            return result;
        }

        #endregion hex加密
    }
}