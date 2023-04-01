using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepLinkHandler : MonoBehaviour
{
    void Start()
    {
        Application.deepLinkActivated += OnDeepLinkActivated;
    }

    
    [ContextMenu("Test deep link basic query")]
    public void TestQuery()
    {
        string link = "https://colorfulcoding.com/app?query=test";
        OnDeepLinkActivated(link);
    }

    private void OnDeepLinkActivated(string link)
    {
        var param = GetParam(link);
        Debug.Log("Deep link activated: " + link + " param: " + param);
    }

    private string GetParam(string link)
    {
        var uri = new Uri(link);
        var query = uri.Query;
        var param = query.Split('=')[1];
        return param;
    }
}
