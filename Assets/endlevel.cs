using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endlevel : MonoBehaviour {
	
	public GameObject winwindow;
	public Button restart;
	public Button next;
	public Button quit;
	public Text textScore;
	public Text textRecord;
	public static int nextLevel = 1;
	public static Endlevel singleton;


	// Use this for initialization
	void Start () 
	{
		singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public static void ActionAfterLose()
	{
		singleton.winwindow.SetActive(true);
		singleton.textScore.text = "you lose ...";
		singleton.textRecord.text = "record: " + PlayerPrefs.GetInt ("score" + nextLevel, 100);
		singleton.restart.onClick.AddListener (() => Restart(nextLevel));

		if (PlayerPrefs.GetInt ("isAccess" + (nextLevel + 1)) == 1) 
		{
			singleton.next.onClick.AddListener (() => NextLevel (nextLevel + 1));
		}
		singleton.quit.onClick.AddListener (() => Quit ());
	}


	public static void ActionAfterWin()
	{
		Debug.Log ("WINNNN");

		int currentScore = Timer.time - Timer.timeLeft - 1;
		int record = PlayerPrefs.GetInt ("score" + nextLevel, 100);

		singleton.winwindow.SetActive(true);
		singleton.textScore.text = "score: " + currentScore.ToString ();

		if (currentScore < 100) {
			PlayerPrefs.SetInt("isAccess" + (nextLevel + 1), 1); //open access for next level
		}


		if (currentScore < record) 
		{
			PlayerPrefs.SetInt ("score" + nextLevel, currentScore);
			record = currentScore;
			singleton.textRecord.text = "new record: " + record.ToString();
		}
		else
			singleton.textRecord.text = "record: " + record.ToString();

		Debug.Log ("number befor next level - " + nextLevel);
		if (PlayerPrefs.GetInt ("isAccess" + (nextLevel + 1)) == 1) {
			singleton.next.onClick.AddListener (() => NextLevel (nextLevel + 1));
		}
		
		singleton.restart.onClick.AddListener (() => Restart(nextLevel));
		singleton.quit.onClick.AddListener (() => Quit ());
	}

	public static void Restart(int number)
	{
		SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
	}

	public static void NextLevel(int number)
	{
		int levelsCount = PlayerPrefs.GetInt ("levelsCount", 0);
		nextLevel = number;                 				 //save current level
		if (number <= levelsCount) {
			SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
			Debug.Log ("number in next level - " + number);
		}
		else 
			SceneManager.LoadScene ("levels", LoadSceneMode.Single);
			
	}

	public static void Quit()
	{
		SceneManager.LoadScene ("levels", LoadSceneMode.Single);
	}


}
