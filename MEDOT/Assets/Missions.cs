using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    // Start is called before the first frame update
    public enum missions {Reconnaitre, Surveiller, Appuyer, Couvrir};

    public string Nom;
    public string Definition;
    public List<string> Composantes;
    public string Symbol; //we'll use path to the mission's symbol
    public List<string> SubMissions; //mission to subordinates

    void loadMissions()
    {
        //using the filepath to missions data, get all the defined missions in the data file
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
