using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleurDeRotation : MonoBehaviour {

	private Transform ownTransform;
	// Use this for initialization
	void Start () {
		ownTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float inputY = Input.GetAxis ("Horizontal");
		//Quaternion aroundY = Quaternion.AngleAxis (inputY,Vector3.up);
		//Debug.Log ("en x " + inputX);
		float inputX = Input.GetAxis ("Vertical");
		//Quaternion aroundX = Quaternion.AngleAxis (inputX,Vector3.right);
		//Debug.Log ("en y " + inputY);

		//ownTransform.Rotate(new Vector3(inputX,inputY,0));
		//ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation, aroundY * aroundX, 1000);

		Vector3 angles = ownTransform.rotation.eulerAngles;
		ownTransform.rotation = Quaternion.Euler (new Vector3(-inputX + angles.x,angles.y + inputY,0));
		//Quaternion euler = Quaternion.Euler (new Vector3(inputX,inputY,0));
		//ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation, ownTransform.rotation * euler, 1000);

	}
}
