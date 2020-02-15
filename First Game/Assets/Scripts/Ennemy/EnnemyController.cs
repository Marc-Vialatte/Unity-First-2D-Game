using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour {

    Rigidbody2D ennemyRB;
    Animator EnnemyAnim;

    public float speed;
    float move;
    float distance;
    public float stoppingDistance;
    public float maxDistanceView;
    public float retreatDistance;
    public float minDistanceShoot;

    private float timeBtwAttack;
    public float starTimeBtwAttack;

    public Transform player;

    bool canMove = true;
    bool canAttack = true;
    bool damage = false;
    public bool attack = false;

    SpriteRenderer ennemyRenderer;
    bool facingLeft = true;

    public Transform fireball;

    // Use this for initialization
    void Start () {
        EnnemyAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwAttack = starTimeBtwAttack;
        ennemyRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        EnnemyAnim.SetBool("IsAttack", false);
        EnnemyAnim.SetBool("IsCast", false);

        if (player != null && canMove != false)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < maxDistanceView)
            {
                move = speed * Time.deltaTime;
                distance = Vector2.Distance(transform.position, player.position);
                if (distance < 0 && facingLeft == false)
                    Flip();
                if (distance > 0 && facingLeft == false)
                    Flip();

                transform.position = Vector2.MoveTowards(transform.position, player.position, move);
                EnnemyAnim.SetFloat("MoveSpeed", move);
            }
            else if (Vector2.Distance(transform.position, player.position) <= stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance || Vector2.Distance(transform.position, player.position) < maxDistanceView))
            {
                move = 0;
                transform.position = this.transform.position;
                EnnemyAnim.SetFloat("MoveSpeed", move);
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                move = -speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, move);
                EnnemyAnim.SetFloat("MoveSpeed", move);
            }
            if (timeBtwAttack <= 0 && canAttack == true && Vector2.Distance(transform.position, player.position) <= stoppingDistance && Vector2.Distance(transform.position, player.position) < minDistanceShoot)
            {
                EnnemyAnim.SetBool("IsAttack", true);
                timeBtwAttack = starTimeBtwAttack;
            }
            else if (timeBtwAttack <= 0 && canAttack == true && Vector2.Distance(transform.position, player.position) <= stoppingDistance && Vector2.Distance(transform.position, player.position) > minDistanceShoot)
            {
                EnnemyAnim.SetBool("IsCast", true);
                for (int i = 0; i <  2 + Random.value * 8; i++)
                {
                    Vector2 position = new Vector2(transform.position.x + Random.Range(-22.0f, -2.0f), transform.position.y + 15.0f + Random.Range(5.0f, 0.0f));
                    Instantiate(fireball, position, Quaternion.identity);
                }
                timeBtwAttack = starTimeBtwAttack;
            }
            else
                timeBtwAttack -= Time.deltaTime;
        }
        else
        {
            move = 0;
            transform.position = this.transform.position;
            EnnemyAnim.SetFloat("MoveSpeed", move);
        }
    }

    public void ToggleCanMove()
    {
        canMove = !canMove;
    }

    public void TogglecanAttack()
    {
        canAttack = !canAttack;
    }

    public void ToggleDamage()
    {
        damage = !damage;
    }
    public bool GetDamage()
    {
        return damage;
    }
    public void ToggleAttack()
    {
        attack = !attack;
    }
    void Flip()
    {
        facingLeft = !facingLeft; // On change la valeur du boolen facing right par son contraire, représentant la direction du personnage
        ennemyRenderer.flipX = !ennemyRenderer.flipX; // Même chose ici pour que notre flipx et facingRight soient en phase
        ennemyRB.MoveRotation(ennemyRB.velocity.y * 180); // Rotation complete du gameObject
    }
}