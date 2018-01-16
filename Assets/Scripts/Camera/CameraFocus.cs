using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour {

    [SerializeField]private GameObject[] players;
    public float lerpSpeed;

    void Start()
    {
        Invoke("FindPlayers", 3);
        transform.position = new Vector3(GameObject.Find("SpawnPos").transform.position.x, GameObject.Find("SpawnPos").transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if(players.Length > 0)
        {
            float x = 0;
            float y = 0;
            foreach(GameObject t in players)
            {
                x += t.transform.position.x;
                y += t.transform.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(x / players.Length, y / players.Length, transform.position.z), lerpSpeed * Time.deltaTime);
        }
    }

    public void FindPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
