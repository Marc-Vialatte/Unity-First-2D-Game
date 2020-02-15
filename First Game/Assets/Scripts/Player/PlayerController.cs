using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB; // Propriété qui tiendra en référence le rigid body de notre player
    Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator
    SpriteRenderer playerRenderer; // Propriété qui tiendra la référence du sprite rendered de notre player
    bool facingRight = true; // Par défaut, notre player regarde à droite
    public float maxSpeed; // Vitesse maximale que notre player peut atteindre en se déplacant
                           // Use this for initialization
    public bool grounded = false; // Valeur qui traque si l'utilisateur est au sol ou non
    public float groundCheckRadius = 0.2f; // Raduis du cercle pour tester si l'utilisateur est en contact avec le sol(Peut etre change en fonction des assets)
    public LayerMask groundLayer; // Référence au layer avec lequel nous allons checker la colision
    public Transform groundCheck; // Référence au GroundCheckLocation que nous avons déini dans le KnightPlayer
    public float jumpPower; // Force avec laquelle nous allons projeter notre personnage en l'air
    public bool canMove = true; // Valeur qui traque si l'utilisateur peut bouger
    public bool canAttack = true;

    public GameObject Jump;
    //public GameObject Fall;
    public GameObject Hit;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du même objet
        playerAnim = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();// Récupérer le component sprite renderer en dessous de cette ligne
    }
    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("IsAttack", false);

        float move = Input.GetAxis("Horizontal");
        // Rédiger ci dessous le code permettant de déerminer quand le player doit se retourner
        if (canMove)
        {
            if (move < 0 && facingRight == true)
                Flip();
            if (move > 0 && facingRight == false)
                Flip();

            playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
            playerAnim.SetFloat("MoveSpeed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
        }

        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y); // Si movement non autorise, on arrete la velocite 
            playerAnim.SetFloat("MoveSpeed", 0); // on arrete aussi l'animation en cours si on etait en train de courir
        }

        if (grounded && Input.GetAxis("Jump") > 0 && canMove)
        {
            // On verifie si l'utilisateur est au sol, et si l'input jump est en appui
            playerAnim.SetBool("IsGrounded", false); // On defini le parametre danimation IsGrounded a faux car nous nous aprettons a sauter
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f); // On defini la velocite y a 0 pour etre sur d'avoir la même hauteur quelque soit le contexte
            playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // On ajoute de la force sur notre rigidbody afin de le faire s'envoler, on precise bien un forcement a impulse pour avoir toute la force d'un seul coup
            grounded = false; // On defini notre grounded a false pour garder en memoire l'etat du personnage
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // on utilise ici notre moteur physique pour crér un petit cercle àn endroit bien precis(position du ground check personnage)
        // On defini aussi son radius pour dessiner le cercle
        // Et on defini le layer sur lequel on veut checker l'overlap
        // Si le cercle overlap avec le ground layer, ç va nous renvoyer vrai, car le player est au sol
        // Sinon cela veut dire que le personnage est en l'air
        // Cela va nous permetre aussi de declencer la condition permettant d'appliquer la force sur notre personnage
        playerAnim.SetBool("IsGrounded", grounded); // On utilise donc cette information pour mettre a jour note animator

        if (Input.GetAxis("Fire1") > 0 && grounded && canAttack)
        {
            playerAnim.SetBool("IsAttack", true);

        }

        if (Input.GetAxis("Fire2") > 0 && grounded && canAttack)
        {
            if (GetComponent<PlayerHearth>().lifepoints <= GetComponent<PlayerHearth>().maxLifePoints && GetComponent<PlayerInventory>().Potions > 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    gameObject.GetComponent<PlayerHearth>().LifePoint(1);
                    gameObject.GetComponent<PlayerInventory>().SubPotions();
                }
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, représentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // Même chose ici pour que notre flipx et facingRight soient en phase
        playerRB.MoveRotation(playerRB.velocity.y * 180); // Rotation complete du gameObject
    }

    public void ToggleCanMove()
    {
        canMove = !canMove;
    }

    public void TogglecanAttack()
    {
        canAttack = !canAttack;
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            playerRB.AddForce(new Vector3(knockbackDir.x * 100, knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }

    public void ActJump()
    {
        Instantiate(Jump, transform.position, Quaternion.identity);
    }
    public void ActHit()
    {
        Instantiate(Hit, transform.position, Quaternion.identity);
    }
}