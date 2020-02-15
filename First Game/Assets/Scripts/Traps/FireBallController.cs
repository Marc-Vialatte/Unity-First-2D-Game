using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public bool grounded = false;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (grounded == true)
        {
            Destroy(gameObject, 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.tag == "Fire")
        {
            collision.gameObject.GetComponent<PlayerHearth>().LifePoint(-1);
            Destroy(gameObject, 0.2f);
        }
    }
}
