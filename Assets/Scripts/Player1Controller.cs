using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {
	//Camera Control Vars
	private Camera firstPersonCamera;
	private Camera thirdPersonCamera;
	private bool isFirstPerson;

	//Player Movement Vars
	private CharacterController controller;
	//First Person Movement Vars
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	public float playerSpeed = 2.0f;
	public float jumpHeight = 1.0f;
	public float gravityValue = -9.81f;
	
	//Third Person Movement Vars


	// Start is called before the first frame update
	void Start() {

		//Sets up camera controls for player, makes thrid person default.
		Camera[] camList = GetComponentsInChildren<Camera>();
		foreach (Camera aCam in camList) {
			if(aCam.name == "1st Person Camera") {
				firstPersonCamera = aCam;
			}
			else {
				thirdPersonCamera = aCam;
			}
		}
		isFirstPerson = false;
		firstPersonCamera.enabled = false;
		thirdPersonCamera.enabled = true;

		//Config character movement componet
		controller = gameObject.GetComponent<CharacterController>();
		
	}

	// Update is called once per frame
	void Update() {
		
		//Handles camera toggle check
		#region CameraToggle 
		if (Input.GetButtonDown("togglePlayerCamera")) {//"c"
			ToggleCamera();
		}
		#endregion

		//Toggles movement system based on camera
		if (isFirstPerson) {
			float x = Input.GetAxisRaw("Horizontal");
			float z = Input.GetAxisRaw("Vertical");
			groundedPlayer = controller.isGrounded;

			if (groundedPlayer && playerVelocity.y < 0) {
				playerVelocity.y = 0f;
			}

			Vector3 moveDirection = (transform.forward * z + transform.right * x) * playerSpeed * Time.deltaTime;
			controller.Move(moveDirection);


			if (Input.GetButton("Jump") && groundedPlayer) {
				playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			}

			playerVelocity.y += gravityValue * Time.deltaTime;
			controller.Move(playerVelocity * Time.deltaTime);

			
		}
		else {
			float x = Input.GetAxisRaw("Horizontal");
			float z = Input.GetAxisRaw("Vertical");
			groundedPlayer = controller.isGrounded;

			if (groundedPlayer && playerVelocity.y < 0) {
				playerVelocity.y = 0f;
			}

			Vector3 moveDirection = (thirdPersonCamera.transform.forward*z + thirdPersonCamera.transform.right * x) * playerSpeed * Time.deltaTime;
			
			controller.Move(moveDirection);
			if (Input.GetButton("Jump") && groundedPlayer) {
				playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			}

			playerVelocity.y += gravityValue * Time.deltaTime;
			controller.Move(playerVelocity * Time.deltaTime);
		}

	}

	/*Controls toggling between first person and third person camera for player characters */
	void ToggleCamera() {
		if (isFirstPerson) {

			thirdPersonCamera.enabled = true;
			firstPersonCamera.enabled = false;
			isFirstPerson = false;
			
		}
		else {
			thirdPersonCamera.enabled = false;
			firstPersonCamera.enabled = true;
			isFirstPerson = true;
		}
	}

	//Handles triggerboxes
	private void OnTriggerExit(Collider other) {
		//Signals if out of bounds
		if(other.tag == "KillVolume") {
			Debug.Log("LEFT KILL VOLUME");
		}
	}

	/*
	 * 
	 * //Movement Vars
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	public float playerSpeed = 2.0f;
	public float jumpHeight = 1.0f;
	public float gravityValue = -9.81f;
	
	 //Handles player movement
		#region FirstPersonPlayerMovement
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0) {
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		controller.Move(move * Time.deltaTime * playerSpeed);

		if (move != Vector3.zero) {
			gameObject.transform.forward = move;
		}

		// Changes the height position of the player..
		if (Input.GetButton("Jump") && groundedPlayer) {
			Debug.Log("JUMP");
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);

		#endregion

		#region ThirdPersonPlayerMovement
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0) {
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		controller.Move(move * Time.deltaTime * playerSpeed);

		if (move != Vector3.zero) {
			gameObject.transform.forward = move;
		}

		// Changes the height position of the player..
		if (Input.GetButton("Jump") && groundedPlayer) {
			Debug.Log("JUMP");
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);

		#endregion
	 */
}
