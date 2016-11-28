using UnityEngine;
using System.Collections.Generic;

public class VisibilityManager : MonoBehaviour {

    public float timeBetweenChecks = 1;
    public float visibleRange = 100;

    private float waited = 1000;
    
	// Update is called once per frame
	void Update () {
        waited += Time.deltaTime;
        if (waited <= timeBetweenChecks)
        {
            return;
        }

        waited = 0;

        List<MapBlip> pBlips = new List<MapBlip>();
        List<MapBlip> oBlips = new List<MapBlip>();

        foreach(var p in RtsManager.current.players)
        {
            foreach (var u in p.activeUnits)
            {
                var blip = u.GetComponent<MapBlip>();
                if (p == Player.Default) pBlips.Add(blip);
                else oBlips.Add(blip);
            }
        }

        foreach (var o in oBlips)
        {
            bool active = false;
            foreach (var p in pBlips)
            {
                var distance = Vector3.Distance(o.transform.position, p.transform.position);
                if (distance <= visibleRange)
                {
                    active = true;
                    break;
                }

            }
            o.blip.SetActive(active);
            foreach (var r in o.GetComponentsInChildren<Renderer>()) r.enabled = active;
        }

        
        
	}
}
