using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour {

	public Transform LoadingBar;
	public Transform Indicator;
	public Transform ReadyText;
	[SerializeField] private float currentTime;
	[SerializeField] private float speed;
	[SerializeField] private CanvasGroup cg1, cg2;
	private int i=1;

	void Start ()
	{
		cg1.alpha = 0.0f;
		while (i != 4) 
		{
			StartSequence(i);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (currentTime > 0) {
			currentTime -= speed*Time.deltaTime;
		}

		LoadingBar.GetComponent<Image>().fillAmount = currentTime / 100;
	}

	public IEnumerator StartSequence (int i)
	{
		
			switch (i) {
			case 1:
				ReadyText.GetComponent<Text> ().text = "Ready!";
				i++;
				break;
			case 2:
				ReadyText.GetComponent<Text> ().text = "Set!";
				i++;
				break;
			case 3:
				ReadyText.GetComponent<Text> ().text = "Go!";
				i++;
				break;
			case 4:
				ReadyText.gameObject.SetActive (false);
				break;
			}

			yield return new WaitForSeconds (1.0f);
		}
	
}
