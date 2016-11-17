using UnityEngine;
using System.Collections.Generic;

public class RtsManager : MonoBehaviour {

    public static RtsManager current = null;
    public List<PlayerSetupDefinition> players = new List<PlayerSetupDefinition>();

	// Use this for initialization
	void Start () {

        current = this;
        foreach (var p in players)
        {
            foreach (var u in p.startingUnits)
            {
                GameObject.Instantiate(u, p.startLocation.position, p.startLocation.rotation);
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
