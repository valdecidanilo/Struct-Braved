using System;
using UnityEditor;
using UnityEngine;
namespace Braved.Editor
{
    public static class CreateAssetBundles
    {
        [MenuItem("Braved/AssetBundles/Build")]
        private static void BuildAllAssetBundles()
        {
            var path = Application.dataPath + "/AssetBundles";
            try
            {
                BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                throw;
            }
        }
    }
}