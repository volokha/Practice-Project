using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {

		if (other.transform.parent != null)
			Destroy (other.transform.parent.gameObject);
		else
			Destroy (other.gameObject);

	}
}
