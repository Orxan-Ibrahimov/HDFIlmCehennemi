using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.Utilities.Helpers
{
    public static class Methods
    {
         public static string RenderImage(IFormFile photo, string name, string directory, string environment)
        {
            string ext = Path.GetExtension(photo.FileName);
            string filename = name.ToLower() + ext;
            string path = Path.Combine(environment, "assets", "img", directory);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, filename);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }
            return filename;
        }

        public static void DeleteImage(string directory, string environment, string oldFilename)
        {
            oldFilename = Path.Combine(environment, "assets", "img", directory, oldFilename);
            FileInfo oldFile = new FileInfo(oldFilename);
            if (File.Exists(oldFilename)) oldFile.Delete();
        }
        public static string RenderImage(IFormFile photo, string name, string directory, string environment, string oldFilename)
        {
            oldFilename = Path.Combine(environment, "assets", "img", directory, oldFilename);
            FileInfo oldFile = new FileInfo(oldFilename);
            if (File.Exists(oldFilename)) oldFile.Delete();
            return RenderImage(photo, name, directory, environment);
        }
    }
}
