using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public List<Character> characters = new List<Character>();
    public List<PlayerSlot> playerSlots = new List<PlayerSlot>();
    public bool[] connectedPlayers = new bool[4];

    public Image selector;
    public Image[] selectors = new Image[4];
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Input.GetAxisRaw("Jump_P" + (i + 1)) != 0)
            {
                if (connectedPlayers[i] == false)
                    ConnectPlayer(i);
                else
                    print("player " + (i + 1) + " already connected");
            }


            if (Input.GetAxisRaw("NextSelect_P" + (i + 1)) != 0)
            {
                if (connectedPlayers[i] == false)
                    ConnectPlayer(i);
                else
                {
                    if((selectors[i].transform.parent.GetSiblingIndex() + 1) > transform.Find("CharacterPanel").childCount - 1)
                    {
                        print("first char");
                        selectors[i].rectTransform.SetParent(transform.Find("CharacterPanel").GetChild(0));
                    }else
                    {
                        print("next char");
                        selectors[i].rectTransform.SetParent(selectors[i].transform.parent.parent.GetChild(selectors[i].transform.parent.GetSiblingIndex() + 1));
                    }
                    selectors[i].rectTransform.localPosition = new Vector3(0, 0, 0);
                    playerSlots[i].SetCharacter(selectors[i].transform.parent.GetComponent<CharacterOption>().character);
                }
                    
            }
        }
    }

    void DisconnectPlayer(int i)
    {
        connectedPlayers[i] = false;
        print("Player " + (i + 1) + " disconnected!");
    }

    void ConnectPlayer(int i)
    {
        connectedPlayers[i] = true;
        selectors[i] = Instantiate(selector, transform.Find("CharacterPanel").GetChild(0));
        switch(i)
        {
            case 0:
                selectors[i].color = Color.green;
                break;
            case 1:
                selectors[i].color = Color.blue;
                break;
            case 2:
                selectors[i].color = Color.blue;
                break;
            case 3:
                selectors[i].color = Color.magenta;
                break;
        }
        playerSlots[i].SetCharacter(transform.Find("CharacterPanel").GetChild(0).GetComponent<CharacterOption>().character);
    }
}
