using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttackTrigger : MonoBehaviour {
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.tag == "EnnemyAttack")
        {
            collision.gameObject.GetComponent<PlayerHearth>().LifePoint(-Damage);
            //StartCoroutine(collision.GetComponent<PlayerController>().Knockback(0.02f, 350, collision.transform.position));
        }
    }
}
