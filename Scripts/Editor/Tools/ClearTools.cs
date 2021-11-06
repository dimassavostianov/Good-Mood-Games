using System.IO;
using GoodMoodGames.Scripts.Editor.Tools.Domain;
using GoodMoodGames.Scripts.Runtime.Core.Storage;
using UnityEditor;
using UnityEngine;

namespace GoodMoodGames.Scripts.Editor.Tools
{
    internal static class ClearTools
    {
        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ClearToolsDirectory + "Clear Data",
            false, EditorToolsToolsConstants.ClearToolsPriority)]
        private static void ClearData()
        {
            ClearScriptableSaveData();
            ClearPersistentData();
            ClearPlayerPrefs();
            ClearCache();
        }

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ClearToolsDirectory +
            "Clear Scriptable Save Data", false, EditorToolsToolsConstants.ClearToolsPriority + 100)]
        private static void ClearScriptableSaveData()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(ScriptableSave)}");
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var scriptableSave = AssetDatabase.LoadAssetAtPath<ScriptableSave>(assetPath);
                if (scriptableSave == null) continue;

                scriptableSave.ResetData();
                Debug.Log($"{scriptableSave.name} cleared");
            }

            Debug.Log("ScriptableSave data Cleared");
        }

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ClearToolsDirectory +
            "Clear Persistent Data", false, EditorToolsToolsConstants.ClearToolsPriority + 100)]
        private static void ClearPersistentData()
        {
            if (!Directory.Exists(Application.persistentDataPath)) return;
            foreach (var file in Directory.GetFiles(Application.persistentDataPath)) File.Delete(file);
            Debug.Log("Persistent data cleared");
        }

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ClearToolsDirectory +
            "Clear Player Prefs", false, EditorToolsToolsConstants.ClearToolsPriority + 100)]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Player Prefs cleared");
        }

        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ClearToolsDirectory +
            "Clear Cache", false, EditorToolsToolsConstants.ClearToolsPriority + 100)]
        private static void ClearCache()
        {
            AssetBundle.UnloadAllAssetBundles(true);
            Debug.Log($"Cache cleared: {Caching.ClearCache()}");
        }
    }
}