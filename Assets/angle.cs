using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angle : MonoBehaviour {

	public static float angleOfDirection = 45f;
	public static float windSpeed = 1f;

	// Use this for initialization
	void Start () 
	{
		angleOfDirection = transform.eulerAngles.z - 180f;
		StartCoroutine(ChangeDirection ());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	IEnumerator ChangeDirection ()
	{
		for (;;) {
			//if (Random.Range (0, 100) < 50) {
			//	angleOfDirection += 10f;
			//}

			angleOfDirection += 10f;

		
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angleOfDirection - 180f));
			yield return new WaitForSeconds (3f);
		}
	}

}
