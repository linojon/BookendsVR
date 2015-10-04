using UnityEngine;
using System.Collections;

namespace Parkerhill
{
    /// <summary>
    /// CameraLockPosition class will lock the camera position to the its starting position in the scene
    /// Correlates with the positional tracking ability of the current HMD
    /// Note: not related to locomotion which should be handled in a parent object of the camera
    /// TODO: make this a singleton
    /// TODO: compiler directives when Cardboard
    /// </summary>
    public class CameraLockPosition : MonoBehaviour
    {
        public bool lockPositionX, lockPositionY, lockPositionZ;

        private bool lockPosition;

        [SerializeField]
        private Vector3 startPosition;

        //--------------------------------

        void Start()
        {
            lockPosition = lockPositionX || lockPositionY || lockPositionZ;
            if (lockPosition)
            {
                startPosition = Camera.main.transform.position;
            }
        }

        void Update()
        {
            if (lockPosition)
            {
                ResetCameraPosition();
            }
        }

        //--------------------------------

        public bool IsLockPosition()
        {
            return lockPosition;
        }

        //--------------------------------

        private void ResetCameraPosition()
        {
            //Vector3 pos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            Vector3 pos = Camera.main.transform.position;
            if (lockPositionX) pos.x = startPosition.x;
            if (lockPositionY) pos.y = startPosition.y;
            if (lockPositionZ) pos.z = startPosition.z;
            Camera.main.transform.position = pos;
        }
    }
}