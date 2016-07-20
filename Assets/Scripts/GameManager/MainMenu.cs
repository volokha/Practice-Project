using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	GameManager GM;

	void Awake () {
		GM = GameManager.Instance;
		GM.OnStateChange += HandleOnStateChange;
	}

	public void HandleOnStateChange ()
	{
		SceneManager.LoadScene ("Game");
	}
		




	public void StartGame() {
		
		//Start game scene
		GM.SetGameState(GameState.GAME);


	}

	public void Quit() {
		
		Application.Quit();
	}
}
