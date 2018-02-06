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

	public static void ActionAfterWin()
	{
		int currentScore = timer.time - timer.timeLeft;
		int record = PlayerPrefs.GetInt ("score" + nextLevel, 0);

		singleton.winwindow.SetActive(true);
		singleton.textScore.text = currentScore.ToString ();

		if (currentScore > record) 
		{
			PlayerPrefs.SetInt ("score" + nextLevel, currentScore);
			record = currentScore;
		}

		singleton.textRecord.text = record.ToString();

		singleton.restart.onClick.AddListener (() => Restart(nextLevel));
		singleton.next.onClick.AddListener (() => NextLevel(nextLevel));
	}

	public static void Restart(int number)
	{
		SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
	}

	public static void NextLevel(int number)
	{
		number++;
		SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
	}

	public void Quit()
	{
		SceneManager.LoadScene ("levels", LoadSceneMode.Single);
	}
}
