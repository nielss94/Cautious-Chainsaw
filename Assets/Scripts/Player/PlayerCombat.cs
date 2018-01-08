using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    AbilityCaster abilityCaster;

	// Use this for initialization
	void Start () {
        abilityCaster = GameObject.Find("AbilityCaster").GetComponent<AbilityCaster>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            abilityCaster.UseAbility(gameObject, GetComponent<PlayerStats>().character.abilities[2]);
        }
	}
}
