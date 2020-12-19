using System;
using UnityEngine;
using UnityEngine.Events;

namespace Patient{
    [System.Serializable]
    public class VoidEvent : UnityEvent{}
    public class PatientsScript : MonoBehaviour{
        [SerializeField] VoidEvent pickUpEvent;
        [SerializeField] VoidEvent deathEvent;
        [SerializeField] VoidEvent addPatientEvent;
        bool isSick;
        bool isDead;

        void Awake(){
            addPatientEvent?.Invoke();
        }

        public bool IsSick{
            get => isSick;
            set => isSick = value;
        }

        void OnTriggerStay(Collider other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                if (!isDead && isSick && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.05f){
                    pickUpEvent?.Invoke();
                    Destroy(this.gameObject);
                }
            }
        }
        void OnCollisionEnter(Collision other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                if(isDead) return;
                isDead = true;
                deathEvent?.Invoke();
                Destroy(this.gameObject,5f);
            }
        }
    }
}

