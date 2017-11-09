using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMasterMenu : MonoBehaviour {

	public void LoadGame ()
	{
		SceneManager.LoadScene("game");
	}
}
