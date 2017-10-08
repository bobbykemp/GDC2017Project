using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DebugReportSender.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 07
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 08
 * 
 * To send debug text to UI, add this component to game object, then within any script, grab this script and
 * use handler to send debug lines to handler.
 * 
 */
 [AddComponentMenu("GDC/Scripts/Debug Report Sender.cs")]
public class DebugReportSender : MonoBehaviour
{
    /* Public Variables */
    public bool sendToDebugWindow = false; /* Should be enabled in editor level so they can send debug info to debug gui */

    /* Private Variables */
    private DebugReportHandler handler;

    private void Awake()
    {
        handler = GameObject.Find("debug_text").GetComponent<DebugReportHandler>();
    }

    private void FixedUpdate()
    {
        handler.SendLog("Fixed Update Called");
    }

    private void Update()
    {
        handler.SendLog("Update Called");
    }

    private void LateUpdate()
    {
        handler.SendLog("Late Update Called");
    }
}
