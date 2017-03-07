using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPumpkin : MonoBehaviour {

	private Light light;
	private SphereCollider collider;

	// Use this for initialization
	void Start () {

		StartCoroutine (FindLight());


	}

	IEnumerator FindLight() {
		
		yield return new WaitForSeconds (0.5f);

		if (GameObject.FindGameObjectWithTag ("torchLight").activeInHierarchy) {

			light = GameObject.FindGameObjectWithTag ("torchLight").GetComponent<Light> ();
			collider = GetComponent<SphereCollider> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (collider && light) {
			
			Vector3 pos = transform.position + collider.center;
			Vector3 lightPos = light.transform.position;

			Vector3 lightToPump = (pos - lightPos).normalized;
			Vector3 forwardVector = light.transform.forward;

			if (Vector3.Dot (lightToPump, forwardVector) > Mathf.Cos (light.spotAngle * Mathf.PI / 360)) {
				GetComponent<GhostStatus> ().m_Health--;
				SteamVR_Controller.Input ((int)light.GetComponent<SteamVR_TrackedObject> ().index).TriggerHapticPulse (2000);
			}
		}
	}
}
