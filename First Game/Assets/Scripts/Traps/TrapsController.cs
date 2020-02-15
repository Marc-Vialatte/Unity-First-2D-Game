using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsController : MonoBehaviour 
{
    float timer = 0;
    public float damageTime = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.tag == "Traps")
        { // Nous recuperons le tag de l'objet en colision 
            collision.gameObject.GetComponent<PlayerHearth>().LifePoint(-1);
        }

        if (collision.tag == "Ennemy" && this.tag == "Traps")
        {
            collision.gameObject.GetComponent<EnnemyHearth>().TakeDamage(-1);
        }
    }

    private void OnTriggerStay2D(Collider2D damage)
    {
        if (damage.gameObject.tag == "Player" && this.tag == "Traps")
        {
            if (timer >= damageTime)
            {
                timer -= damageTime;
                damage.gameObject.GetComponent<PlayerHearth>().LifePoint(-1);
            }
            timer += Time.deltaTime;
        }

        if (damage.gameObject.tag == "Ennemy" && this.tag == "Traps")
        {
            if (timer >= damageTime)
            {
                timer -= damageTime;
                damage.gameObject.GetComponent<EnnemyHearth>().TakeDamage(-1);
            }
            timer += Time.deltaTime;
        }
    }
}