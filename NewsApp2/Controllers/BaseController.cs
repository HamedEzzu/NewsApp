using Microsoft.AspNetCore.Mvc;

namespace NewsApp2.Controllers
{
    public class BaseController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public BaseController(IWebHostEnvironment host)
        {
            _host = host;
        }

        public string? UploadFile(string folder, IFormFile? img, string? imageUrl, string? isImg)
        {
            if (isImg == null) // في حال تم حذف الصورة فقط
            {
                DeleteOldFile(imageUrl);
                return null;
            }

            if (img != null)// في حال تم تحميل صورة جديدة
            {
                DeleteOldFile(imageUrl);

                string pictures = Path.Combine(_host.WebRootPath, "pictures");
                string fileName = Guid.NewGuid() + "_" + img.FileName;
                string NewPath = Path.Combine(pictures, folder, fileName);
                if (!System.IO.File.Exists(NewPath))
                    img.CopyTo(new FileStream(NewPath, FileMode.CreateNew));

                return fileName;
            }
            return imageUrl; // في حال لم يتم تحميل صورة جديدة تبقى الصورة القديمة كما هي
        }
        public void DeleteOldFile(string? imageUrl)
        {
            if (imageUrl != null)
            {
                string picturesPath = Path.Combine(_host.WebRootPath, "pictures");
                string oldPath = Path.Combine(picturesPath, imageUrl);
                if (System.IO.File.Exists(oldPath))
                {
                    GC.Collect(); GC.WaitForPendingFinalizers(); // من اجل مشكلة الملف قيد الإستخدام
                    System.IO.File.Delete(oldPath);
                }
            }
        }
        public string ReadHtmlTemplate(string htmlTemplate)
        {
            var filePath = _host.WebRootPath
                            + Path.DirectorySeparatorChar + "templates"
                            + Path.DirectorySeparatorChar + htmlTemplate;

            StreamReader htmlFile = new StreamReader(filePath);
            string content = htmlFile.ReadToEnd();
            htmlFile.Close();
            return content;
        }

        //public bool CheckImgExtension(IFormFile? img)
        //{
        //    if (img != null)
        //    {
        //        string fileExtension = Path.GetExtension(img.FileName.ToLower());
        //        string[] validExtensions = { ".jpeg", ".jpg", ".bmp", ".gif", ".png", ".tiff", ".ico" };
        //        if (validExtensions.Contains(fileExtension))
        //            return true;
        //        else
        //            return false;
        //    }
        //    return true; /// في حال لا يوجد ملف
        //}
    }
}
