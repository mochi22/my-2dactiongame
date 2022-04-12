using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OK : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		this.gameObject.GetComponent<Text>().enabled = false;
	}

	public void ok()
	{
		this.gameObject.GetComponent<Text>().enabled = true;
	}
}
