using UnityEngine;
using System.Collections;

public class ScooterController : MonoBehaviour {

	public float acceleration;
	public float rotationRate;

	public float jumpForce;
	public float jumpCooldown;

	public float turnRotationAngle;
	public float turnRotationSeekSpeed;

	private float rotationVelocity;
	private float groundingAngleVelocity;

	private bool jumping = false;
	private float jumpTimer;
	private bool grounded = false;


	// Update is called once per frame
	void FixedUpdate () {
		//checks to see if we're "grounded"
		if (Physics.Raycast (transform.position, transform.up * -1, 3f)) {
			grounded = true;
			GetComponent<Rigidbody>().drag = 1;

			Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis ("Vertical");
			forwardForce = forwardForce * Time.deltaTime * GetComponent<Rigidbody>().mass;
			GetComponent<Rigidbody>().AddForce (forwardForce);
		} else {
			grounded = false;
			GetComponent<Rigidbody>().drag = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space) && grounded && !jumping) {
			jumping = true;
			jumpTimer = 0f;

			Vector3 upwardForce = transform.up * (jumpForce * 1000) * Input.GetAxis ("Jump");
			//Debug.Log (upwardForce);
			upwardForce = upwardForce * Time.deltaTime * GetComponent<Rigidbody> ().mass;
			GetComponent<Rigidbody> ().AddForce (upwardForce);
		} else if (jumpTimer < jumpCooldown) {
			jumpTimer += .1f;
			if(jumpTimer >= jumpCooldown)
			{
				jumping = false;
			}
		} else if(jumpTimer >= jumpCooldown)
		{
			jumping = false;
		}

		Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis ("Horizontal");

		turnTorque = turnTorque * Time.deltaTime * GetComponent<Rigidbody>().mass;
		GetComponent<Rigidbody> ().AddTorque (turnTorque);

		Vector3 newRotation = transform.eulerAngles;
		newRotation.z = Mathf.SmoothDampAngle (newRotation.z, Input.GetAxis ("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
		transform.eulerAngles = newRotation;
	}
}
