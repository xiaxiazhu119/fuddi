using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fuddi.SiteUtils
{
    [Serializable]
    public class ImgResultModel
    {
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Domain { get; set; }
        public string RootPath { get; set; }
        public string ThumbFilePath { get; set; }
        public string OriFilePath { get; set; }

    }
    public enum OperationModeEnum
    {
        HW,
        W,
        H,
        Cut,
        Ori,
        Auto,
        /// <summary>
        /// 以最短一条边为尺寸。
        /// </summary>
        AutoRefMinSize
    }

    public enum UploadErrorEnum
    {
        None = 0,
        TooLarge = 1,
        InvalidExtension = 2
    }

    public class UploadFileHelper
    {
        string _rootPath = "";
        string _extPath = "";
        string _serverRootPath = "";

        public UploadFileHelper(string rootPath)
        {
            this._rootPath = rootPath;
            this._serverRootPath = System.Web.HttpContext.Current.Server.MapPath(_rootPath);
        }

        public UploadFileHelper(string rootPath, string extPath)
        {
            this._rootPath = rootPath;
            this._extPath = extPath;
            this._serverRootPath = System.Web.HttpContext.Current.Server.MapPath(_rootPath + _extPath);
        }


        public List<ImgResultModel> UploadImg(HttpRequestBase request, IList<OperationParameterModel> opParaList)
        {
            return UploadImg(request, opParaList, false);
        }
        public List<ImgResultModel> UploadImg(HttpRequestBase request, IList<OperationParameterModel> opParaList, bool useOriginalFileName)
        {

            List<ImgResultModel> r = new List<ImgResultModel>();
            //SiteUtil.Log("request.Files:" + request.Files.Count.ToString());
            //SiteUtil.Log("request.Headers[\"X-File-Name\"]:" + (string.IsNullOrEmpty(request.Headers["X-File-Name"]) ? "null" : request.Headers["X-File-Name"].ToString()));
            foreach (string file in request.Files)
            {
                var statuses = new List<ImgResultModel>();
                var headers = request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(request, statuses, opParaList, useOriginalFileName);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], request, statuses);
                }
                return statuses;

            }

            return r;
        }


        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ImgResultModel> result)
        {

            //SiteUtil.Log("UploadPartialFile");

            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(_serverRootPath, Path.GetFileName(fileName));

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            result.Add(new ImgResultModel() { FileName = Path.GetFileName(fileName), Type = file.ContentType, Domain = "", RootPath = _rootPath, Size = file.ContentLength });
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private Exception UploadWholeFile(HttpRequestBase request, List<ImgResultModel> result, IList<OperationParameterModel> opParaList, bool userOriginalFileName)
        {
            Exception exn = null;
            for (int i = 0; i < request.Files.Count; i++)
            {

                string ext;
                string originalFile = SaveImg(request.Files[i], out ext, userOriginalFileName);

                //SiteUtil.Log("originalFile:" + originalFile);
                foreach (var m in opParaList)
                {
                    byte[] content = ThumbnailHelper.MakeThumbnail(Path.Combine(_serverRootPath, originalFile), m.Width, m.Height, m.OperationMode);
                    MemoryStream ms = new MemoryStream(content);
                    Bitmap bitMap = new Bitmap(ms);

                    try
                    {
                        string _sfp = System.Web.HttpContext.Current.Server.MapPath(m.RootPath + m.ThumbFilePath);

                        if (!Directory.Exists(_sfp))
                            Directory.CreateDirectory(_sfp);

                        bitMap.Save(_sfp + originalFile);
                    }
                    catch (Exception ex)
                    {
                        int a = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                        exn = ex;
                        throw ex;
                    }
                    finally
                    {
                        bitMap.Dispose();
                        ms.Close();
                    }

                    result.Add(new ImgResultModel() { FileName = originalFile, Type = request.Files[i].ContentType, Domain = "", RootPath = m.RootPath, ThumbFilePath = m.ThumbFilePath, OriFilePath = m.OriFilePath, Size = request.Files[i].ContentLength });
                }

            }

            return exn;
        }

        private string SaveImg(HttpPostedFileBase file, out string extName, bool userOriginalFileName)
        {

            string ext = Path.GetExtension(file.FileName);
            string fn = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random()).Next(1000, 9999);
            if (userOriginalFileName)
                fn = Path.GetFileNameWithoutExtension(file.FileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //string fn2 = fn + "_" + DateTime.Now.ToString("yyyyMMddHHmmssdddd");
            string a = fn + ext;

            //var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));
            string fullPath = _serverRootPath + a;

            if (!Directory.Exists(_serverRootPath))
                Directory.CreateDirectory(_serverRootPath);
            extName = ext;
            file.SaveAs(fullPath);
            return a;
        }

        public static UploadErrorEnum CheckImgFileExt(HttpRequestBase request)
        {
            UploadErrorEnum ue = UploadErrorEnum.None;
            if (request.Files.Count > 0)
            {
                foreach (string fileName in request.Files)
                {
                    HttpPostedFileBase file = request.Files[fileName];
                    string ext = Path.GetExtension(file.FileName).ToLower();

                    bool r = SiteUtil.Instance.VerifyImgFileExt(ext);
                    if (!r)
                    {
                        ue = UploadErrorEnum.InvalidExtension;
                        break;
                    }
                }
            }
            return ue;
        }

        /*
        public static UploadErrorEnum CheckOtherFileExt(HttpRequestBase request)
        {
            UploadErrorEnum ue = UploadErrorEnum.None;
            if (request.Files.Count > 0)
            {
                foreach (string fileName in request.Files)
                {
                    HttpPostedFileBase file = request.Files[fileName];
                    string ext = Path.GetExtension(file.FileName).ToLower();
                    if (SiteUtils.OtherFileExt.IndexOf(ext) > -1)
                    {
                        ue = UploadErrorEnum.InvalidExtension;
                        break;
                    }
                }
            }
            return ue;
        }

        public static UploadErrorEnum CheckFlashFileExt(HttpRequestBase request)
        {
            UploadErrorEnum ue = UploadErrorEnum.None;
            if (request.Files.Count > 0)
            {
                foreach (string fileName in request.Files)
                {
                    HttpPostedFileBase file = request.Files[fileName];
                    string ext = Path.GetExtension(file.FileName).ToLower();
                    if (SiteUtils.FlashFileExt.IndexOf(ext) == -1)
                    {
                        ue = UploadErrorEnum.InvalidExtension;
                        break;
                    }
                }
            }
            return ue;
        }
         * */

        /// <summary>
        /// 判断上传后文件的大小，kb为单位。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UploadErrorEnum CheckFileSize(HttpRequestBase request, int size)
        {
            size = size * 1024;
            for (int i = 0; i < request.Files.Count; i++)
            {
                if (request.Files[i].ContentLength > size)
                {
                    return UploadErrorEnum.TooLarge;
                }
            }
            return UploadErrorEnum.None;
        }

        /*
        public static UploadErrorEnum CheckFile(HttpRequestBase request, ImgTarget it)
        {
            UploadErrorEnum ue_rst = UploadErrorEnum.None;
            foreach (UploadErrorEnum ue in UploadErrorList)
            {
                switch (ue)
                {
                    case UploadErrorEnum.TooLarge:
                        break;
                    case UploadErrorEnum.InvalidExtension:
                        break;
                }
                if (ue_rst != UploadErrorEnum.None)
                    break;
            }
            return ue_rst;
        }

        private static IList<UploadErrorEnum> _uploadErrorList;
        public static IList<UploadErrorEnum> UploadErrorList
        {
            get {
                if (_uploadErrorList == null) {
                    _uploadErrorList = new List<UploadErrorEnum>();
                    _uploadErrorList.Add(UploadErrorEnum.TooLarge);
                    _uploadErrorList.Add(UploadErrorEnum.InvalidExtension);
                }
                return _uploadErrorList;
            }
        }
         * */
    }

    public class OperationParameterModel
    {
        public string RootPath { get; set; }
        public string ThumbFilePath { get; set; }
        public string OriFilePath { get; set; }
        public OperationModeEnum OperationMode { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    /*
    public class FileModel
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

    }
     * */

    public class ThumbnailHelper
    {


        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static byte[] MakeThumbnail(string originalImagePath, int width, int height, OperationModeEnum mode)
        {
            return MakeThumbnail(originalImagePath, width, height, mode, System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic, System.Drawing.Drawing2D.SmoothingMode.HighQuality);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static byte[] MakeThumbnail(string originalImagePath, int width, int height, OperationModeEnum mode, System.Drawing.Drawing2D.InterpolationMode interpolationMode, System.Drawing.Drawing2D.SmoothingMode smoothingMode)
        {
            byte[] imgData;

            #region

            using (Image originalImage = Image.FromFile(originalImagePath))
            {

                int towidth = width;
                int toheight = height;

                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;

                switch (mode)
                {
                    case OperationModeEnum.HW://指定高宽缩放（可能变形）                
                        break;
                    case OperationModeEnum.W://指定宽，高按比例                    
                        toheight = originalImage.Height * width / originalImage.Width;
                        break;
                    case OperationModeEnum.H://指定高，宽按比例
                        towidth = originalImage.Width * height / originalImage.Height;
                        break;
                    case OperationModeEnum.Cut://指定高宽裁减（不变形）                
                        if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                        {
                            oh = originalImage.Height;
                            ow = originalImage.Height * towidth / toheight;
                            y = 0;
                            x = (originalImage.Width - ow) / 2;
                        }
                        else
                        {
                            ow = originalImage.Width;
                            oh = originalImage.Width * height / towidth;
                            x = 0;
                            y = (originalImage.Height - oh) / 2;
                        }
                        break;
                    case OperationModeEnum.Auto:
                        AutoSize(ow, oh, ref towidth, ref toheight);
                        break;
                    case OperationModeEnum.AutoRefMinSize:
                        AutoRefMinSize(ow, oh, ref towidth, ref toheight);
                        break;
                    default:
                        towidth = originalImage.Width;
                        toheight = originalImage.Height;
                        break;
                }

                //新建一个bmp图片
                using (Image bitmap = new System.Drawing.Bitmap(towidth, toheight))
                {

                    //新建一个画板
                    Graphics g = System.Drawing.Graphics.FromImage(bitmap);

                    //设置高质量插值法
                    //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.InterpolationMode = interpolationMode;

                    //设置高质量,低速度呈现平滑程度
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.SmoothingMode = smoothingMode;

                    //清空画布并以透明背景色填充
                    g.Clear(Color.Transparent);

                    //在指定位置并且按指定大小绘制原图片的指定部分
                    g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                        new Rectangle(x, y, ow, oh),
                        GraphicsUnit.Pixel);

                    try
                    {
                        //以jpg格式保存缩略图
                        /*
                        Bitmap a = new Bitmap(bitmap);
                        a.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        a.Dispose();
                         * */

                        Bitmap a = new Bitmap(bitmap);
                        MemoryStream ms = new MemoryStream();
                        a.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        /*
                        Bitmap a2 = new Bitmap(ms);
                        a2.Save(HttpContext.Current.Server.MapPath("/upload/s/a2.jpg"));

                         * */
                        imgData = ms.GetBuffer();
                        //new WebService1().SaveThumnail(imgData);
                        ms.Close();

                        /*
                        using (Stream stream = new MemoryStream())
                        { 
                            //克隆Bitmap对象  
                    Bitmap bmp = new Bitmap(bitmap);
                    bmp.Save(stream, bitmap.RawFormat);
                     bmp.Dispose();  
                        
                         * */
                    }
                    catch (System.Exception e)
                    {
                        throw e;
                        //imgData = null;
                    }
                    finally
                    {
                        g.Dispose();
                        bitmap.Dispose();
                        originalImage.Dispose();
                    }
                    return imgData;
                }
            }
            #endregion}

        }

        private static void AutoSize(int ow, int oh, ref int towidth, ref int toheight)
        {
            if (towidth < ow)
            {
                if (toheight < oh)
                {
                    float finalRate = 0f;
                    float rate1 = (float)toheight / (float)oh;
                    float rate2 = (float)towidth / (float)ow;
                    if (rate1 > rate2)
                    {
                        finalRate = rate2;
                    }
                    else
                        finalRate = rate1;
                    towidth = (int)((float)ow * finalRate);
                    toheight = (int)((float)oh * finalRate);

                }
                else
                {
                    float finalRate = (float)towidth / (float)ow;
                    towidth = (int)((float)ow * finalRate);
                    toheight = (int)((float)oh * finalRate);
                }
            }
            else
            {
                if (toheight < oh)
                {

                    float finalRate = (float)toheight / (float)oh;
                    towidth = (int)((float)ow * finalRate);
                    toheight = (int)((float)oh * finalRate);


                }
                else
                {
                    towidth = ow;
                    toheight = oh;

                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="ow"></param>
        /// <param name="oh"></param>
        /// <param name="towidth"></param>
        /// <param name="toheight"></param>
        private static void AutoRefMinSize(int ow, int oh, ref int towidth, ref int toheight)
        {
            if (ow < towidth && oh < toheight)
            {
                towidth = ow;
                toheight = oh;
            }
            else
            {
                if (ow > oh)
                {
                    towidth = ow * toheight / oh;

                }
                else
                {
                    toheight = oh * towidth / ow;
                }
            }
        }

        private static Size NewSize(int maxWidth, int maxHeight, int Width, int Height)
        {
            double w = 0.0;
            double h = 0.0;
            double sw = Convert.ToDouble(Width);
            double sh = Convert.ToDouble(Height);
            double mw = Convert.ToDouble(maxWidth);
            double mh = Convert.ToDouble(maxHeight);

            if (sw < mw && sh < mh)//如果maxWidth和maxHeight大于源图像，则缩略图的长和高不变  
            {
                w = sw;
                h = sh;
            }
            else if ((sw / sh) > (mw / mh))
            {
                w = maxWidth;
                h = (w * sh) / sw;
            }
            else
            {
                h = maxHeight;
                w = (h * sw) / sh;
            }
            return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
        }
    }
}