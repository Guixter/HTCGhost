using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPumpkin : MonoBehaviour {

	private Light flashlight;
	private SphereCollider pumpkinCollider;

	// Use this for initialization
	void Start () {

		StartCoroutine (FindLight());
	}

	IEnumerator FindLight() {
		
		yield return new WaitForSeconds (0.5f);

		if (GameObject.FindGameObjectWithTag ("torchLight").activeInHierarchy) {

			flashlight = GameObject.FindGameObjectWithTag ("torchLight").GetComponent<Light> ();
			pumpkinCollider = GetComponent<SphereCollider> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (pumpkinCollider && flashlight) {
			
			Vector3 pos = transform.position;// + pumpkinCollider.center;
			Vector3 lightPos = flashlight.transform.position;

			Vector3 lightToPump = (pos - lightPos).normalized;
			Vector3 forwardVector = flashlight.transform.forward;
			bool centerIsInCone = Vector3.Dot (lightToPump, forwardVector) > Mathf.Cos (flashlight.spotAngle * Mathf.PI / 360);

			RaycastHit hit;
			bool hitSomething = Physics.Raycast (lightPos, forwardVector, out hit, 10.0f);

			if (centerIsInCone || (hitSomething && hit.transform == transform)) {
				GetComponent<GhostStatus> ().m_Health--;
				SteamVR_Controller.Input ((int)flashlight.GetComponent<SteamVR_TrackedObject> ().index).TriggerHapticPulse (2000);
			}
		}
	}
}
