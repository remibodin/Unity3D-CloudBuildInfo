# Unity3D-CloudBuildInfo

For [Unity cloud build](https://build.cloud.unity3d.com/) users

> CloudBuildInfo include [MiniJSON](https://gist.github.com/darktable/1411710).

## Build manifest

It’s often useful for your game’s run-time code to know key information about the build itself. Information like the name and number of the build is very useful when reporting bugs or tracking analytics. To help facilitate this, Unity Cloud Build injects a “manifest” into your game at build time, so that this key data can be accessed later at runtime.

The Unity Cloud Build manifest is provided as a JSON formatted TextAsset. This is stored as a game resource.

You can find all informations in [Build manifest documentation](https://docs.unity3d.com/Manual/UnityCloudBuildManifest.html)

## CloudBuildInfo

The class **CloudBuildInfo** provide static properties for all build manifest key, like *CloudBuildInfo.BuildNumber* or *CloudBuildInfo.CloudBuildTargetName*

### Example

    // Display branch name and commit id in log file
    Debug.Log("Branch: " + CloudBuildInfo.ScmBranch);
    Debug.Log("Commit: " + CloudBuildInfo.ScmCommitId);
