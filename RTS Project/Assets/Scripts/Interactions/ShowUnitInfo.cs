using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitInfo : Interaction {

    public string unitName;
    public float maxHealth, currentHealth;
    public Sprite profilePic;

    public override void Select()
    {
        InfoManager.Current.SetLines(unitName, currentHealth + "/" + maxHealth, "Owner: " + GetComponent<Player>().info.name);
        InfoManager.Current.SetPicture(profilePic);
    }

    public override void Deselect()
    {
        InfoManager.Current.ClearLines();
        InfoManager.Current.ClearPic();
    }

}
