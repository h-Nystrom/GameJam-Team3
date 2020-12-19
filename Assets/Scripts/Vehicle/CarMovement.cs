using System;
using Player;
using UnityEngine;

namespace Vehicle{
    [RequireComponent(typeof(Rigidbody))]
    public class CarMovement : MonoBehaviour{
        [SerializeField] CarSo carSo;
        ICarHandler carHandler; 
        Rigidbody rb => GetComponent<Rigidbody>();

        void Awake(){
            carHandler = GetComponent<ICarHandler>();
        }

        void FixedUpdate(){
            OnMove(carHandler.Direction);
        }
        void OnMove(Vector2 direction){
            //MaxSpeed
            rb.AddForce(transform.forward * carHandler.Direction.x * carSo.Speed);
            
        }
    }
}

