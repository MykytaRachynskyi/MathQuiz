using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public Transform LoadingBar;
	public Transform Indicator;
	public Transform ReadyText;
	public Transform InputField;
	public Transform Problem;
	public Transform Score;
	[SerializeField] private float currentTime = 100;
	[SerializeField] private float speed = 100/15;
	[SerializeField] private CanvasGroup cg1; 
	[SerializeField] private CanvasGroup cg2;
	[SerializeField] private CanvasGroup cg3;
	[SerializeField] private CanvasGroup cg4;
	[SerializeField] private CanvasGroup cg5;
	[SerializeField] private CanvasGroup cg6;
	public InputField inpf;
	private bool StartSequenceDone;
	private bool problemDone = true;
	private bool weCanGo = true;
	private bool isAddition;
	private int Number1, Number2, Solution;
	private string userSolution;
	private Coroutine corNum;
	private int ScoreNum;

	void Start ()
	{
		StartCoroutine(StartSequence());
		ScoreNum = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		if (StartSequenceDone)
		{
			StartSequenceDone = false;
			StartGame();
		}

		if (currentTime < 0) 
			LoseScreen();
	}

	public IEnumerator StartSequence ()
	{
		cg1.alpha = 1.0f;
		cg2.alpha = 0.0f;
		cg3.alpha = 1.0f;
		cg4.alpha = 0.0f;
		cg5.alpha = 0.0f;
		cg6.alpha = 0.0f;
		cg2.interactable = false;
		cg6.interactable = false;

		int counter = 1;
		int i = 5;
		while (counter<i) {
			switch (counter) {
			case 1:
				ReadyText.GetComponent<Text> ().text = "Ready!";
				counter++;
				break;
			case 2:
				ReadyText.GetComponent<Text> ().text = "Set!";
				counter++;
				break;
			case 3:
				ReadyText.GetComponent<Text> ().text = "Go!";
				counter++;
				break;
			case 4:
				cg3.alpha = 0.0f;
				cg2.alpha = 1.0f;
				cg2.interactable = true;
				counter++;
				StartSequenceDone = true;
				break;
			}

			yield return new WaitForSeconds (2.0f);
		}
	}

//	public IEnumerator ProblemSequence ()
//	{
//		
//	}

	public IEnumerator StartCounter ()
	{
		while (currentTime > 0) {
			currentTime -= speed/100;
			LoadingBar.GetComponent<Image> ().fillAmount = currentTime / 100;
			yield return new WaitForSeconds (0.01f);
			if (currentTime < 100 - speed)
				Indicator.GetComponent<Text>().text = "14";
			if (currentTime < 100 - speed*2)
				Indicator.GetComponent<Text>().text = "13";
			if (currentTime < 100 - speed*3)
				Indicator.GetComponent<Text>().text = "12";
			if (currentTime < 100 - speed*4)
				Indicator.GetComponent<Text>().text = "11";
			if (currentTime < 100 - speed*5)
				Indicator.GetComponent<Text>().text = "10";
			if (currentTime < 100 - speed*6)
				Indicator.GetComponent<Text>().text = "9";
			if (currentTime < 100 - speed*7)
				Indicator.GetComponent<Text>().text = "8";
			if (currentTime < 100 - speed*8)
				Indicator.GetComponent<Text>().text = "7";
			if (currentTime < 100 - speed*9)
				Indicator.GetComponent<Text>().text = "6";
			if (currentTime < 100 - speed*10)
				Indicator.GetComponent<Text>().text = "5";
			if (currentTime < 100 - speed*11)
				Indicator.GetComponent<Text>().text = "4";
			if (currentTime < 100 - speed*12)
				Indicator.GetComponent<Text>().text = "3";
			if (currentTime < 100 - speed*13)
				Indicator.GetComponent<Text>().text = "2";
			if (currentTime < 100 - speed*14)
				Indicator.GetComponent<Text>().text = "1";
			if (currentTime < 100 - speed*15)
				Indicator.GetComponent<Text>().text = "0";
		}
		problemDone = true;
	}                  

	void GenerateProblem ()
	{
		Number1 = Random.Range (1, 10);
		Number2 = Random.Range (1, 10);
		string num1 = Number1.ToString();
		string num2 = Number2.ToString();
		int coin = Random.Range (1, 3);
		if (coin == 1) {
			Solution = Number1 + Number2;
			isAddition = true;
			Problem.GetComponent<Text> ().text = num1 + " + " + num2;
		} else {
			Solution = Number1 - Number2;
			isAddition = false;
			Problem.GetComponent<Text> ().text = num1 + " - " + num2;
		}
	}

	public IEnumerator Wait ()
	{
		yield return new WaitForSeconds(2);
		StartGame();
	}

	void StartGame ()
	{
		cg2.alpha = 1.0f;
		cg2.interactable = true;
		cg4.alpha = 0.0f;
		cg5.alpha = 1.0f;
		cg6.interactable = false;
		GenerateProblem();
		currentTime = 100;
		Indicator.GetComponent<Text>().text = "15";
		corNum = StartCoroutine(StartCounter());
	}

	public void getInput ()
	{
		userSolution = inpf.text;
		StopCoroutine (corNum);
		inpf.text = "";
		if (userSolution == Solution.ToString ()) {
			cg2.alpha = 0.0f;
			cg4.alpha = 1.0f;
			cg5.alpha = 0.0f;
			ScoreNum +=10;
			Score.GetComponent<Text>().text = ScoreNum.ToString();
			StartCoroutine(Wait());
		} else {
			LoseScreen();
		}
	}

	public void LoadMenu ()
	{
		SceneManager.LoadScene("menu");
	}

	void LoseScreen ()
	{
			cg2.alpha = 0.0f;
			cg2.interactable = false;
			cg5.alpha = 0.0f;
			cg6.alpha = 1.0f;
			cg6.interactable = true;
	}
}
