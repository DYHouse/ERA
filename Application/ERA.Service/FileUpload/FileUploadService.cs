using ERA.Domain;
using ERA.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERA.Service.FileUpload
{
    public class FileUploadService:IFileUploadService
    {
        public FileInfo Upload(HttpPostedFileBase file, ERAUser user, params string[] paths)
        {
            FileInfo fileInfo = new FileInfo();
            string fileName = string.Empty;
            int length = 0;
            if (file != null)
            {
                var readyPath = new List<string>();
                foreach (string path in paths)
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        readyPath.Add(path);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                }

                string extension = Path.GetExtension(file.FileName);

                FilterExtension(extension, user);

                var name = ERACommonHelper.GetDateFormart(DateTime.Now, HRMDateFomart.yyyymmdd) + "_" + Guid.NewGuid().ToString("N") + extension;
                fileName = name;
                foreach (var path in readyPath)
                {
                    file.SaveAs(Path.Combine(path, name));
                    length = file.ContentLength;
                    fileInfo.Result = true;
                }
            }
            fileInfo.FileName = fileName;
            fileInfo.FileLength = length;
            return fileInfo;
        }

        private void FilterExtension(string extension,ERAUser user)
        {
            if (string.IsNullOrEmpty(extension))
            {
                throw new EvilException(string.Format("用户：{0}上传文件没有扩展名",user.UserId));
            }
            else
            {
                var extensionLow = extension.ToLower();
                if (extensionLow.Contains("exe")
                    || extensionLow.Contains("js")
                    || extensionLow.Contains("vb")
                    || extensionLow.Contains("sql"))
                {
                    throw new EvilException(string.Format("用户：{0}上传文件扩展名非法",user.UserId));
                }
            }
        }
    }
}
