using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PropProperties.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 08
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 08
 * 
 * To send debug text to UI, add this component to game object, then within any script, grab this script and
 * use handler to send debug lines to handler.
 * 
 */
[AddComponentMenu("GDC/Scripts/Prop Properties.cs")]
public class PropProperties : MonoBehaviour
{
    /* Public variables (Subject to change often based on game functions */
    public bool isDestructible = false; /* Is this prop can be called via Destroy()? */

    /* Private variables */
    private DebugReportSender debug;
    private float maxRefreshRate = 1.0f;
    private float counter = 0.0f;

    private void Awake()
    {
        this.gameObject.AddComponent<DebugReportSender>(); /* Add debug report sender to parent object */
        debug = this.gameObject.GetComponent<DebugReportSender>();

        /* Any children in this parent prop will have debug report sender as well. */
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.AddComponent<DebugReportSender>();
    }

    private void Update()
    {
        /* Simple test by counting one second and send log to debug UI.
         */
        if (counter > maxRefreshRate)
        {
            counter = 0;

            debug.SendLog("Demo 1 second counter from " + this.gameObject.name);
        }
        else counter += Time.deltaTime;
    }
}
