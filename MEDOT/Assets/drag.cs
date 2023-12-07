using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class drag : MonoBehaviour
{
    public GameObject selected_object_to_move;
    Collider2D object_to_move;
    Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)){
            Collider2D object_to_move = Physics2D.OverlapPoint(MousePosition);
            if(object_to_move){
                selected_object_to_move = object_to_move.transform.gameObject;
                //offset = selected_object_to_move.transform.position - MousePosition;
                //selected_object_to_move.GetComponent<Transform>().localPosition = new Vector3 (MousePosition[0],MousePosition[1],0f);
            }
        }
        if(selected_object_to_move){
            //object_to_move.transform.position = MousePosition + offset;
            selected_object_to_move.GetComponent<Transform>().localPosition = new Vector3 (MousePosition[0],MousePosition[1],0f); 
        }
        if(Input.GetMouseButtonUp(0) && selected_object_to_move){
            selected_object_to_move = null;
        }
        
    }
}
