using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the collisions of the ghost in the light.
 */
public class TorchlightCollisions : MonoBehaviour {

	public int nbSpheres;
	public float maxDistance;
	public string nomDeLaCouche;
	public Light spotlight;

	private int masque;
	private float rayonDuCercleRef;
	private float distanceDuCercleRef;

	// Use this for initialization
	void Start () {
		string[] noms = new string[] {nomDeLaCouche };
		masque = LayerMask.GetMask (noms);
		if (nbSpheres == 0)
			nbSpheres = 4;
		if (maxDistance == 0)
			maxDistance = 10000;

//		float angleCone = spotlight.spotAngle;
//		distanceDuCercleRef = spotlight.range;
//		rayonDuCercleRef = distanceDuCercleRef * Mathf.Abs (Mathf.Tan (angleCone * Mathf.PI / 180));
//		Debug.Log ("rayon du cercle " + rayonDuCercleRef);
//		Debug.Log ("distance du cercle " + distanceDuCercleRef);
	}
	
	// Update is called once per frame
	void Update () {
		//lanceDeSpheres ();
	}

	private void lanceDeSpheres(){


		float angleCone = spotlight.spotAngle;
		distanceDuCercleRef = spotlight.range;
		rayonDuCercleRef = distanceDuCercleRef * Mathf.Abs (Mathf.Tan (angleCone * Mathf.PI / 180));

		Vector3 origine = this.transform.position;
		float rayonDesSpheres = rayonDuCercleRef / 2;
		Vector3 versAvant = spotlight.transform.forward;

		float pas = 2*Mathf.PI / nbSpheres;
		float angleCourant = 0;
		Vector3 directionCourante = new Vector3 ();
		HashSet<Collider> enContact = new HashSet<Collider> ();

			for (int i = 0; i < nbSpheres; i++) {
				//calcul du vecteur direction
				angleCourant = pas * i;
				directionCourante = distanceDuCercleRef * versAvant + 0.5f * new Vector3 (Mathf.Cos (angleCourant), Mathf.Sin (angleCourant));
				//resultat du raycast
				RaycastHit[] resultatCast = Physics.SphereCastAll (origine, rayonDesSpheres, directionCourante, maxDistance, masque);

				//ajout dans l ensemble
				foreach (RaycastHit hit in resultatCast) {
					Collider colliderTouche = hit.collider;
					enContact.Add (colliderTouche);
				}
			}

	}
}
