using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		this.gameObject.GetComponent<Text>().enabled = false;
	}

	public void gameover()
	{
		this.gameObject.GetComponent<Text>().enabled = true;
	}
}
