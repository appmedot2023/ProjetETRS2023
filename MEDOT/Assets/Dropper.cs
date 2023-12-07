using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dropper : MonoBehaviour
{
    public bool need_to_be_populated;
    public List<string> Missions = new List<string>() {"Reconnaitre","Surveiller"};
    public TMP_Dropdown dropper;
    public GameObject _dropper;
    public List<GameObject> droppers;

    public void populate(List<string> Objects,TMP_Dropdown dropper) {
        dropper.options.Clear();
        foreach(string obj in Objects){
            dropper.options.Add(new TMP_Dropdown.OptionData() {text=obj});
        }
    }

    public GameObject game_image;
    public void UpdateImageInCanvas(){
        //make clear explanation of what will happpen in this function...
        TMP_Dropdown dropper = this.transform.GetComponent<TMP_Dropdown>();
        string mission_name = dropper.options[dropper.value].text;
        game_image.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Pictures/tests/"+mission_name+"_"+game_image.name);
    }
    public void Valuation_to_color(){
        //changes the color of the dropper according to the valuation. Will be green if 
        // the valuation is positve, whit if null, red otherwise.
        // input : void
        // output : void
        GameObject dropper = this.transform.gameObject; //we're going from the srcipt
        // so we have to do this in order to get the dropdown button...
        int valuation = dropper.GetComponent<TMP_Dropdown>().value; // getting th user input
        if(valuation == 0){
            dropper.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        else{
            if(valuation <= 3){ //contains a +
                dropper.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            }
            else{ // contains -
                dropper.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            }
        }
    }

    public void Make_Sum_Of_Previous_Fields(){
        // For now, we'll use an inputField to do the job. Nonetheless, I'll have to make it
        // ausable for other kind of "buttons" 
        // will get the values of the different droppers, and make a sum of these
        // input : List<GameObject> droppers : list of the droppers to sum for the analysis
        // output : void
        int valuation = 0;
        // Don't know if I'll need to do the same with other kind of inputs... Maybe I'll
        // have to adapt the code later
        foreach(GameObject dropper in droppers){
            TMP_Dropdown dropdown = dropper.GetComponent<TMP_Dropdown>();
            string value_in_dropper = dropdown.options[dropdown.value].text;
            switch (value_in_dropper){
                //matching the pattern. Since we only have +, - and 0, an only repetition
                // of one of these characters, we can calculate the value only by checking
                // the presence of + or -
                case string cotation when cotation.Contains("+"):
                    valuation += cotation.Length;
                    break;
                case string cotation when cotation.Contains("-"):
                    valuation -= cotation.Length;
                    break;
                default:
                    break;
            }
        }
        // now we go from the valuation to a string to show on the button
        GameObject current_input = this.transform.gameObject;
        char sign = '0';
        Color new_color = Color.white;
        if (valuation != 0){
            if(valuation > 0)
            {
                sign = '+';
                new_color = Color.green;
            }
            else{
                if (valuation < 0){
                    sign = '-';
                    new_color = Color.red;
                }
            }
            current_input.transform.GetChild(0).GetComponent<TMP_Text>().text = new string(sign, Mathf.Abs(valuation));
            current_input.GetComponent<UnityEngine.UI.Image>().color = new_color;
        }
        else{
            current_input.transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            current_input.GetComponent<UnityEngine.UI.Image>().color = new_color;
        }
    }

    public GameObject Input_field;
    public GameObject Elt_field;
    public GameObject canvas;
    public GameObject Missions_aux_subs;
    public GameObject prefab_mission_elt;
    public void Delete_all_With_Given_Tag(string tag){ //defined two times...
        GameObject[] list_object = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in list_object){
            Destroy(obj);
        }
    }
    public void SetOrganisation(){
        TMP_Dropdown current_dropper = this.transform.gameObject.GetComponent<TMP_Dropdown>();
        //we have only two choices for the organisation dropper...
        //caution : make sure that the value are filtered...
        Destroy(GameObject.Find("number_of_elts"));
        Delete_all_With_Given_Tag("elt");
        Delete_all_With_Given_Tag("mission_elt");
        if(current_dropper.value == 0){
            //will have to interact with the decision part...
            //GameObject Missions_aux_subs = GameObject.Find("Missions_aux_subs_canvas");
            for(int i=1;i<5;i++){
                string current_index = i.ToString();

                // profiting the opportunity to create the missions in the decision part
                GameObject new_mission = Instantiate(prefab_mission_elt);
                new_mission.name = "mission_elt_"+current_index;
                new_mission.transform.SetParent(Missions_aux_subs.transform);
                // adapt the position...
                new_mission.GetComponent<RectTransform>().localPosition = new Vector3 (0f,90f-(i*20f),0f);
            }
        }
        else{
            GameObject number_of_elts = Instantiate(Input_field);
            number_of_elts.transform.SetParent(canvas.transform);
            number_of_elts.name = "number_of_elts";
            number_of_elts.GetComponent<RectTransform>().localPosition = new Vector3 (-50f,90f,0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(need_to_be_populated){
            populate(Missions,dropper);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
