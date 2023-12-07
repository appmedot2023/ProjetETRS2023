using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{


//===================================================================================================
//=========================================== Changing canvas =======================================
//===================================================================================================

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

    public void ChangeCanvas(Canvas canvas_to_open){
        // will change the canvas by opening the new canvas and closing the current one
        //father of the button
        //input : Canvas canvas_to_open the canvas we want to get on screen
        // output : void
        canvas_to_open.enabled = true;
        Canvas current_canvas = this.transform.GetComponentInParent<Canvas>();
        current_canvas.enabled = false;
    }

    public void ActivateAllUnitsOnMap(){
        List<GameObject[]> ListExistingUnits = new List<GameObject[]> {GameObject.FindGameObjectsWithTag("eni_cdu"),GameObject.FindGameObjectsWithTag("eni_cds"),GameObject.FindGameObjectsWithTag("ami")};
        foreach(GameObject[] Units in ListExistingUnits){
            foreach(GameObject unit in Units){
                if(unit.activeSelf == true){
                    unit.SetActive(false);
                }
                else{
                    unit.SetActive(true);
                }
            }
        }
    }
}
