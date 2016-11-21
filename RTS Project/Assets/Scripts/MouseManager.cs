using UnityEngine;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour {

    private List<Interactive> _selections = new List<Interactive>();
	
	// Update is called once per frame
	void Update () {
	    if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var es = UnityEngine.EventSystems.EventSystem.current;
        if (es != null && es.IsPointerOverGameObject())
        {
            return;
        }

        if (_selections.Count > 0)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                foreach (var sel in _selections)
                {
                    if (sel != null) sel.Deselect();
                }
                _selections.Clear();
            }
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        var interact = hit.transform.GetComponent<Interactive>();
        if (interact == null)
        {
            return;
        }
        else
        {
            _selections.Add(interact);
            interact.Select();
        }
	}
}
