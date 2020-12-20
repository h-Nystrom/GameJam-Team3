using Patient;
using UnityEngine;

namespace Patients{
    public class HospitalScript : MonoBehaviour{
        [SerializeField] VoidEvent inZoneEvent;

        void OnTriggerStay(Collider other){
            if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
                return;
            if (other.GetComponent<Rigidbody>().velocity.magnitude < 0.2f)
                inZoneEvent?.Invoke();
        }
    }
}
