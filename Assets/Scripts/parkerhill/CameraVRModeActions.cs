using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Parkerhill
{
    /// <summary>
    /// CameraVRModeActions
    /// version for use with UI checkbox toggles, behaves like radios
    /// JSL 10/4/2015
    /// </summary>
	public class CameraVRModeActions : MonoBehaviour
    {
        public Toggle vrModeToggle;
        public Toggle flatModeToggle;

        void Start()
        {
            if (vrModeToggle != null)
                vrModeToggle.isOn = CameraVRMode.GetVRMode();
            if (flatModeToggle != null)
                flatModeToggle.isOn = !CameraVRMode.GetVRMode();
        }

        public void EnableVRMode()
        {
            if (vrModeToggle.isOn)
            {
                Debug.Log("EnableVRMode");
                CameraVRMode.SetVRMode(true);
            }
        }

        public void DisableVRMode()
        {
            if (flatModeToggle.isOn)
            {
                Debug.Log("DisableVRMode");
                CameraVRMode.SetVRMode(false);
            }
        }
    }
}