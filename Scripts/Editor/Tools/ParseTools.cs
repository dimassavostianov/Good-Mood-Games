using GoodMoodGames.Scripts.Editor.Tools.Domain;
using GoodMoodGames.Scripts.Runtime.Core.Configs;
using GoodMoodGames.Scripts.Runtime.Core.GoogleServices;
using UnityEditor;

namespace GoodMoodGames.Scripts.Editor.Tools
{
    internal static class ParseTools
    {
        [MenuItem(
            EditorToolsToolsConstants.ToolsRootDirectory + EditorToolsToolsConstants.ParseToolsDirectory +
            "Parse Configs", false, EditorToolsToolsConstants.ParseToolsPriority)]
        private static void ParseConfigs()
        {
            var guids = AssetDatabase.FindAssets($"t:{typeof(GoogleSheetDescriptor)}");
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var descriptor = AssetDatabase.LoadAssetAtPath<GoogleSheetDescriptor>(assetPath);
                if (descriptor == null) continue;

                ConfigParserUtils.TryParseConfig(descriptor.ConfigName, descriptor.ConfigSpreadSheetId);
            }
        }
    }
}