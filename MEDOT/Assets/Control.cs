using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class Control : MonoBehaviour
{
//===================================================================================================
//==========================================RegexGeneration==========================================
//===================================================================================================

    public Regex GenerateRegexFromDatabase(List<string> Syntax){
        //will generate a regex from the fom of the sentence it's given
        //input : List<string> Syntax the form for the sentence
        //output : Regex newregexp the automatically produced regexp
        string sentence = "";
        Regex newregexp = new Regex(sentence);
        return newregexp;
    }
//===================================================================================================
//========================================== RegexControl ===========================================
//===================================================================================================

//havin these in different files might reduce the weight of importation ?

    public Regex Coordinates_regexp = new Regex("^[0-9]{4}-[0-9]{4}$"); // reduced coordinates...
    public Regex reduced_GDH_regexp = new Regex("^([0-1][0-9]|[2][0-3]):[0-5][0-9]$"); // reduced GDH, as required by the customer...
    public Regex EM_regexp = new Regex(@"^(Reconnaitre|Surveiller|Detruire)\s([1-9]\s(Equipe|Groupe|Section|Compagnie)\sENI\s)?[0-9]{4}-[0-9]{4}\s([0-1][0-9]|[2][0-3]):[0-5][0-9]$"); //¡ forma del efecto mayor !
    public Regex Missions_regexp = new Regex("^(Reconnaitre|Surveiller|Detruire)$");
    public Regex Volume_regexp = new Regex("^(Equipe|Groupe|Section|Compagnie)$");
    public string regexp_for_the_field;

    public void SelfControl(){
        GameObject InputField = this.transform.gameObject;
        Regex regexp = new Regex("");
        switch(regexp_for_the_field){
            case "Coordinates_regexp":
                regexp = Coordinates_regexp;
                break;
            case "reduced_GDH_regexp":
                regexp = reduced_GDH_regexp;
                break;
            case "EM_regexp":
                regexp = EM_regexp;
                break;
            case "Volume_regexp":
                regexp = Volume_regexp;
                break;
            default:
                break;
        }
        if(!regexp.IsMatch(InputField.GetComponent<TMP_InputField>().text)){
            InputField.GetComponent<TMP_InputField>().text = "";
        }
    }
    public bool ControlIfCorrectlyFilled(GameObject FieldToCheck ,string regexp, string FieldType){
        //Will check if the given field is correctly field, using the given regex
        // input : GameObject FieldToCheck : the field we want to check
        // Regex regexp : the regular expression used to do the check
        // string FieldType : the type of the field we'll deal with
        // ouptut : bool
        // caution : What's the type of the field to check ?
        string InputToCheck = "";
        // get the value according to the type of field under scope
        switch(FieldType){
            case "InputField":
                InputToCheck = FieldToCheck.GetComponent<TMP_InputField>().text;
                break;
            case "Button":
                //user shouldn't be able to interact with that. However it might come handy later for
                // security check ?
                break;
            case "Dropper":
                TMP_Dropdown dropper = FieldToCheck.GetComponent<TMP_Dropdown>();
                InputToCheck = dropper.options[dropper.value].text;
                break;
            default:
                break;
        }
        //matching (or not) the regexp
        return Regex.IsMatch(InputToCheck,regexp);
    }
    public bool ControlIfEntierlyFilled(GameObject FormToCheck){
        //will check if the Form is entierly completed. To do so, it will take all the children of 
        //the form and do individual check on their value, depending on the type of the child under
        // review
        //input GameObject FormToCheck : the prefab having the form to check. Unit_description can be
        //given as an instance of form... maybe I should add the tag form on te concerned objects...
        //output : bool true if the form is correctly completed, false otherwise

        //why do I keep thinking of her ?

        //doing the check on every child of the Form
        foreach(Transform GivenField in transform){
            //to match the type of the field under scope, we'll use tags. The tag are defined as
            //following : InputField for TMP_InputField, Button for TMP_Button, and Dropper for
            //TMP_Dropdown...

            //this will change our regexp for the following check up... may this piece of code sent
            // on the previous function ?
            switch(GivenField.tag){
                case "InputField":
                    break;
                case "Button": 
                    break;
                case "Dropper": 
                    break;
                default:
                    return false;
            }
            if(!ControlIfCorrectlyFilled(GivenField.gameObject,"",GivenField.tag)){
                return false;
            }
        }
        return true;
    }

//===================================================================================================
//============================================ AutoLock =============================================
//===================================================================================================

}
