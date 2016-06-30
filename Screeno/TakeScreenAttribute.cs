using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Screeno
{
    public class TakeScreenAttribute : ActionFilterAttribute
    {
        private static DateTime? lastImageSaveTime = null;
        private string _controllerName;
        private string _actionName;

        public TakeScreenAttribute()
        {
            if(Screeno.Instance == null)
            {
                throw new NullReferenceException("Screeno instance is required. Best to put it on startup.");
            }
        }

        private Bitmap TakeScreenshot()
        {
            ScreenShot image = new ScreenShot();
            return image.CaptureActiveWindow();
        }

        private void SaveScreenshot(Bitmap img)
        {
            string fullPath = Path.Combine(Screeno.Instance.Path, _controllerName, _actionName);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            // Don't take a picture unless its past the buffer. 
            if (!lastImageSaveTime.HasValue || DateTime.Now >= lastImageSaveTime.Value.Add(Screeno.Instance.BufferTime))
            {
                lastImageSaveTime = DateTime.Now;
                img.Save(Path.Combine(fullPath, lastImageSaveTime.Value.ToString("yyyy-MM-dd HH.mm.ss", CultureInfo.InvariantCulture) + ".bmp"));
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            _controllerName = filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString();
            _actionName = filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString();
            SaveScreenshot(TakeScreenshot());
        }
    }
}
