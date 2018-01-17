using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    AbilityCaster abilityCaster;
    PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        playerStats = GetComponent<PlayerStats>();
        abilityCaster = GameObject.Find("AbilityCaster").GetComponent<AbilityCaster>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("FirstAbility_P"+playerStats.playerIndex))
        {
            abilityCaster.UseAbility(gameObject, GetComponent<PlayerStats>().character.abilities[2]);
        }
	}
}
