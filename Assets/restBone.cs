using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restBone : MonoBehaviour
{
    private float resetSpeed =15;
    private Vector3 oldLoc;
    private Quaternion oldRot;
    bool isreset;
    // Start is called before the first frame update
    void Start()
    {
        oldLoc = transform.localPosition; ;
        oldRot = transform.localRotation;
    }

    public void ResetBone() {
        isreset = true;
       // transform.localRotation = oldRot;
        //transform.localPosition = oldLoc;
       
    }
    // Update is called once per frame
    void Update()
    {
        if (isreset) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, oldLoc, resetSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, oldRot, resetSpeed * Time.deltaTime);
        }
    }
}
