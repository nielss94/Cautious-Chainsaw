using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Character character;
    private bool canJump = true;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        character = playerStats.character;
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

            transform.Translate(move * Time.deltaTime * (character ? character.moveSpeed : 1), 0, 0);
        }
        if(jump > 0 && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, character.jumpHeight), ForceMode2D.Impulse);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}
