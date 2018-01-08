using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability  {

    public Abilities ability;

    [Range(0,10)]public float cooldown;
    [Range(1, 5)]public float power;
}
