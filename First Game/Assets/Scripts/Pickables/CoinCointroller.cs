using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCointroller : MonoBehaviour
{
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { // Nous recuperons le tag de l'objet en colision 
            collision.gameObject.GetComponent<PlayerInventory>().AddCoins();
            Destroy(gameObject, 0.2f);
            Instantiate(reward, transform.position, Quaternion.identity); // transform.position nous permet de recuperer la position de l'objet actuel
        }
    }
}

//gameObject.transform.root.gameObject