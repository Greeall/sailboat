using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour {


	public Sprite sailOn;
	public Sprite sailOff;

	void Start () 
	{
		//StartCoroutine (Debbubby());
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
		float cosine = Mathf.Cos (angle.angleOfDirection * Mathf.Deg2Rad);
		float sinus = Mathf.Sin (angle.angleOfDirection * Mathf.Deg2Rad);
		transform.Translate (Time.deltaTime * new Vector3(cosine, sinus));
	}
		
}
