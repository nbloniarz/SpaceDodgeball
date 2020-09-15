using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour{

	private static GameManagerController _Instance;

	public static GameManagerController Instance { get { return _Instance; } }
	public static int numberOfPlayers = 1;
	public static int maxPlayers = 4;
	public static bool enableJoyCamera = true;

	private void Awake() {
		if (_Instance == null && _Instance != this) {
			Destroy(this.gameObject);
			return;
		}
		else {
			_Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}
	
}
