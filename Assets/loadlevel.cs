using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadlevel : MonoBehaviour {

	public GameObject buttonPrefab;
	public List <string> levels;

	void Start () 
	{
		DisplayLevels ();
	}
	

	void Update () 
	{
		
	}

	public void DisplayLevels()
	{
		float i = 0;
		int number = 1;

		foreach (string level in levels) 
		{
			GameObject b = Instantiate(buttonPrefab, new Vector3(150f + i, 2.5f, 0f), transform.rotation) as GameObject;
			b.transform.SetParent (GameObject.Find ("Canvas").transform, false);
			b.GetComponentInChildren<Text> ().text = number.ToString ();
			AddListener (b.GetComponent<Button>(), number);
			i += 150f;
			number++;
		}
	}

	void AddListener(Button but, int number)
	{
		but.onClick.AddListener (() => LoadLevel(number));
	}


	public void LoadLevel(int number)
	{
		SceneManager.LoadScene ("level" + number, LoadSceneMode.Single);
		endlevel.nextLevel = number;
	}
}
