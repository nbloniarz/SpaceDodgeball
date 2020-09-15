using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureLevel : MonoBehaviour{

	private float splitScreenSize;
	private List<GameObject> playerList;
	public GameObject PlayerPrefab;

	private void Awake() {
		playerList = new List<GameObject>();
		splitScreenSize = 1 / GameManagerController.numberOfPlayers;
		for(int i = 0; i < GameManagerController.numberOfPlayers; i++) {
			GameObject newPlayer = GameObject.Instantiate(PlayerPrefab);
			switch (i) {
				case 1:
					newPlayer.transform.position = new Vector3(2*newPlayer.transform.position.x, newPlayer.transform.position.y, newPlayer.transform.position.z);
					break;
				case 2:
					newPlayer.transform.position = new Vector3(newPlayer.transform.position.x, newPlayer.transform.position.y, 2*newPlayer.transform.position.z);
					break;
				case 3:
					newPlayer.transform.position = new Vector3(2 * newPlayer.transform.position.x, newPlayer.transform.position.y, 2*newPlayer.transform.position.z);
					break;
					break;
			}
			newPlayer.name = "Player: " + (i+ 1);
			playerList.Add(newPlayer);
		}
		Debug.Log("Number of players: " + playerList.Count);
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
