using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Wind wind;              //object of wind for check if stop wind and then stop timer here
	public Text txt;
	public Motion motion;
	public static int time = 100;
	public static int timeLeft;
	Coroutine backTime;

	// Use this for initialization
	void Start () 
	{
		timeLeft = time;
		txt.gameObject.GetComponent<Text> ();
		backTime = StartCoroutine (BackTime());
	}

	// Update is called once per frame
	void Update () 
	{
		if (wind.offChange)
			StopCoroutine (backTime);
	}

	IEnumerator BackTime()
	{
		for (;;) 
		{
			txt.text = timeLeft.ToString ();
			timeLeft--;
			if (timeLeft == -1) {
				motion.StopMotion ();
				Endlevel.ActionAfterLose ();
			}
			yield return new WaitForSeconds (1f);
		}
	}
}
