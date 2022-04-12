using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool GroundEnter = false;//接地になるとき
    public bool GroundExit = false;//接地が終わるとき
    public bool Grounded = false;//接地し続けてる


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            GroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Grounded = true;
            if (GroundExit)
            {
                Grounded = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            GroundExit = true;
        }
    }
}
