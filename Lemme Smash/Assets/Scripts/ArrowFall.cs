using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFall : MonoBehaviour
{

    private float fallSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

    }

}
