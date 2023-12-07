using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using TMPro;
using System;

public class MapManagement : MonoBehaviour
{

    public void SearchPictureForTheMap(){
        //Open the explorer, and will load the picture given by the path in the asset directory. Since we're dealing with 
        // map loading, we will put it in Assets/Resources/Map as map.jpeg
        //input : void
        //output : void

        string path = EditorUtility.OpenFilePanel("loading","","jpeg");
        if(path != ""){
            if(File.Exists("Assets/Resources/Map/map.jpeg")){
                File.Delete("Assets/Resources/Map/map.jpeg");    
            }
            File.Copy(path,"Assets/Resources/Map/map.jpeg");
        } 
        //later we may decide to have multiple maps (for both cdu and cds....)
    }

    public void LoadTheMap(GameObject MapPictureField){
        //Loading the map on the map canvas
        //input : gameobject MapPictureField : te picture map to fill with the map
        // output : void 

        //do some checking before to load the map...
        MapPictureField.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Map/map");
    }

    public string CentralPoint; //Coordinates of the central point in game

    public List<float> InGameScales(){
        List<float> scales = new List<float>();

        //get the coordinates from the O,x and y coordinates fields
        // it could be a good thing to heck if coordinates match the regexp
        // furthermore, have to make sure that O.x = y.x, O.y = x.y, O.x < x.x, O.y < y.y
        string[] RawOCoordinates = GameObject.Find("O_coordinates").GetComponent<TMP_InputField>().text.Split("-");
        string[] RawXCoordinates = GameObject.Find("x_coordinates").GetComponent<TMP_InputField>().text.Split("-");
        string[] RawYCoordinates = GameObject.Find("y_coordinates").GetComponent<TMP_InputField>().text.Split("-");
        
        //defining the x scale
        //int XCamPixelMeasurement = MainCam.pixelWidth;
        //for now, InGameX i defined between -10 and 10 (to be on screen). This may change later...
        // scale is centered, allowing negative values (?)
        float Xscale = (Int32.Parse(RawXCoordinates[0]) - Int32.Parse(RawOCoordinates[0]))/20f;
        
        //same with y
        float Yscale = (Int32.Parse(RawYCoordinates[1]) - Int32.Parse(RawOCoordinates[1]))/10f;
        
        //setting the central point
        CentralPoint = ((Int32.Parse(RawXCoordinates[0]) + Int32.Parse(RawOCoordinates[0]))/2).ToString() + "-" + ((Int32.Parse(RawYCoordinates[1]) + Int32.Parse(RawOCoordinates[1]))/2).ToString();
        
        scales.Add(Xscale);
        scales.Add(Yscale);
        return scales;
    }

    public void scaling(){
        InGameScales();
    }

    public List<float> OnMapCoordinatesToInGameCoordinates(string OnMapCoordinates){
        //Given the reduced coordinates of a point, returns the in game coordinates of the same point
        //input : string OnMapCoordinates coordinates matching the regexp as stated in Control.cs
        //output : List<float> InGameCoordinates a couple of floats for x,y coordinates of the point
        // in game
        List<float> scales = InGameScales();
        string[] RawOnMapCoordinates = OnMapCoordinates.Split("-");
        string[] RawCentralPointCoordinates = CentralPoint.Split("-");
        //first checking if we'll have to put it on positive or negative side of the map
        float Xhibition = (Int32.Parse(RawOnMapCoordinates[0]) - Int32.Parse(RawCentralPointCoordinates[0]))/scales[0];
        //Hey Mussorgsky, seems we got ourselves a new pitcure for the Xhibition !
        //ok I really am the only one to get the joke over here... That's why I shouldn't be doing 
        //collaborative work...
        float Yposition = (Int32.Parse(RawOnMapCoordinates[1]) - Int32.Parse(RawCentralPointCoordinates[1]))/scales[1];
        return new List<float>() {Xhibition,Yposition};
    }

    public void PlacingUnitOnMap(){
        //will find all units using tags, and place them according to their position
        //input : 
        //output : void

        List<string> ListOfTagToSearch = new List<string>() {"eni_cdu","eni_cds"};
        List<GameObject[]> ListUnitsInGame = new List<GameObject[]>() {GameObject.FindGameObjectsWithTag("eni_cdu"),GameObject.FindGameObjectsWithTag("eni_cds"),GameObject.FindGameObjectsWithTag("ami")}; //maybe I'm not forced to
        //initialize the array
        //foreach(string tag in ListOfTagToSearch){
        //    UnitsInGame.Concat(GameObject.FindGameObjectsWithTag(tag)).ToArray();
        //} iteration doesn't work for some reasons...

        //placing the units
        foreach(GameObject[] UnitsInGame in ListUnitsInGame){
            foreach(GameObject unit in UnitsInGame){
                List<float> coordinates = OnMapCoordinatesToInGameCoordinates(unit.GetComponent<Units>().position);
                unit.transform.position = new Vector3(coordinates[0],coordinates[1],0f);
            }
        }

    }
}
