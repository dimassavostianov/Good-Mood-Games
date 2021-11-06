using System;
using System.Globalization;
using System.IO;
using GoodMoodGames.Scripts.Editor.Tools.Domain;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Editor.Tools
{
    internal static class ScreenshotTools
    {
        private const string ScreenshotName = "Screenshot";
        private const char Separator = '_';

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ScreenshotToolsDirectory +
            "Take Screenshot JPEG", false, EditorToolsToolsConstants.ScreenshotToolsPriority)]
        private static void TakeScreenshotJpeg() => CaptureScreenshot(".jpeg");

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ScreenshotToolsDirectory + "Take Screenshot PNG",
            false, EditorToolsToolsConstants.ScreenshotToolsPriority)]
        private static void TakeScreenshotPng() => CaptureScreenshot(".png");

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