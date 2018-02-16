using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	public static float angleOfDirection = 45f;
	public float speed = 3f;
	public bool offChange;
	public Coroutine changeDirection;

    void Start () 
	{
		changeDirection = StartCoroutine(ChangeDirection ());
		angleOfDirection = transform.eulerAngles.z - 180f;
	}

    void Update () 
	{
		if (offChange) 
			StopCoroutine (changeDirection);
	}


	public virtual IEnumerator ChangeDirection ()
	{
		for (;;) {
			Debug.Log ("THIS SHOUDNT BE DONE!!!!!");
			yield return new WaitForSeconds (1f);
		}
	}

}
