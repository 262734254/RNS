using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Services.Qiniu
{
    public class QiniuService : IQiniuService
    {
        //public string AccessKey = "sdAZknlRSbcQ51O4l6yuCtxFrdwiEyU-lOSXLAGr";//"jI0oatrQDjvNGJaX5pKSq80cu_KUjbrdmt-LiMcT"; 
        //public string SecretKey = "oBe2wr5GFqtObrbczkrQ09iQxu8tzh98NdF3oNqz"; // "o3KgtKJ-Pm6Ip27KRV0Mjb95PPE6Upx9To2C54Rw";
        //public string Bucket = "jnkj";//存储空间名
        //public string Domain = "http://qiniu.junengkeji.net/";
        public string AccessKey = ConfigurationManager.AppSettings["QiniuAccessKey"];
        public string SecretKey = ConfigurationManager.AppSettings["QiniuSecretKey"];
        public string Bucket = ConfigurationManager.AppSettings["QiniuBucket"];
        public string Domain = ConfigurationManager.AppSettings["QiniuDomain"];

        /// <summary>
        /// 下载文件_私有空间
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string DownLoadPrivateUrl(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                Mac mac = new Mac(AccessKey, SecretKey);
                string privateUrl = DownloadManager.CreatePrivateUrl(mac, Domain, fileName);

                return privateUrl;
            }
            return "";
        }
    }
}
