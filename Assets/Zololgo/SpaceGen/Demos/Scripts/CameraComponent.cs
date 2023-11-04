using UnityEngine;

class CameraComponent : MonoBehaviour {
	// variables
	public float speed = 0.1f;
	public Vector2 zoomLimits = new Vector2(1,10);
	public bool turnableOn = false;

	Vector2 touchDeltaPosition;
	float zoom;

	void Update () {

		// basic rotation controls for mobile, please note there is no zoom implemented.
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {

			touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			updateRotation ();
			
		}

		// left mousehold to rotate
		if (Input.GetMouseButton(0)) {

			touchDeltaPosition.x = speed * Input.GetAxis ("Mouse X");
			touchDeltaPosition.y = -speed * Input.GetAxis ("Mouse Y");
			updateRotation ();
			
		}
		// right mousehold to zoom
		else if (Input.GetMouseButton(1)) {

			zoom = speed * Input.GetAxis ("Mouse Y");
			updateZoom ();
			
		}
		// slow turntable animation on idle
		else if (turnableOn) {
		
			transform.Rotate (Vector3.up* speed/100, Space.World);
		
		}
		
	}

	// function for rotation
	void updateRotation () {

		transform.Rotate (Vector3.right * touchDeltaPosition.y * speed, Space.Self);
		transform.Rotate (Vector3.up * touchDeltaPosition.x * speed, Space.World);

	}

	// function for zoom
	void updateZoom (){

		transform.localScale += new Vector3(zoom,zoom,zoom);
		transform.localScale = new Vector3( 
			Mathf.Clamp (transform.localScale.x, zoomLimits.x, zoomLimits.y),
			Mathf.Clamp (transform.localScale.y, zoomLimits.x, zoomLimits.y),
			Mathf.Clamp (transform.localScale.z, zoomLimits.x, zoomLimits.y)
		);
	}
}