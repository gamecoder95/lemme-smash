using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHitbox : MonoBehaviour
{

    // Update is called once per frame
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "UpArrow")
        {
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "DownArrow")
        {
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "RightArrow")
        {
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "LeftArrow")
        {
            Destroy(col.gameObject);
        }
    }
}
