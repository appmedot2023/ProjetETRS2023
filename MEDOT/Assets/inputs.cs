using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inputs : MonoBehaviour
{
    public Canvas canvas;
    public List<string> list_to_write;
    public GameObject current_field;
    public bool is_loading;
    public string field_to_get_from;
    public GameObject prefab_to_write_in;
    public int the_kid;
    // Start is called before the first frame update
    public void Write_in_other_fields()
    {
        string text_to_write = this.GetComponent<TMP_InputField>().text;
        foreach (string field in list_to_write)
        {
            GameObject.Find(field).GetComponent<TMP_InputField>().text = text_to_write;
        }
    }

    public void Write_in_other_field_of_prefab(){
        string text_to_write = this.GetComponent<TMP_InputField>().text;
        foreach(string field in list_to_write){
            prefab_to_write_in.transform.GetChild(the_kid).gameObject.GetComponent<TMP_InputField>().text = text_to_write;
        }
    }

    public void Write_From_Other_Fields(string field_to_get_from)
    {
        //will get the input from the field we want to copy, and put it in itsown value
        //input : string field_to_get_from the name of the field we want to copy
        // output : void 
        GameObject input_field = this.transform.gameObject;
        //caution : what happens if it is to get the value from a field other than inputfield?
        input_field.GetComponent<TMP_InputField>().text = GameObject.Find(field_to_get_from).GetComponent<TMP_InputField>().text;
    }


    public GameObject prefab_elts;
    public GameObject prefab_mission_elt;
    public void Delete_all_With_Given_Tag(string tag){
        GameObject[] list_object = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in list_object){
            Destroy(obj);
        }
    }
    public void Create_Elts(){
        //generates the correct number of elts
        //caution : make a max elts possible to create...
        int iterations = int.Parse(this.GetComponent<TMP_InputField>().text);
        GameObject Articulation_canvas = GameObject.Find("Articulation_canvas");
        GameObject Missions_aux_subs = GameObject.Find("Missions_aux_subs_canvas");
        for(int i=1;i<iterations+1;i++){
            string current_index = i.ToString();
            GameObject new_elt = Instantiate(prefab_elts);
            new_elt.transform.SetParent(Articulation_canvas.transform);
            new_elt.name = "elt_"+current_index.ToString();
            new_elt.GetComponent<RectTransform>().localPosition = new Vector3 (90f,90f-((i-1)*100f),0f);
            //will we have to use this fields later ?

            // profiting the opportunity to create the missions in the decision part
            GameObject new_mission = Instantiate(prefab_mission_elt);
            new_mission.name = "mission_elt_"+current_index;
            new_mission.transform.SetParent(Missions_aux_subs.transform);
            // adapt the position...
            new_mission.GetComponent<RectTransform>().localPosition = new Vector3 (0f,90f-i*30f,0f);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Write_in_other_fields(list_to_write);
        //if(is_loading){
        //    Write_From_Other_Fields(field_to_get_from);
        //}
    }
}
