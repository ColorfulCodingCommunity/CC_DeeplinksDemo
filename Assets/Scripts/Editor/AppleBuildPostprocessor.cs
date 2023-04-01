using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_IPHONE
using UnityEditor.iOS.Xcode;
#endif

//Used to add associated domains capability to the Xcode project
//Can also be added manually in XCODE
public class AppleBuildPostprocessor : MonoBehaviour
{
    [PostProcessBuild(1)]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        if (target != BuildTarget.iOS)
        {
            return;
        }

#if UNITY_IPHONE

        //Get the Xcode project
        var projectPath = PBXProject.GetPBXProjectPath(path);
        var project = new PBXProject();
        project.ReadFromString(File.ReadAllText(projectPath));

        var manager = new ProjectCapabilityManager(
            projectPath,
            "Entitlements.entitlements",
            null,
            project.GetUnityMainTargetGuid()
        );
        manager.AddAssociatedDomains(new string[] { "applinks:colorfulcoding.com" });
        manager.WriteToFile();

#endif
    }
}
