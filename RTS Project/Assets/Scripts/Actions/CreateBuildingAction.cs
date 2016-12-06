using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildingAction : ActionBehaviour {
    
    public override System.Action GetClickAction()
    {
        return delegate ()
        {
            Debug.Log("Button clicked!");
        };
        
    }

}
