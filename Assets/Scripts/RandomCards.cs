using UnityEngine;
using System.Collections;

public class RandomCards : MonoBehaviour {
	public GameObject card;
	public Vector3 start = new Vector3( 0f, 3.5f, 0f);
	public Vector3 posVariant = Vector3.one * 0.1f;
	public Vector3 rotVariant = Vector3.zero;
	public float fireInterval = 1f;
	public float maxCards = 10f;

	void Start () {
//		DropCard ();
		StartCoroutine (DropCardWithDelay ());	
	}

	IEnumerator DropCardWithDelay() {
		while (true) {
			DropCard ();
			yield return new WaitForSeconds (fireInterval);
		}
	}

	void DropCard() {
//		Debug.Log ("Dropping card");
		Vector3 position = new Vector3 (start.x + Random.Range (-posVariant.x, posVariant.x),
		                                start.y + Random.Range (-posVariant.y, posVariant.y),
		                                start.z + Random.Range (-posVariant.z, posVariant.z));
		Vector3 euler = new Vector3 (Random.Range (-rotVariant.x, rotVariant.x),
		                               Random.Range (-rotVariant.y, rotVariant.y),
		                               Random.Range (-rotVariant.z, rotVariant.z));
		Quaternion rotation = Quaternion.identity;
		rotation.eulerAngles = euler;
		var newCard = Instantiate (card, position, rotation);
		Destroy (newCard, fireInterval * maxCards);
	}
}
