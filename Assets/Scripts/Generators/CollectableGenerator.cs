using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableGenerator : MonoBehaviour {

	public List<GameObject> collectablePrefabs;

	public float jumpCount;

	public LayerMask layer;

	[Header("Set range for spawning collectable on road")]
	[Range(0f, 14f)]
	public float obstacleSpawnRange;

	[Header("Set frequency for spawning collectable on road")]
	[Range(0f, 10f)]
	public float collectableSpawnFrequency;

	public float minDistanceBetweenCollectable = 4f;

	// Use this for initialization
	void Start () {

		jumpCount = 4;

		for (int i = 0; i < collectableSpawnFrequency; i++) {
			foreach (GameObject obstacle in collectablePrefabs) {
				SpawnObstacle (obstacle, new Vector3 (Random.Range (transform.position.x - obstacleSpawnRange, transform.position.x + obstacleSpawnRange), (Random.Range(transform.position.y + 2f,transform.position.y + jumpCount + 2f)) , transform.position.z));

			}
		}

	}

	void SpawnObstacle(GameObject collectable, Vector3 location) {
		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), minDistanceBetweenCollectable, layer)) {
			GameObject Collectable = Instantiate (collectable, location, transform.rotation) as GameObject;
		}
	}
}


