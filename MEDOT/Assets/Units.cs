using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Objects;

public class Units : MonoBehaviour
{
    public string Faction;
    public string Nature;
    public string Volume;
    public string Attitude;
    public List<string> equipement; //à redéfinir proprement,
    // avec la portée des armes, le calibre etc...
    public string position;
    public string GDH;
    public string Mission;
    public string comment;

    public GameObject UnitPrefab;
    public string UnitName;

    public void GenerateUnit(string tag){
        //will get the info from the concerned unit field and instantiate the prefab with all the
        // caracteristics informed
        // input : GameObject UNIT : the pattern containing the NVADof the unit to be created
        // string tag : to add the tag to the unit
        // output : void
        //create a new unit with the prefab
        //caution, lot checking to do here !
        //what happens if multiple teams ?
        if(!GameObject.Find(UnitName)){
            GameObject new_unit = Instantiate(UnitPrefab) as GameObject;
            new_unit.name = UnitName;
            new_unit.tag = tag;
            // caution : position will depend on the unit being created on the timeline or the map
            new_unit.GetComponent<Transform>().localPosition = new Vector3 (0f,0f,0f);
        }
    }
    public void GetInfoFromForm(string UnitName){
        //Get the info from the associated form, and put it inside the unit with name name
        //input string UnitName, the name of the unit
        //output : void
        GameObject Unit = GameObject.Find(UnitName);
        GameObject Form = this.transform.parent.gameObject;
        //caution, lot checking to do here !
        //getting the children inputs. Here we'll only do the eni units, but aly can be added later
        Unit.GetComponent<Units>().Nature = Form.transform.GetChild(1).gameObject.GetComponent<TMP_InputField>().text;
        Unit.GetComponent<Units>().Volume = Form.transform.GetChild(2).gameObject.GetComponent<TMP_InputField>().text;
        TMP_Dropdown dropper = Form.transform.GetChild(4).gameObject.GetComponent<TMP_Dropdown>();
        Unit.GetComponent<Units>().Mission = dropper.options[dropper.value].text;
        Unit.GetComponent<Units>().position = Form.transform.GetChild(6).gameObject.GetComponent<TMP_InputField>().text;
        Unit.GetComponent<Units>().GDH = Form.transform.GetChild(7).gameObject.GetComponent<TMP_InputField>().text;
    }

    public void CreateFigure(string UnitName)
    {
        // Create the picture for a given unit (self)
        // Created picture is then attached to the unit object
        // on oth the map and timeline

        //for now we'll only consider having a simple Symbol of unit.Maybe later we will be able to 
        // add more precision (mechanized infantry)
        //input : string UnitName the name of the unit to modify
        //output : void
        
        //the unit has 3 components : symbol, border, and volume.
        GameObject TargetedUnit = GameObject.Find(UnitName);
        //selecting the color according to the faction
        Color UnitColor = Color.red;
        //first we will look if the unit is from the azur force. Later, we may decide to add more
        // factions
        if(TargetedUnit.GetComponent<Units>().Faction == "Azur"){
            UnitColor = Color.blue;
            //factoin also changes the border
            TargetedUnit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Symbols/Border_"+TargetedUnit.GetComponent<Units>().Faction);
        }

        TargetedUnit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = UnitColor;
        TargetedUnit.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = UnitColor;
        TargetedUnit.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = UnitColor;

        //then we change the symbol according to the info.
        TargetedUnit.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Symbols/Symbol_"+TargetedUnit.GetComponent<Units>().Nature);
        TargetedUnit.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Symbols/Volume_"+TargetedUnit.GetComponent<Units>().Volume);
    }
    
}
