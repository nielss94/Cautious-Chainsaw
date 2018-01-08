using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    public List<GameObject> projectilePool;

    void Start()
    {
    }

    public void Fire(Abilities ability, GameObject owner)
    {
        switch (ability)
        {
            case Abilities.FireBall:
                CastFireBall(owner);
                break;
        }
    }

    private void CastFireBall(GameObject abilityOwner)
    {
        Vector3 castPos;
        Quaternion castRot = new Quaternion(0,0,0,0);
        if (abilityOwner.GetComponent<SpriteRenderer>().flipX == true)
        {
            castPos = new Vector3(abilityOwner.transform.position.x - 1, abilityOwner.transform.position.y, 0);
        }
        else
        {
            castPos = new Vector3(abilityOwner.transform.position.x + 1, abilityOwner.transform.position.y, 0);
            castRot = new Quaternion(0, 180, 0, 0);
        }
        
        GameObject proj = Instantiate(projectilePool[(int)Abilities.FireBall], castPos, castRot) as GameObject;
        proj.GetComponent<Fireball>().player = abilityOwner;
        //TODO: List of projectile objects, instantiate object towards player direction
    }
}
