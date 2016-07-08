using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	[Header("UI")]
	[SerializeField]
	Text scoreText;

	[SerializeField]
	Text bestScore;

	public int MaxScore {
		get {
			return PlayerPrefs.GetInt ("MaxScore");
		}
		set {
			if (PlayerPrefs.GetInt ("MaxScore") < value) {
				PlayerPrefs.SetInt ("MaxScore", value);
				bestScore.text = value.ToString ();
			}


		}
	}

	static int currentScore = 0;
	public int CurrentScore {
		get {
			return currentScore;
		}
		set {
			currentScore = value;

			if (currentScore < 0)
				currentScore = 0;

			if (currentScore > MaxScore) {
				print ("YOU'VE BEATED BEST SCORE");
				MaxScore = currentScore;
			}

			scoreText.text = currentScore.ToString();
		}
	}

	void Awake() {
		if (!instance)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);   
	}

	void Start() {
		bestScore.text = MaxScore.ToString();
		CurrentScore = 0;
		MaxScore = PlayerPrefs.GetInt ("MaxScore");
		scoreText.text = CurrentScore.ToString();
	}

	static ScoreManager instance = null; 

	public static ScoreManager Instance{
		get {
			return instance;
		}
	}
}