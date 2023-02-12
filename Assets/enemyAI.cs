using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        foreach (CapsuleCollider cc in GetComponentsInChildren<CapsuleCollider>())
        {
            cc.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            foreach (CapsuleCollider cc in GetComponentsInChildren<CapsuleCollider>())
            {
                cc.isTrigger = false;
            }
        }
        else {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                if (rb.GetComponent<restBone>() != null)
                    rb.GetComponent<restBone>().ResetBone();
                transform.GetChild(0).GetComponent<restBone>().ResetBone();

            }

            foreach (CapsuleCollider cc in GetComponentsInChildren<CapsuleCollider>())
            {
                cc.isTrigger = true;
                if(cc.GetComponent <restBone>() != null)
                cc.GetComponent<restBone>().ResetBone();
                transform.GetChild(0).GetComponent<restBone>().ResetBone();
            }

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("revive");
        }
    }

    IEnumerable revive()
    {
        GetComponent<restBone>().ResetBone();
        isDead = true;
        yield return new WaitForSeconds(5);
        isDead = false;
    }
}
