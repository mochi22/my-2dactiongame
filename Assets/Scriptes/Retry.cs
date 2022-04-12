using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Time.timeScale == 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
