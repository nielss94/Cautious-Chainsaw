using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviour {

    public Character character;
    
    public void SetCharacter(Character c)
    {
        character = c;
        GetComponent<Text>().text = c.name;
    }
    
}
