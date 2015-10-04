using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Parkerhill
{
    /// <summary>
    /// CameraVRModeActions
    /// version for use with UI checkbox toggles, behaves like radios
    /// </summary>
	public class CameraVRModeActions : MonoBehaviour
    {
        public Toggle vrModeToggle;
        public Toggle flatModeToggle;

        void Awake()
        {
            if (vrModeToggle != null)
                vrModeToggle.isOn = CameraVRMode.GetVRMode();
            if (flatModeToggle != null)
                flatModeToggle.isOn = !CameraVRMode.GetVRMode();
        }

        public void EnableVRMode()
        {
            Debug.Log("EnableVRMode");
            CameraVRMode.SetVRMode(true);
        }

        public void DisableVRMode()
        {
            Debug.Log("DisableVRMode");
            CameraVRMode.SetVRMode(false);
        }

    }
}