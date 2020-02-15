using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameCleanerController : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
            collision.gameObject.GetComponent<PlayerHearth>().MakeDead();

        else if (collision != null && collision.tag == "Ennemy")
            collision.gameObject.GetComponent<EnnemyHearth>().MakeDead();

        else if (collision != null && (collision.tag == "Object" || collision.tag == "Fire"))
            collision.gameObject.GetComponent<ObjectController>().ObjectDestroy();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1"); // Attention a bien mettre le bon nom de scene car sinon elle ne se chargera pas
                                               // Load scene nous permet ici de charger une nouvelle scene au sein de unity
    }
    public void QuitGame()
    {
        Application.Quit(); // Disponible seulement une fois compile
    }
}