using System;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    internal static class ScreenshotTaker
    {
        private const string ScreenshotName = "Screenshot";
        private const char Separator = '_';

        [MenuItem("Tools/Screenshot Taker/Take Screenshot JPEG", false, 5000)]
        public static void TakeScreenshotJPG()
        {
            CaptureScreenshot(".jpeg");
        }
        
        [MenuItem("Tools/Screenshot Taker/Take Screenshot PNG", false, 5000)]
        public static void TakeScreenshotPNG()
        {
            CaptureScreenshot(".png");
        }

        private static void CaptureScreenshot(string extension)
        {
            var screenshotName = string.Join(Separator.ToString(), ScreenshotName,
                DateTime.Now.ToString(CultureInfo.InvariantCulture)).Replace('/', Separator);
            
            var path = Path.Combine(Application.persistentDataPath, screenshotName + extension);
            ScreenCapture.CaptureScreenshot(path);
            
            Debug.Log($"Screenshot saved at: {path}");
        }
    }
}