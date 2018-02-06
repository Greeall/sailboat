using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public wind a;
	public Text txt;
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
		if (a.offChange)
			StopCoroutine (backTime);
	}

	IEnumerator BackTime()
	{
		for (;;) 
		{
			txt.text = timeLeft.ToString ();
			timeLeft--;
			yield return new WaitForSeconds (1f);
		}
	}
}
