using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    bool canpickup;
    public Transform newowner;

    public LayerMask lm;
    public LayerMask oldlm;

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
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                transform.SetParent(newowner);
                canpickup = false;
                foreach (Transform objs in transform)
                {
                    objs.gameObject.SetActive(false);
                }
                foreach (BoxCollider objs in transform.GetComponents<BoxCollider>())
                {
                    objs.enabled = false;
                }
            }

        }
        else
        {

            if (Input.GetKeyDown(KeyCode.F) && newowner != null)
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
                transform.forward = newowner.GetChild(0).forward;
                transform.position += new Vector3(0, .5f, 0);
                GetComponent<Rigidbody>().AddForce(newowner.GetChild(0).forward * 250, ForceMode.Impulse);
                transform.SetParent(null);
                Debug.Log("hello");
                foreach (Transform objs in transform)
                {
                    objs.gameObject.SetActive(true);
                }

                newowner = null;
                foreach (BoxCollider objs in transform.GetComponents<BoxCollider>())
                {
                    objs.enabled = true;
                }
            }
        }
    }

    IEnumerator carfix()
    {
        gameObject.layer = oldlm;
        yield return new WaitForSeconds(.1f);
        gameObject.layer = lm;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("clickbait");
            newowner = other.transform;
            canpickup = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canpickup = false;
            //transform.SetParent(nu
            newowner = null;
        }

    }
}
