using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCameraController : MonoBehaviour{

	public float horzTurnSpeed = 2f;
	public float vertTurnSpeed = 4f;
	private GameObject parent;
	private Vector3 offset;
	public float verticalOffset = 4f;
	public float distanceOffset = -6f;
	public float minYHeight = 0.25f;

    // Start is called before the first frame update
    void Start(){
		offset = new Vector3(parent.transform.localPosition.x, parent.transform.localPosition.y + verticalOffset, parent.transform.localPosition.z + distanceOffset);
		transform.position = offset;
		transform.LookAt(parent.transform.position);
	}

    // Update is called once per frame
    void LateUpdate()
    {
		if (GetComponent<Camera>().enabled) {
			float x_rot = Input.GetAxis("Mouse X") * horzTurnSpeed;
			float y_rot = Input.GetAxis("Mouse Y") * vertTurnSpeed;

			Vector3 angles = transform.eulerAngles;
			angles.z = 0;
			transform.eulerAngles = angles;
			transform.RotateAround(parent.transform.position, Vector3.up, x_rot);
			transform.RotateAround(parent.transform.position, Vector3.right, y_rot);
			if(transform.position.y < minYHeight) {
				transform.position = new Vector3(transform.position.x, minYHeight, transform.position.z);
			}
			transform.LookAt(parent.transform.position);

			//parent.transform.forward = transform.forward;
		}
    }

	private void Awake() {
		parent = transform.parent.gameObject;
	}
}
