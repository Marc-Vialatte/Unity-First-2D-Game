using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    /*Animator playerAnim;
    public Transform attackPos;
    public LayerMask whatIsEnnemies;
    public float attackRange;
    int damage;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        damage = GetComponent<PlayerInventory>().Damage;
        if (Input.GetAxis("Fire1") > 0 && GetComponent<PlayerController>().grounded && GetComponent<PlayerController>().canAttack)
        {
            playerAnim.SetBool("IsAttack", true);
            Collider2D[] ennemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, 0, whatIsEnnemies);
            for (int i = 0; i < ennemiesToDamage.Length; i++)
            {
                print(damage);
                ennemiesToDamage[i].GetComponent<EnnemyHearth>().TakeDamage(-damage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }*/

    public Collider2D attackTrigger;
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
    private void Update()
    {
        if (playerAnim.GetBool("IsAttack") == true)
        {
            attackTrigger.enabled = true;

        }
        else
            attackTrigger.enabled = false;
    }
}