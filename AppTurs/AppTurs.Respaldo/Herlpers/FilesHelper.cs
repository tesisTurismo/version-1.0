using System;
using System.Collections.Generic;
using System.Linq;


namespace AppTurs.Respaldo.Herlpers
{
    using System.Web;
    using System.IO;
    public static class FilesHelper
    {
        public static string UploadPhoto(HttpPostedFileBase file, string folder)
        {
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                file.SaveAs(path);
            }

            return pic;
        }
    }
}