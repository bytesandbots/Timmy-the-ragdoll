using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrotation : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 destinationRotation = Vector3.zero;
    public float rotSpeed = 10;

    public Transform referenceOrSomething;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            if (h > 0)
            {
                destinationRotation = referenceOrSomething.TransformDirection(Vector3.right);
            }
            if (h < 0)
            {
                destinationRotation = referenceOrSomething.TransformDirection(Vector3.left);
            }

            if (v > 0)
            {
                destinationRotation = referenceOrSomething.TransformDirection(Vector3.forward);
            }
            if (v < 0)
            {
                destinationRotation = referenceOrSomething.TransformDirection(Vector3.back);
            }
            transform.forward = Vector3.MoveTowards(transform.forward,destinationRotation,rotSpeed *Time.deltaTime);
        }
    }
}
