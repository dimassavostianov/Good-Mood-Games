using System;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class ScriptableObjectAssetCreator
    {
        [MenuItem("Assets/Create/Scriptable Object Asset %#a", true)]
        public static bool CreateObjectAsAssetValidate()
        {
            var activeObject = Selection.activeObject;
            if (activeObject == null || !(activeObject is TextAsset)) return false;

            var assetPath = AssetDatabase.GetAssetPath(activeObject);
            if (assetPath == null) return false;

            var monoScript = (MonoScript) AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
            if (monoScript == null) return false;

            var scriptType = monoScript.GetClass();
            return scriptType != null && scriptType.IsSubclassOf(typeof(ScriptableObject));
        }

        [MenuItem("Assets/Create/Scriptable Object Asset %#a", false)]
        public static void CreateObjectAsAsset()
        {
            var activeObject = Selection.activeObject;
            var assetPath = AssetDatabase.GetAssetPath(activeObject);
            var scriptType = ((MonoScript) AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript))).GetClass();

            var path = EditorUtility.SaveFilePanelInProject("Save Scriptable Object Asset", scriptType.Name + ".asset",
                "asset", "Enter file name");

            if (path.Length == 0) return;
            try
            {
                var instance = ScriptableObject.CreateInstance(scriptType);
                AssetDatabase.CreateAsset(instance, path);
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = instance;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}