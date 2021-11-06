using GoodMoodGames.Scripts.Editor.Tools.Domain;
using GoodMoodGames.Scripts.Runtime.Core.GoogleServices;
using UnityEditor;

namespace GoodMoodGames.Scripts.Editor.Tools.Configs
{
    internal static class ParseTools
    {
        [MenuItem(
            EditorToolsConstants.ToolsRootDirectory + EditorToolsConstants.ParseToolsDirectory +
            "Parse Configs", false, EditorToolsConstants.ParseToolsPriority)]
        private static void ParseConfigs()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(GoogleSheetDescriptor)}");
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var descriptor = AssetDatabase.LoadAssetAtPath<GoogleSheetDescriptor>(assetPath);
                if (descriptor == null) continue;

                ConfigParser.TryParseConfig(descriptor.ConfigName, descriptor.ConfigSpreadSheetId);
            }
        }
    }
}