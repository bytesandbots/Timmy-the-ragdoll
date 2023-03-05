using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public bool isDead;
    public manager gm;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
            rb.useGravity = false;

        }

        foreach (Collider cc in GetComponentsInChildren<Collider>())
        {
            cc.isTrigger = true;
        }

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true ;
        GetComponent<CapsuleCollider>().isTrigger = false ;



    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("HaaNd"))
        {
            StartCoroutine(revive());
            isDead = true;
        }
        if(collision.gameObject.CompareTag("Untagged")||collision.gameObject.CompareTag("HaaNd"))
        {
            gm.addMoney(10);
        }
    }

    IEnumerator revive()
    {
        isDead = true;

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        foreach (Collider cc in GetComponentsInChildren<Collider>())
        {
            cc.isTrigger = false;
        }

        yield return new WaitForSeconds(5);
        isDead = false;


        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
            rb.useGravity = false;

        }

        foreach (Collider cc in GetComponentsInChildren<Collider>())
        {
            cc.isTrigger = true;
        }

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().isTrigger = false;

    }
}
