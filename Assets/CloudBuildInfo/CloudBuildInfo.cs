using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class CloudBuildInfo 
{
    #region Singleton
    private static CloudBuildInfo _instance = null;

    public static CloudBuildInfo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CloudBuildInfo();
            }
            return _instance;
        }
    }
    #endregion

    private Dictionary<string,object> _manifestData;

    private CloudBuildInfo()
    {
#if UNITY_CLOUD_BUILD        
        var manifest = (TextAsset) Resources.Load("UnityCloudBuildManifest.json");
        Debug.Log(manifest.text);
        if (manifest != null)
        {
            _manifestData = Json.Deserialize(manifest.text) as Dictionary<string,object>;
        }
#endif        
    }

    private string GetKey(string key, string defaultValue)
    {
        if (Instance._manifestData == null)
        {
            return defaultValue;
        }
        if (Instance._manifestData.ContainsKey(key) == false)
        {
            return defaultValue;
        }
        object data = Instance._manifestData[key];
        if (data == null)
        {
            return defaultValue;
        }
        return data as string;
    }

    /// <summary>
    /// The commit or changelist that was built.
    /// </summary>
    public static string ScmCommitId
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("scmCommitId", "no manifest");
#else
            return "<ScmCommitId>";
#endif
        }
    }

    /// <summary>
    /// The name of the branch that was built.
    /// </summary>
    public static string ScmBranch
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("scmBranch", "no manifest");
#else
            return "<ScmBranch>";
#endif
        }
    }

    /// <summary>
    /// The Unity Cloud Build “build number” corresponding to this build.
    /// </summary>
    public static string BuildNumber
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("buildNumber", "no manifest");
#else
            return "<BuildNumber>";
#endif
        }
    }

    /// <summary>
    /// The UTC timestamp when the build process was started.
    /// </summary>
    public static string BuildStartTime
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("buildStartTime", "no manifest");
#else
            return "<BuildStartTime>";
#endif
        }
    }

    /// <summary>
    /// The Unity project identifier.
    /// </summary>
    public static string ProjectId
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("projectId", "no manifest");
#else
            return "<ProjectId>";
#endif
        }
    }

    /// <summary>
    /// The bundleIdentifier configured in Unity Cloud Build (iOS and Android only).
    /// </summary>
    public static string BundleId
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("bundleId", "no manifest");
#else
            return "<BundleId>";
#endif
        }
    }

    /// <summary>
    /// The version of Unity that Unity Cloud Build used to create the build.
    /// </summary>
    public static string UnityVersion
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("unityVersion", "no manifest");
#else
            return "<UnityVersion>";
#endif
        }
    }

    /// <summary>
    /// The version of XCode used to build the project (iOS only).
    /// </summary>
    public static string XcodeVersion
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("xcodeVersion", "no manifest");
#else
            return "<XcodeVersion>";
#endif
        }
    }

    /// <summary>
    /// The name of the build target that was built.
    /// </summary>
    public static string CloudBuildTargetName
    {
        get
        {
#if UNITY_CLOUD_BUILD
            return Instance.GetKey("cloudBuildTargetName", "no manifest");
#else
            return "<CloudBuildTargetName>";
#endif
        }
    }

    
}
