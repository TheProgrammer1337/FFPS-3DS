using System.Collections.Generic;
using UnityEngine;

public static class ResourceTracker
{
    private static List<Object> loadedAssets = new List<Object>();

    public static T Load<T>(string path) where T : Object
    {
        T asset = Resources.Load<T>(path);
        if (asset != null && !loadedAssets.Contains(asset))
        {
            loadedAssets.Add(asset);
            Debug.Log("Loaded: " + asset.name); // Replace interpolated string
        }
        return asset;
    }

    public static void LogLoadedAssets()
    {
        Debug.Log("Currently loaded assets:");
        foreach (var asset in loadedAssets)
        {
            Debug.Log(" - " + asset.name); // Replace interpolated string
        }
    }

    public static void CheckUnloadedAssets()
    {
        Debug.Log("Checking for unloaded assets...");
        List<Object> stillLoaded = new List<Object>();
        foreach (var asset in loadedAssets)
        {
            if (asset != null)
            {
                stillLoaded.Add(asset);
            }
            else
            {
                Debug.Log("An asset was unloaded."); // Replace interpolated string
            }
        }
        loadedAssets = stillLoaded;
    }
}
