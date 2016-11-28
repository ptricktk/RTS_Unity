using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public RectTransform viewPort;
    public Transform corner1, corner2;
    public GameObject blipPrefab;
    public static Map current;

    private Vector2 terrainSize;
    private RectTransform mapRect;

    public Map()
    {
        current = this;
    }

	// Use this for initialization
	void Start () {
        terrainSize = new Vector2(
            corner2.position.x - corner1.position.x, 
            corner2.position.z - corner1.position.z);
        mapRect = GetComponent<RectTransform>();
    }

    public Vector2 WorldPositionToMap(Vector3 point)
    {
        var pos = point - corner1.position;
        var mapPos = new Vector2(
            pos.x / terrainSize.x * mapRect.rect.width,
            pos.z / terrainSize.y * mapRect.rect.height);

        return mapPos;
    }
	
	// Update is called once per frame
	void Update () {
        viewPort.position = WorldPositionToMap(Camera.main.transform.position);
	}
}
