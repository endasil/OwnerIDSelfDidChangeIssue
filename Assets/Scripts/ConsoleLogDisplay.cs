using Normal.Realtime;

using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class ConsoleLogDisplay : MonoBehaviour
{

    public TMP_Text consoleText;
    public TMP_Text ownerText;
    private List<string> logMessages = new List<string>();
    private const int maxLogMessages = 20;
    RealtimeTransform _realtimeTransform;

    private void Awake()
    {
        _realtimeTransform = GetComponent<RealtimeTransform>();
        Debug.Log("Blah");
        Application.logMessageReceived += HandleLog;
    }
    public void Update()
    {
        
        ownerText.text = _realtimeTransform.ownerIDSelf.ToString();
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        logMessages.Add(logString);
        if (logMessages.Count > maxLogMessages)
        {
            logMessages.RemoveAt(0);
        }

        UpdateConsoleText();
    }

    private void UpdateConsoleText()
    {
        consoleText.text = string.Join("\n", logMessages.ToArray());
    }
}
