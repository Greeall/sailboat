using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour {
	
	public GameObject winwindow;
	public Button restart;
	public Button next;
	public Text textScore;
	public Text textRecord;
	public static int nextLevel = 0;
	public static endlevel singleton;


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

		if(PlayerPrefs.GetInt("isAccess" + (nextLevel + 1)) == 1)
			singleton.next.onClick.AddListener (() => NextLevel(nextLevel));
	}


	public static void ActionAfterWin()
	{
		int currentScore = timer.time - timer.timeLeft - 1;
		int record = PlayerPrefs.GetInt ("score" + nextLevel, 100);

		singleton.winwindow.SetActive(true);
		singleton.textScore.text = "score: " + currentScore.ToString ();

		if (currentScore < 100) {
			PlayerPrefs.SetInt("isAccess" + (nextLevel + 1), 1);
		}


		if (currentScore < record) 
		{
			PlayerPrefs.SetInt ("score" + nextLevel, currentScore);
			record = currentScore;
			singleton.textRecord.text = "new record: " + record.ToString();
		}
		else
			singleton.textRecord.text = "record: " + record.ToString();


		if(PlayerPrefs.GetInt("isAccess" + (nextLevel + 1)) == 1)
			singleton.next.onClick.AddListener (() => NextLevel(nextLevel));
		
		singleton.restart.onClick.AddListener (() => Restart(nextLevel));
		
	}

	public static void Restart(int number)
	{
		SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
	}

	public static void NextLevel(int number)
	{
		int levelsCount = PlayerPrefs.GetInt ("levelsCount", 0);
		if (number < levelsCount)
			SceneManager.LoadScene ("level" + ++number, LoadSceneMode.Single);
		else 
			SceneManager.LoadScene ("levels", LoadSceneMode.Single);
			
	}

	public void Quit()
	{
		SceneManager.LoadScene ("levels", LoadSceneMode.Single);
	}


}
