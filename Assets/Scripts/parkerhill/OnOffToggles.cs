using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Parkerhill {
	public class OnOffToggles : MonoBehaviour {
		public string player_pref;
		public Toggle on_toggle;
		public Toggle off_toggle;

		[SerializeField]
		private bool on_enabled;

		private string cname = "OnOffToggles";

		void Awake() {
			load_settings ();
			if (on_enabled)
				on_toggle.isOn = true;
			else
				off_toggle.isOn = true;
		}

		public void set_on() {
			Debug.Log (cname+":set_on");
			on_enabled = true;
			save_settings ();
		}

		public void set_off() {
			Debug.Log (cname+":set_off");
			on_enabled = false;
			save_settings ();
		}

		// private methods

		private void save_settings() {
			PlayerPrefs.SetInt (player_pref, (on_enabled ? 1 : 0));
		}

		private void load_settings() {
			on_enabled = (PlayerPrefs.GetInt (player_pref) == 1);
		}
	} 
}
