using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace Patient{
    [System.Serializable]
    public class VoidEvent : UnityEvent{}
    public class PatientsScript : MonoBehaviour{
        [SerializeField] VoidEvent pickUpEvent;
        [SerializeField] VoidEvent deathEvent;
        [SerializeField] VoidEvent addPatientEvent;
        [SerializeField] VoidEvent sickEvent;
        bool isSick;
        bool isDead;

        void Awake(){
            addPatientEvent?.Invoke();
        }

        public bool IsSick{
            get => isSick;
            set{
                sickEvent?.Invoke();
                isSick = value;
            }
        }

        void OnTriggerStay(Collider other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                if (!isDead && isSick && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f){
                    pickUpEvent?.Invoke();
                    Destroy(this.gameObject);
                }
            }
        }
        void OnCollisionStay(Collision other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                print("Collision1");
                if(isDead) return;
                isDead = true;
                deathEvent?.Invoke();
                Destroy(this);
                print("Colllision after");
            }
        }
    }
}

