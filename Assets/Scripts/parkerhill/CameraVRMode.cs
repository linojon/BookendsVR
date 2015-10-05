using UnityEngine;
using UnityEngine.VR;
using System.Collections;

namespace Parkerhill {
    /// <summary>
    /// CameraVRMode
    ///     Oculus devices: Unity built-in "Virtual Reality Supported" must be initially checked in the Player Settings
    ///     Cardboard sdk: assume cardboard when "CardboardMain" object enabled (and "Virtual Reality Supported" unchecked)
    /// JSL 10/4/2015
    /// </summary>
	public class CameraVRMode : MonoBehaviour { // static?

        private static bool vrSupported = false;
		private static bool vrEnabled = false;
        private static GameObject googleCardboard = null;

        // ------------------------------------------------

        void Awake() {
            Debug.Log("HELLO");
            Debug.Log(Application.platform.ToString());
#if (UNITY_ANDROID || UNITY_IPHONE)
            // cardboard camera and sdk
            googleCardboard = GameObject.Find("CardboardMain");
#endif
            if (googleCardboard != null)
            {
                Debug.Log("found CardboardMain");
                vrSupported = true;
            } else
            {   // built in oculus support
                vrSupported = VRSettings.enabled;
            }

            if (vrSupported)
            {
                ReadVRMode(); // read mode from PlayerPrefs
                SetVRMode(vrEnabled, false); // initial vr camera mode, no need to save it
            } else
            {
                Debug.Log("Virtual Reality Supported checkbox is not checked");
                vrSupported = false;
                vrEnabled = false;
            }
        }

        // ------------------------------------------------

        public static void SetVRMode(bool enabled, bool save = true)
        {
            vrEnabled = vrSupported && enabled;
            Debug.Log("SetVRMode to " + enabled);
            if (googleCardboard == null)
                VRSettings.enabled = vrEnabled;
            else
                Cardboard.SDK.VRModeEnabled = vrEnabled;
            if (save) SaveVRMode();
        }

        public static bool GetVRSupported()
        {
            return vrSupported;
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