using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THROWAWAY : MonoBehaviour
{

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
