using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Parkerhill {
    /// <summary>
    /// CameraVRMode
    /// </summary>
	public class CameraVRMode : MonoBehaviour {

		[SerializeField]
		private static bool vrEnabled;

        // ------------------------------------------------

        void Awake() {
			ReadVRMode ();
		}

        // ------------------------------------------------

        public static void SetVRMode(bool enabled, bool save = true)
        {
            vrEnabled = enabled;
            if (save) SaveVRMode();
        }
        public static bool GetVRMode()
        {
            return vrEnabled;
        }

		public static void SaveVRMode() {
			PlayerPrefs.SetInt ("SaveVRMode", (vrEnabled ? 1 : 0));
		}

		public static void ReadVRMode() {
			Debug.Log ("ReadVRMode: " + PlayerPrefs.GetInt ("VRMode"));
            vrEnabled = (PlayerPrefs.GetInt ("VRMode") == 1);
		}
	}
}