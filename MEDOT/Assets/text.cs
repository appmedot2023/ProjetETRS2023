using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class text : MonoBehaviour
{
    public void GetTextFromOtherField(Canvas canvas, int field)
    {
        this.GetComponent<TMP_InputField>().text = canvas.transform.GetChild(field).gameObject.GetComponent<TextMeshPro>().text;
    }
}
