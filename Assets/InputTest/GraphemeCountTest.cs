using System.Collections;
using System.Collections.Generic;
using AdvancedInputFieldPlugin;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphemeCountTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  graphemeCountText;
    [SerializeField] AdvancedInputField inputField;

    public void UpdateTextLength(string str)
    {
        Debug.Log(str.Length);
        graphemeCountText.text = str.Length.ToString();
    }

    public void OnMessageInputEndEdit(string result, EndEditReason reason)
    {
        Debug.Log(inputField.RichText);
        graphemeCountText.text = inputField.RichText.Length.ToString();
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaObject jo = new AndroidJavaObject("jp.vivion.koeto.grapheme.GraphemeCounter"))
        {
            graphemeCountText.text = jo.CallStatic<int>("count", inputField.RichText).ToString();
        }
#endif
    }
}
