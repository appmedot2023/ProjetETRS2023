using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_manager: MonoBehaviour
{
    public void GetValueFromOtherField(GameObject field)
    {
        this.transform.gameObject.GetComponent<TMP_Text>().text = field.GetComponent<TMP_InputField>().text;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
