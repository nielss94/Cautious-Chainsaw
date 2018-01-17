﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public GameObject player;
    public float speed;
    public int baseDamage;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
