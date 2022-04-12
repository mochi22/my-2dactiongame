using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float positiony;
    public float positionz;
    public float positionshiftdown;
    public float positionshiftup;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x , positiony , positionz);
        if (target.transform.position.y < positionshiftdown)
        {
            transform.position = new Vector3(target.position.x, target.position.y+positiony, positionz);
            if (target.transform.position.y < positionshiftdown-0.2)
            {
                transform.position = new Vector3(target.position.x, positionshiftdown, positionz);
            }
            
        }
        else if (target.transform.position.y > positionshiftup)
        {
            transform.position = new Vector3(target.position.x, target.position.y, positionz);
        }

    }
}
