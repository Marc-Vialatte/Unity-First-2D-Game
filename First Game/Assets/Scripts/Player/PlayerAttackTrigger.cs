using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour {
    GameObject player;
    int da;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ennemy" && this.tag == "PlayerAttack")
        {
            da = player.GetComponent<PlayerInventory>().Damage;
            print(da);
            collision.gameObject.GetComponent<EnnemyHearth>().TakeDamage(-da);
        }
    }
}