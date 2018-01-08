using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterOption : MonoBehaviour {

    public Character character;

    void Start()
    {
        GetComponent<Image>().sprite = character.sprite;
    }
}
