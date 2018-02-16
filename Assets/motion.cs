using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Motion : MonoBehaviour {

	public Wind wind;

	public Sprite sailOn;
	public Sprite sailOff;

	void Start () 
	{
		
	}

	void Update () 
	{
		
		if (Input.GetKeyDown ("space") || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)) 
			SwitchSail ();

		if (GetComponent<SpriteRenderer> ().sprite == sailOn)
			StartMotion ();
	}

	void SwitchSail ()
	{
		if (GetComponent<SpriteRenderer> ().sprite == sailOn)
			GetComponent<SpriteRenderer> ().sprite = sailOff;
		else
			GetComponent<SpriteRenderer> ().sprite = sailOn;
	}

	void StartMotion()
	{
		float cosine = Mathf.Cos (Wind.angleOfDirection * Mathf.Deg2Rad);
		float sinus = Mathf.Sin (Wind.angleOfDirection * Mathf.Deg2Rad);
		transform.Translate (Time.deltaTime * wind.speed * new Vector3(cosine, sinus));
	}
		
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.name == "goal") 
		{
			StopMotion ();
			Endlevel.ActionAfterWin ();
		}

		if (coll.tag == "obstacle") 
		{
			StopMotion ();
			Endlevel.ActionAfterLose ();
		}
	}

	public void StopMotion ()
	{
		wind.offChange = true;
		wind.speed = 0f;
	}
}
