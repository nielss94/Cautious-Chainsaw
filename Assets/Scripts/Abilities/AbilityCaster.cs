using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCaster : MonoBehaviour {

    public static AbilityCaster instance;

    [SerializeField]
    private List<GameObject> activeProjectiles = new List<GameObject>();

    private Projectiles projectiles;
    
	void Start () {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        projectiles = GetComponent<Projectiles>();
	}

    public void UseAbility(GameObject player, Ability ability)
    {
        switch (ability.abilityType)
        {
            case AbilityType.Environment:
                break;
            case AbilityType.Melee:
                break;
            case AbilityType.Projectile:
                projectiles.Fire(ability.ability, player);
                break;
            case AbilityType.Self:
                print(" asdasdsadsa ");
                break;
        }
    }
}
