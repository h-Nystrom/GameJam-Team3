using System;
using Vehicle.Player;
using UnityEngine;

namespace Vehicle{
    [RequireComponent(typeof(Rigidbody))]
    public class CarMovement : MonoBehaviour{
        [SerializeField] CarSo carSo;
        ICarHandler carHandler;
        [SerializeField] bool onGround;
        [SerializeField] bool onGroundSlide;
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
            OnGround();
            OnLanding();
            if (!onGround)
                return;
            OnHandBreak();
            OnMove(carHandler.Direction);
        }

        void OnHandBreak(){
            if(onGroundSlide)
                return;
            if (carHandler.Direction.x >= 0f){
                rb.AddForce(-sideSpeed * transform.right * carHandler.HandBreak, ForceMode.VelocityChange);
                if (carHandler.Direction.x == 0 && carHandler.HandBreak < 0.1f)
                    rb.velocity *= 0.96f;
            }
            else{
                rb.AddForce(-sideSpeed * transform.right, ForceMode.VelocityChange);
            }
        }

        void OnLanding(){
            if(!onGroundSlide)
                return;
            rb.AddForce((-sideSpeed * transform.right * 0.005f), ForceMode.VelocityChange);
            rb.velocity *= 0.96f;
            if (sideSpeed == Mathf.Clamp(sideSpeed, -1, 1) || forwardSpeed > 15)
                onGroundSlide = false;
        }

        void OnMove(Vector2 direction){
            if (forwardSpeed == Mathf.Clamp(forwardSpeed, -10, 25))
                rb.AddForce(transform.forward * carHandler.Direction.x * carSo.Speed, ForceMode.Acceleration);
            var turningSpeed = (forwardSpeed * 0.5f) * carHandler.Direction.y;
            rb.AddTorque(transform.up * turningSpeed * carSo.TurnSpeed, ForceMode.Acceleration);

        }

        void OnGround(){
            Debug.DrawRay(transform.position,-transform.up * raycastLenght);
            if (Physics.Raycast(transform.position, -transform.up, out hit, raycastLenght,1 << LayerMask.NameToLayer("Default"))){
                if(!onGround) 
                    onGroundSlide = true;
                onGround = true;
                rb.angularDrag= startAngularDrag;
            }
            else{
                onGround = false;
                rb.angularDrag = 5;
            }
                
        }
    }
}

