using System;
using Player;
using UnityEngine;

namespace Vehicle{
    [RequireComponent(typeof(Rigidbody))]
    public class CarMovement : MonoBehaviour{
        [SerializeField] CarSo carSo;
        ICarHandler carHandler;
        [SerializeField]bool onGround;
        [SerializeField] float raycastLenght;
        RaycastHit hit;
        float sideSpeed;
        float forwardSpeed;
        float startAngularDrag;
        Rigidbody rb => GetComponent<Rigidbody>();

        void Awake(){
            carHandler = GetComponent<ICarHandler>();
        }

        void Start(){
            startAngularDrag = rb.angularDrag;
        }

        void FixedUpdate(){
            forwardSpeed = Vector3.Dot(rb.velocity, transform.forward);
            sideSpeed = Vector3.Dot(rb.velocity, transform.right);
            rb.AddForce((-sideSpeed * transform.right), ForceMode.VelocityChange);
            OnMove(carHandler.Direction);
            //TODO: Add on ticks return!
            OnGround();
        }

        void OnMove(Vector2 direction){
            //MaxSpeed
            if (!onGround)
                return;
            if (forwardSpeed == Mathf.Clamp(forwardSpeed, -10, 25))
                rb.AddForce(transform.forward * carHandler.Direction.x * carSo.Speed, ForceMode.Acceleration);
            var turningSpeed = (forwardSpeed * 0.5f) * carHandler.Direction.y;
            rb.AddTorque(transform.up * turningSpeed * carSo.TurnSpeed, ForceMode.Acceleration);

        }

        void OnGround(){
            Debug.DrawRay(transform.position,-transform.up * raycastLenght);
            if (Physics.Raycast(transform.position, -transform.up, out hit, raycastLenght,1 << LayerMask.NameToLayer("Default"))){
                onGround = true;
                rb.angularDrag= startAngularDrag;
            }
            else{
                onGround = false;
                rb.angularDrag = 0;
            }
                
        }
    }
}

