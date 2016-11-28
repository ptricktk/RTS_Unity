using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour { 

    public PlayerSetupDefinition info;

    public static PlayerSetupDefinition Default;

    void Start()
    {
        info.activeUnits.Add(this.gameObject);

    }

    void OnDestory()
    {
        info.activeUnits.Remove(this.gameObject);
    }
}
