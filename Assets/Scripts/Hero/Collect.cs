using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	public AudioClip collectClip;

	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.layer == 12) {

			SoundManager SOUNDM;
			SOUNDM = SoundManager.Instance;
			SOUNDM.RandomizeSfx (collectClip);


			Destroy (coll.gameObject);

			ScoreManager SM;
			SM = ScoreManager.Instance;
			SM.CurrentScore++;
		}
	}
}
