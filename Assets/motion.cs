using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class motion : MonoBehaviour {

	public wind a;

	public Sprite sailOn;
	public Sprite sailOff;

	void Start () 
	{
		
	}

	void Update () 
	{
		
		if (Input.GetKeyDown ("space")) 
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
		float cosine = Mathf.Cos (wind.angleOfDirection * Mathf.Deg2Rad);
		float sinus = Mathf.Sin (wind.angleOfDirection * Mathf.Deg2Rad);
		transform.Translate (Time.deltaTime * a.speed * new Vector3(cosine, sinus));
	}
		
	void OnTriggerEnter2D(Collider2D coll) 
	{
		StopMotion ();
		endlevel.ActionAfterWin ();
	}

	void StopMotion ()
	{
		a.offChange = true;
		a.speed = 0f;
	}
}
