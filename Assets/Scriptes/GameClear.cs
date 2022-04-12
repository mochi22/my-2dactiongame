using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().enabled = false;
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<OK>().ok();
            FindObjectOfType<Score>().Save();
            Time.timeScale = 0.0f;
        }
    }
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
