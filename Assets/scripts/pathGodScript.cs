using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class pathGodScript : MonoBehaviour
{

	public int globalCounter = 0;

	public int globalTileMax = 0;
	
	public List<GameObject> pathSpheres = new List<GameObject>();
	public List<GameObject> floorTiles = new List<GameObject>();

	public GameObject mainCam;
	private Vector3 averagePosition;
	
	// Use this for initialization
	void Awake () {
		pathSpheres.Add(GameObject.FindGameObjectWithTag("PathSphere"));
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject floorTile in floorTiles)
		{
			averagePosition += floorTile.transform.position;
		}
		averagePosition /= floorTiles.Count;
			
		Debug.Log("Average Position = " + averagePosition);

		mainCam.transform.position = new Vector3(750, averagePosition.y, averagePosition.z);
		mainCam.GetComponent<Camera>().orthographicSize = 100 + ((pathSpheres.Count) * 5);

		
		
		
		
		if (globalCounter > globalTileMax)
		{
			foreach (GameObject pathSphere in pathSpheres)
			{
				Destroy(pathSphere);
			}
		}
		
		averagePosition = Vector3.zero;
	}
}
