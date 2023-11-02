using UnityEditor;

class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles/Android")]
    static void BuildAndroidAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}