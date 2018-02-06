using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind2 : wind {

	public override IEnumerator ChangeDirection ()
	{
		for (;;) 
		{

			//270 - 360 degrees

			float powerOfChange = Random.Range (2, 10);
			int mode = Random.Range (0, 10);
			switch (mode) 
			{
			case 0:
				angleOfDirection = 270f;
				break;
			case 1:
				angleOfDirection = 360f;
				break;
			case 2:
				angleOfDirection += 1f * powerOfChange;
				if (angleOfDirection > 360)
					angleOfDirection = 360f;
				break;
			case 3:
				angleOfDirection -= 1f * powerOfChange;
				if (angleOfDirection < 270)
					angleOfDirection = 270f;
				break;
			case 4:
				angleOfDirection++;
				if (angleOfDirection > 360)
					angleOfDirection = 360f;
				break;
			case 5:
				angleOfDirection--;
				if (angleOfDirection < 270)
					angleOfDirection = 270f;
				break;
			}
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angleOfDirection - 180f));
			yield return new WaitForSeconds (1f);
		}
	}
}
