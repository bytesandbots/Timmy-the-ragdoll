using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackfrequency = 1f;
    public float KICKfrequency = 2f;
   
    private float ctime;
    private float ctime2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator punchWait()
    {
        GetComponent<playermovement>().canMove = false;
        yield return new WaitForSeconds(2);
        GetComponent<playermovement>().canMove = true;
    }
    IEnumerator KICKwait()
    {
        GetComponent<playermovement>().canMove = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<playermovement>().canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (ctime >= attackfrequency)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("PUNCH");
                ctime = 0;
                StartCoroutine(punchWait()) ;
            }
        }
        else
        {
            ctime += Time.deltaTime;
        }
        if (ctime2 >= KICKfrequency)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                anim.SetTrigger("KICK");
                ctime2 = 0;
                StartCoroutine(KICKwait());
            }
        }
        else
        {
            ctime2 += Time.deltaTime;
        }
    }
}
