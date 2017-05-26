using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TibiaTools.Application.Helpers.Contracts;
using TibiaTools.Application.Resources.Database;
using TibiaTools.Core.DTO;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Application.Helpers
{
    public class PathHelper : IPathHelper
    {
        public string DefaultImgPath { get; private set; }

        public PathHelper()
        {
            var defaultImg = Images._default;
            DefaultImgPath = Path.Combine(Path.GetTempPath(), "_default.png");

            ImgUpdater(DefaultImgPath, defaultImg);
        }

        public string GetItemImagePath(ItemResultDTO item)
        {
            return GetItemImagePath(item.Item);
        }

        public string GetItemImagePath(Item item)
        {
            try
            {
                var imgName = "_" + item.Id.ToString();
                var imgPath = String.Empty;

                using (var itemImg = Images.ResourceManager.GetObject(imgName) as Bitmap)
                {
                    if (itemImg == null) return DefaultImgPath;

                    imgPath = Path.Combine(Path.GetTempPath(), imgName + ".gif");
                    ImgUpdater(imgPath, itemImg);
                }

                return imgPath;
            }
            catch
            {
                return DefaultImgPath;
            }
        }

        private static void ImgUpdater(string imgPath, Bitmap img)
        {
            if (File.Exists(imgPath))
            {
                var existImg = new Bitmap(imgPath);

                if (!CompareMemCmp(img, existImg))
                {
                    File.Delete(imgPath);
                    img.Save(imgPath);
                }
            }
            else
            {
                img.Save(imgPath);
            }
        }

        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        public static bool CompareMemCmp(Bitmap b1, Bitmap b2)
        {
            if ((b1 == null) != (b2 == null)) return false;
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bd1scan0 = bd1.Scan0;
                IntPtr bd2scan0 = bd2.Scan0;

                int stride = bd1.Stride;
                int len = stride * b1.Height;

                return memcmp(bd1scan0, bd2scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }
    }
}
