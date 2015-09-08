using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    private static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Resources/AssetBundles",
                                        BuildAssetBundleOptions.UncompressedAssetBundle);
    }
}