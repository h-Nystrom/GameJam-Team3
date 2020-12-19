using UnityEngine;

namespace CameraFollow{
    public class CameraFollow : MonoBehaviour
    {
        // Use this for initialization
        public Transform target;
        public float followSpeed = 0.125f;
        void FixedUpdate()
        {
            Vector3 desiredPos = target.position;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, followSpeed);
            transform.position = smoothedPos;
        }
    }
}

