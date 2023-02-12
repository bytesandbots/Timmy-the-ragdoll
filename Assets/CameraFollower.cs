using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotAngles  = Vector3.zero ;
        rotAngles.y = Camera.main.transform.localEulerAngles.y;
        transform.localEulerAngles = rotAngles;
    }
}
