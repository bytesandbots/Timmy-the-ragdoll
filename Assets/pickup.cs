using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    bool canpickup;
    Transform newowner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canpickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.SetParent(newowner);
            }
            canpickup = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
                transform.SetParent(null);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            newowner = other.transform;
            canpickup = true;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canpickup = false;
            transform.SetParent(null);
        }
    }
}
