using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour {

    public Collider2D attackTrigger;
    //private Animator ennemyAnim;

    private void Awake()
    {
        //ennemyAnim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
    private void Update()
    {
        if (gameObject.GetComponent<EnnemyController>().attack == true)
        {
            attackTrigger.enabled = true;

        }
        else
            attackTrigger.enabled = false;
    }
}
