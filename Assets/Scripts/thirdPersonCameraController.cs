using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCameraController : MonoBehaviour{

	public float turnSpeed = 4f;
	private GameObject parentPlayer;
	private float yOffset = 4f;
	private float zOffset = -6f;

	private float targetDistance;
	private float rotX;

	public float minTurnAngle = -85f;
	public float maxTurnAngle = 0f;

	private void Awake() {
		parentPlayer = transform.parent.GetChild(1).gameObject;
		transform.position = new Vector3(parentPlayer.transform.position.x, parentPlayer.transform.position.y + yOffset, parentPlayer.transform.position.z + zOffset);
		targetDistance = Vector3.Distance(transform.position, parentPlayer.transform.position);
	}

	private void Update() {
		if (GetComponent<Camera>().enabled) {

			if (GameManagerController.enableJoyCamera) {
				float y = Input.GetAxis("Joy Y");
				rotX += Input.GetAxis("Joy X");

				transform.eulerAngles = new Vector3(rotX, transform.eulerAngles.y + y, 0);

				transform.position = parentPlayer.transform.position - (transform.forward * targetDistance);

			}
			else {
				float y = Input.GetAxis("Mouse X") * turnSpeed;
				rotX += Input.GetAxis("Mouse Y") * turnSpeed;

				rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

				transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

				transform.position = parentPlayer.transform.position - (transform.forward * targetDistance);
			}
		}
	}


}
