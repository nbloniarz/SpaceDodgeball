using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonCameraController : MonoBehaviour{

	/*public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;*/

	public float horizontalSpeed = 1f;
	public float verticalSpeed = 1f;
	private float xRotation = 0.0f;
	private float yRotation = 0.0f;
	private GameObject parentPlayer;
	private Camera cameraComponet;

	void Update() {
		if (cameraComponet.enabled) { 
			float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
			float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

			yRotation += mouseX;
			xRotation -= mouseY;
			xRotation = Mathf.Clamp(xRotation, -90, 90);

			transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

			parentPlayer.transform.forward = transform.forward;
		}

		/*if (axes == RotationAxes.MouseXAndY) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else {
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}*/
	}

	void Start() {
		// Make the rigid body not change rotation
		/*if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;*/
	}

	private void Awake() {
		parentPlayer = transform.parent.gameObject;
		cameraComponet = GetComponent<Camera>();
	}
}
