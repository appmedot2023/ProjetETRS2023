using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManagement : MonoBehaviour
{
    public int ConvertGDHToMinutes(string GDH){
        //Will get a GDH in the given format(HH:MM), an turn it into the associated amount
        //of minutes
        // input : string GDH a GDH with the given format
        // output : int ConvertedGDH the equivalent in minutes.
        
        //caution : I'll have to make sure the GDH is at the good format... doing it from
        // the input field might not be sufficient
        int ConvertedGDH = int.Parse(GDH.Substring(0,2))*60 + int.Parse(GDH.Substring(2,2));
        return ConvertedGDH;
    }
    public int TimeDifference(string GDH1, string GDH2){
        // for two given GDHS, will calculate the difference and return the overall time
        // allocated to this period in minutes.
        // input : string GDH1, string GDH2 two GDHs having the given format (HH:MM), 
        // and GDH1<GDH2
        // output : int TotalTimeOfThePeriod : the overall time of the period, given in minutes

        //caution : check that GDH1<GDH2
        int GDH1_in_Minutes = ConvertGDHToMinutes(GDH1);
        int GDH2_in_Minutes = ConvertGDHToMinutes(GDH2);
        int TotalTimeOfThePeriod = GDH2_in_Minutes - GDH1_in_Minutes;
        return TotalTimeOfThePeriod; 
    }
    public void GenerateTimeLine(List<string> GDHS){
        //will generate the base for the timeline. Based on the differnt GDH given in the 
        // OPOCDU, we will 1) have a scale for the timeline, 2) set marks for the different
        // times of the operations
        // input : List<string> GDHs list of gdh with the given format (HH:MM)
        // output : void

        //create the image file
        float length_of_timeline = 0f; //might depend on the format of the picture 
        //loat heigth_of_timeline = 0f;

        //problem encountered : System.Drawing.Common is no longer supported for os other than
        //windows.. don't know how to get a solution to that yet...
        //System.Drawing.Common.Image newImage = System.Drawing.Image.FromFile();

        //draw the horizontal lines
        //dessine moi un mouton...

        //set te gdhs : 
        foreach(string GDH in GDHS){
            //create a new vertical line. X = diffgdh0, GDHcurrent
            int diff = TimeDifference(GDHS[0],GDH);
            float x_position = diff/length_of_timeline;
            //draw the associated line
            // write the GDH with string format at the coordinate...
        }
    }

    public void ManageEniOnTimeline(){
        GameObject[] Eni_CDU = GameObject.FindGameObjectsWithTag("Eni_CDU");
        GameObject[] Eni_CDS = GameObject.FindGameObjectsWithTag("Eni_CDS");

        foreach (GameObject Eni in Eni_CDU){}
    }
    
}
