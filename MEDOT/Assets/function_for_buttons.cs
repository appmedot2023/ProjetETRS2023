using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class function_for_buttons : MonoBehaviour
{
    public string string_name;
    public void DisableCanvas(Canvas canvas)
    {
        if (canvas.GetComponent<Canvas>().enabled == true)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
        else{
            canvas.GetComponent<Canvas>().enabled = true;
        }

    }

    public void GetTextFromOtherField(Canvas canvas, int FieldPositionAsChild, GameObject FieldToFill)
    {
        //get the text from the given input field
        FieldToFill.GetComponent<TextMeshPro>().text = canvas.transform.GetChild(FieldPositionAsChild).gameObject.GetComponent<TextMeshPro>().text;
    }
}
