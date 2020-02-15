using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour {

    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { // Nous recuperons le tag de l'objet en colision 
            collision.gameObject.GetComponent<PlayerInventory>().AddPotions();
            Destroy(gameObject, 0.2f);
            Instantiate(reward, transform.position, Quaternion.identity);
        }
    }
}
