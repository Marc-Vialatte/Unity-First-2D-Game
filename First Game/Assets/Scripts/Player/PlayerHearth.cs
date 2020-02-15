using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHearth : MonoBehaviour {

    Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator

    public CanvasGroup endCG;
    public Text endGameUIText;
    string endText = "You win !";
    string endTextLoose = "You died !";

    public int numOfHeart;
    public int maxLifePoints;
    public int lifepoints;
    public Image[] LifeBar;
    public Sprite FullHeart;
    public Sprite TQHeart;
    public Sprite HalfHeart;
    public Sprite QuartHeart;
    public Sprite EmptyHeart;

    public GameObject Hurt;


    private void Start()
    {
        maxLifePoints = numOfHeart * 4;
        lifepoints = maxLifePoints;
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        maxLifePoints = numOfHeart * 4;
        
        UpdateLife();
    }

    public void LifePoint(int d)
    {
        lifepoints += d;

        Instantiate(Hurt, transform.position, Quaternion.identity);
        Death();
    }

    public void UpdateLife()
    {
        for (int i = 0; i < numOfHeart; i++)
        {
            if (i+1 < (lifepoints / 4))
                LifeBar[i].sprite = FullHeart;

            else
                switch ((((i + 1) * 4) - lifepoints))
                {
                    case 1:
                        LifeBar[i].sprite = TQHeart;
                        break;
                    case 2:
                        LifeBar[i].sprite = HalfHeart;
                        break;
                    case 3:
                        LifeBar[i].sprite = QuartHeart;
                        break;
                }
            if ((i * 4) >= lifepoints)
                LifeBar[i].sprite = EmptyHeart;
        }
    }

    public void Death()
    {
        if (lifepoints <= 0)
        {
            playerAnim.SetBool("IsDead", true);
        }
    }

    public void MakeDead()
    {
        endText = endTextLoose;
        EndGame();
    }

    public void EndGame()
    {
        endGameUIText.text = endText;
        endCG.alpha = 1;
        Destroy(gameObject.transform.root.gameObject, 0.2f);
    }
}
