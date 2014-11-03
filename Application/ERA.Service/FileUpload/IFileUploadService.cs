using ERA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ERA.Service.FileUpload
{
    public interface IFileUploadService
    {
        FileInfo Upload(HttpPostedFileBase file, ERAUser user, params string[] paths);
    }
}
