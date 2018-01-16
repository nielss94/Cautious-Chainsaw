using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    private bool canJump = true;
    private PlayerStats playerStats;
    [SerializeField]private float airTime;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal_P" + playerStats.playerIndex);
        float jump = Input.GetAxis("Jump_P" + playerStats.playerIndex);
        if (move != 0)
        {
            if (move > .1)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (move < -0.1)
                GetComponent<SpriteRenderer>().flipX = true;

            transform.Translate(move * Time.deltaTime * (playerStats.character ? playerStats.character.moveSpeed : 1), 0, 0);
        }
        if(jump > 0 && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerStats.character.jumpHeight), ForceMode2D.Impulse);
        }
	}

    void Update()
    {
        if (!canJump)
            airTime += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 50);
        
        if (Vector2.Distance(transform.position, hit.point) < 1.2 && !canJump && airTime > 0.5f)
        {
            canJump = true;
            airTime = 0;
        }
    }

    
}
