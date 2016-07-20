using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour {

	public AudioClip dieClip;

	public Animator animator;

	void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.layer == 9) {

			SoundManager.Instance.StopLoop ();
			SoundManager.Instance.RandomizeSfx (dieClip);

			animator.SetBool ("isDead", true);

			GameManager gm;
			gm = GameManager.Instance;
			gm.OnStateChange += HandleOnStateChange;
			gm.SetGameState(GameState.GAME);

		}
	}

	public void HandleOnStateChange () {

		ScoreManager.Instance.MaxScore = ScoreManager.Instance.CurrentScore;

		Invoke ("LoadLevel", 1f);

	}

	public void LoadLevel() {
		Destroy (gameObject);
		SceneManager.LoadScene ("Game");
	}
}
