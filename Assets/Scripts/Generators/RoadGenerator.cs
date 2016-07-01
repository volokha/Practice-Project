using UnityEngine;
using System.Collections;

public class RoadGenerator : MonoBehaviour {

	public GameObject roadPrefab;

	public float prefabWidth;

	private Vector3 startPointVect;

	private GameObject generatedRoad;

	void Start(){
		
		prefabWidth = roadPrefab.transform.GetChild(0).GetComponent<Renderer> ().bounds.size.x;
		startPointVect = roadPrefab.transform.position;

	}
	void Update() {
		
		if (Camera.main.transform.position.x >= startPointVect.x) 
			GenerateRoad ();
	}

	void GenerateRoad() {
		
		generatedRoad = Instantiate (roadPrefab, new Vector3 (startPointVect.x + prefabWidth, startPointVect.y, startPointVect.z), Quaternion.identity) as GameObject;
		generatedRoad.transform.SetParent (transform);
		startPointVect = generatedRoad.transform.position;
	
	}

}