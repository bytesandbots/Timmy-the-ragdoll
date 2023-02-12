using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puncher : MonoBehaviour
{
    public float damage = 3;
    public float attackForce = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //put damage here
        Rigidbody victum = collision.gameObject.GetComponent<Rigidbody>();
        if (victum != null)
        {
            victum.AddForce(transform.forward * attackForce, ForceMode.Impulse);
        }
    }
}
