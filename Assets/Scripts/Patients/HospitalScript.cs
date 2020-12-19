using System;
using System.Collections;
using System.Collections.Generic;
using Patient;
using UnityEngine;

public class HospitalScript : MonoBehaviour{
    [SerializeField] VoidEvent inZoneEvent; 
    void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
            inZoneEvent?.Invoke();
        }
    }
}
