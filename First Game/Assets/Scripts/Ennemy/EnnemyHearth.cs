using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHearth : MonoBehaviour {

    Animator EnnemyAnim;

    public int numOfHeart;
    public int maxLifePoints;
    public int lifepoints;

    public Transform coin;
    public Transform potion;
    Vector2 position;
    public GameObject ennemyHurt;

    // Use this for initialization
    void Start () {
        EnnemyAnim = GetComponent<Animator>();
        maxLifePoints = numOfHeart * 4;
        lifepoints = maxLifePoints;
        position = new Vector2(transform.position.x, transform.position.y);
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void TakeDamage(int d)
    {
        lifepoints += d;
        Death();
    }
    public void Death()
    {
        if (lifepoints <= 0)
        {
            EnnemyAnim.SetBool("IsDead", true);
            MakeDead();
        }
    }
    public void MakeDead()
    {
        for (int i = 0; i < 1 + Random.value * 2; i++)
        {
            Instantiate(coin, position, Quaternion.identity);
        }
        for (int i = 0; i < Random.value * 2; i++)
        {
            Instantiate(potion, position, Quaternion.identity);
        }
        Instantiate(ennemyHurt, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.2f);
    }
}