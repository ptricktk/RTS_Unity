using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelect : Interaction {

	public override void Deselect()
    {
        ActionsManager.current.ClearButtons();
    }

    public override void Select()
    {
        ActionsManager.current.ClearButtons();
        foreach (var ab in GetComponents<ActionBehaviour>())
        {
            ActionsManager.current.AddButton(
                ab.ButtonPic, 
                ab.GetClickAction()
                );
        }
    }

}
