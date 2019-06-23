using System;
using System.Security.Cryptography;
using System.Text;

namespace Webi.Wechat.SDK.Components
{
    public class MA_AesEncrypted
    {
        public static string AES_decrypt(string data, string key, string iv)
        {
            try
            {
                var datas = Convert.FromBase64String(data);
                var keys = Convert.FromBase64String(key);
                var ivs = Convert.FromBase64String(iv);
                RijndaelManaged aes = new RijndaelManaged();
                //-----------------
                //设置 cipher 格式 AES-128-CBC
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;
                aes.Key = keys;
                aes.IV = ivs;
                //解密
                ICryptoTransform decryptor = aes.CreateDecryptor();
                var result = decryptor.TransformFinalBlock(datas, 0, datas.Length);
                return Encoding.Default.GetString(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}