using UnityEngine;
using System.Collections;

namespace Parkerhill {
	public class TransitionActions : MonoBehaviour {
		/*
		 * before you can load a level you have to add it to the build scenes list
		 * 
		 * 
		 */
		public string nextLevel;

		public void QuitApp() {
			Debug.Log ("QuitApp");
			Application.Quit ();
		}

		public void LoadNextLevel() {
			Application.LoadLevel (nextLevel); 
		}
	}
}