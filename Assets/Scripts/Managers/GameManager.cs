using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public static GameManager instance;

	void Start () {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);		
	}

    public void StartGame()
    {
        List<Character> characters = new List<Character>();
        foreach(PlayerSlot slot in GameObject.Find("Canvas").GetComponent<MenuController>().playerSlots)
        {
            if(slot.character != null)
                characters.Add(slot.character);
        }
        SceneManager.LoadScene("Game");
        StartCoroutine(SpawnPlayers(characters));
    }

    IEnumerator SpawnPlayers(List<Character> characters)
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject go = Instantiate(player, new Vector2(10,4), Quaternion.identity);
            PlayerStats ps = go.GetComponent<PlayerStats>();
            go.GetComponent<SpriteRenderer>().sprite = characters[i].sprite;
            ps.playerIndex = i + 1;
            ps.name = "Player " + i;
            ps.character = characters[i];
        }
    }
	
}
