using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind3 : wind {

	public override IEnumerator ChangeDirection ()
	{
		for (;;) 
		{

			//0 - 90 degrees

			float powerOfChange = Random.Range (2, 10);
			int mode = Random.Range (0, 10);
			switch (mode) 
			{
			case 0:
				angleOfDirection = 0f;
				break;
			case 1:
				angleOfDirection = 90f;
				break;
			case 2:
				angleOfDirection = 45f;
				//angleOfDirection += 1f * powerOfChange;
				//if (angleOfDirection > 90)
				//	angleOfDirection = 90f;
				break;
			case 3:
				//angleOfDirection -= 1f * powerOfChange;
				//if (angleOfDirection < 0)
				//	angleOfDirection = 0f;
				angleOfDirection = 120f;
				break;
			case 4:
				angleOfDirection = 300f;
				//if (angleOfDirection > 90)
				//	angleOfDirection = 90f;
				break;
			case 5:
				angleOfDirection = 180f;
				//if (angleOfDirection < 0)
				//	angleOfDirection = 0f;
				break;
			}
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angleOfDirection - 180f));
			yield return new WaitForSeconds (1f);
		}
	}
}
