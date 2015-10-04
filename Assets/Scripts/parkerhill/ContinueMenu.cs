using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinueMenu : MonoBehaviour {
	public Button continueButton;
	public int nextLevel = 1;

	void Start () {
		continueButton = continueButton.GetComponent<Button> ();
	}
	

	public void ContinuePress() {
		Application.LoadLevel (nextLevel);
	}
}
