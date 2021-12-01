using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class ScoreToCSV : MonoBehaviour
{

//Variables
    [SerializeField]
    private Button saveScoreButton;
    
    [SerializeField]
    private TMP_InputField nameTextInput;
    
    [SerializeField]
    private TMP_Dropdown controllerTextInput;

    [SerializeField]
    private TMP_Text timeText;

private void disableDataEntry()
{
    saveScoreButton.transform.parent.gameObject.SetActive(false);
}
public void savePlayerData()
{
    //string header = "Name,Group,Time";
    string data = ToCSV();


#if UNITY_EDITOR
    var folder = Application.streamingAssetsPath;

    if(! Directory.Exists(folder))
    {
        Directory.CreateDirectory(folder);
    }
#else
    var folder = Application.dataPath;
#endif

    var filePath = Path.Combine(folder, "export.csv");

      using(var writer = new StreamWriter(filePath, true))
    {
        writer.Write(data);
    }

    Debug.Log($"CSV file written to \"{filePath}\"");
    disableDataEntry();

}
    private string ToCSV()
{
    var sb = new StringBuilder(nameTextInput.text + ',' + controllerTextInput.captionText.text + ',' + timeText.text + '\n');

    return sb.ToString();
}
 
}