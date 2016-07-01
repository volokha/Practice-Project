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


	public void OnGUI() {
		//menu layout
		GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 800));
		GUI.Box (new Rect (0, 0, 100, 200), "Main Menu");
		if (GUI.Button (new Rect (10, 40, 80, 30), "Start")){
			StartGame();
		}
		if (GUI.Button (new Rect (10, 160, 80, 30), "Quit")){
			Quit();
		}
		GUI.EndGroup();
	}




	public void StartGame() {
		
		//Start game scene
		GM.SetGameState(GameState.GAME);


	}

	public void Quit() {
		
		Application.Quit();
	}
}
