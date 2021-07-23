using System;
using System.IO;

namespace GoodMoodGames.Scripts.IO
{
    public static class FileUtilities
    {
        public static string GetFileDirectory(string filePath)
        {
            var lastSlashIndex = filePath.LastIndexOf('/');
            return filePath.Substring(0, lastSlashIndex);
        }

        public static string GetFileName(string filePath, bool includeExtension = true)
        {
            var lastSlashIndex = Math.Max(filePath.LastIndexOf('/'), filePath.LastIndexOf('\\'));
            var fileName = filePath.Substring(lastSlashIndex + 1, filePath.Length - lastSlashIndex - 1);

            return includeExtension ? fileName : fileName.Substring(0, fileName.LastIndexOf('.'));
        }

        public static void WriteBytesToFile(byte[] bytes, string localFilePath)
        {
            var directory = localFilePath.Substring(0, localFilePath.LastIndexOf('/'));
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists(localFilePath))
                File.Delete(localFilePath);

            File.WriteAllBytes(localFilePath, bytes);
        }
    }
}