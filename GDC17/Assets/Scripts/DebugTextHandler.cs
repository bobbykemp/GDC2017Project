using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * DebugTextHandler.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 07
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 08
 * 
 */
[AddComponentMenu("GDC/Scripts/Debug Text Handler.cs")]
public class DebugTextHandler : MonoBehaviour
{
    /* Public variables */
    public bool displayToScreen = false; /* Use to turn on/off debug text at gui level */

    /* Private */
    private Text debugWindow;

    private void Awake()
    {
        debugWindow = this.gameObject.GetComponent<Text>();
        debugWindow.text = ""; /* Clear text field */
    }

    /* SendLog(string line)
     * Sends debug line with log tag
     */
    public void SendLog(string line)
    {
        Send("Log: " + line);
    }

    /* SendWarning(string line)
     * Sends debug line with warning tag
     */
    public void SendWarning(string line)
    {
        Send("Warning: " + line);
    }

    /* SendError(string line)
     * Sends debug line with error tag
     */
    public void SendError(string line)
    {
        Send("Error: " + line);
    }

    /* Send(string line, bool append = false)
     * Sends a single string line to debug window. If append flag is set to false, a newline flag is sent.
     * If append flag is set to true, debug text will be sent without feeding new line.
     */
    public void Send(string line, bool append = false)
    {
        if (!append)
            AppendText(line + "\n");
        else AppendText(line);
    }

    private void AppendText(string line)
    {
        if(displayToScreen)
            debugWindow.text += line;
    }
}
