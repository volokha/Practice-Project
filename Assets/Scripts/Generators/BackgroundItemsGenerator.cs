using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundItemsGenerator : MonoBehaviour {

	[Header("Set frequency for spawning trees")]
	[Range(0f, 1f)]
	public float treesFrequency;

	[Header("Set frequency for spawning trucks")]
	[Range(0f, 1f)]
	public float trucksFrequency;

	[Header("Set frequency for spawning constructions")]
	[Range(0f, 1f)]
	public float constructionsFrequency;

	[Header("Set frequency for spawning clouds")]
	[Range(0f, 1f)]
	public float cloudsFrequency;

	public List<GameObject> bgItems;

	public LayerMask layer;

	public float generationAreaX = 7f;

	void Start () {
		/*for (int i = 0; i < 10; i++) {
			foreach (var item in bgItems) {
				SpawnObjectsOnRoad (item, new Vector3 (Random.Range (transform.position.x - generationAreaX, transform.position.x + generationAreaX), transform.position.y + 1f, transform.position.z));
			}
		}*/



		for (int i = 0; i < 10; i++) {
			if (Random.value < treesFrequency) {
					SpawnTree (new Vector3 (Random.Range (transform.position.x - generationAreaX, transform.position.x + generationAreaX), transform.position.y + 1f, transform.position.z));
			}
		}

		for (int i = 0; i < 10; i++) {
			if (Random.value < cloudsFrequency) {
				SpawnCloud (new Vector3 (Random.Range (transform.position.x - generationAreaX, transform.position.x + generationAreaX), transform.position.y + 6f, transform.position.z));
			}
		}
		for (int i = 0; i < 10; i++) {
			if (Random.value < constructionsFrequency) {
				SpawnConstruction (new Vector3 (Random.Range (transform.position.x - generationAreaX, transform.position.x + generationAreaX), transform.position.y + 1f, transform.position.z));
			}
		}
	

	}



		
	void SpawnTree(Vector3 location) {
		
		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), 4f, layer)) {
			GameObject Tree = Instantiate (bgItems [0], location, transform.rotation) as GameObject;
		}
		//Tree.transform.SetParent (transform);
	}
	void SpawnCloud(Vector3 location) {

		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), 2f, layer)) {
			GameObject Cloud = Instantiate (bgItems [1], location, transform.rotation) as GameObject;
		}
		//Tree.transform.SetParent (transform);
	}
	void SpawnConstruction(Vector3 location) {

		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), 3f, layer)) {
			GameObject Cloud = Instantiate (bgItems [2], location, transform.rotation) as GameObject;
		}
		//Tree.transform.SetParent (transform);
	}

	/*void SpawnObjectsOnRoad(GameObject obj, Vector3 location) {
		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), 3f, layer)) {
			GameObject Obj = Instantiate (obj, location, transform.rotation) as GameObject;
		}

	}
	*/
}
