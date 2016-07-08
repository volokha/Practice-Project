using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour {

	public List<GameObject> obstaclePrefabs;

	public LayerMask layer;

	[Header("Set range for spawning obstacles on road")]
	[Range(0f, 14f)]
	public float obstacleSpawnRange;

	[Header("Set frequency for spawning obstacles on road")]
	[Range(0f, 10f)]
	public float obstacleSpawnFrequency;

	public float minDistanceBetweenObstacles = 4f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < obstacleSpawnFrequency; i++) {
			foreach (GameObject obstacle in obstaclePrefabs) {
				SpawnObstacle (obstacle, new Vector3 (Random.Range (transform.position.x - obstacleSpawnRange, transform.position.x + obstacleSpawnRange), transform.position.y - 1.5f, transform.position.z));

			}
		}

	}

	void SpawnObstacle(GameObject obstacle, Vector3 location) {
		if (!Physics2D.OverlapCircle (new Vector2 (location.x, location.y), minDistanceBetweenObstacles, layer)) {
			GameObject Obstacle = Instantiate (obstacle, location, transform.rotation) as GameObject;
		}
	}
}
