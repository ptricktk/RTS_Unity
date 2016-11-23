using UnityEngine;
using System.Collections.Generic;

public class RtsManager : MonoBehaviour {

    public static RtsManager current = null;
    public List<PlayerSetupDefinition> players = new List<PlayerSetupDefinition>();
    public TerrainCollider mapCollider;

    public Vector3? ScreenPointToMapPosition(Vector2 point)
    {
        var ray = Camera.main.ScreenPointToRay(point);
        RaycastHit hit;

        if (!mapCollider.Raycast(ray, out hit, Mathf.Infinity)) {
            return null;
        }

        return hit.point;
    }



	// Use this for initialization
	void Start () {

        current = this;
        foreach (var p in players)
        {
            foreach (var u in p.startingUnits)
            {
                var go = (GameObject) GameObject.Instantiate(u, p.startLocation.position, p.startLocation.rotation);
                var player = go.AddComponent<Player>();
                player.info = p;

                if (!p.isAi)
                {
                    if (Player.Default == null) Player.Default = p;
                    go.AddComponent<RighClickNavigation>();
                }
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
