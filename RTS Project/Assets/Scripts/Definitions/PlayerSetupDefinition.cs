using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerSetupDefinition {

    public string name;
    public Transform startLocation;
    public Color AccentColor;
    public List<GameObject> startingUnits = new List<GameObject>();
    public bool isAi;
    public float credits;
    
}
