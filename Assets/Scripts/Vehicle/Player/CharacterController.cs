using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float handling;
    Rigidbody rb => GetComponent<Rigidbody>();
    Vector3 moveDirection;
    
    
    void Start()
    {
        
    }
    void Update(){
        moveDirection = new Vector3(Input.GetAxis("Vertical"), 0,Input.GetAxis("Vertical"));
        
    }

    void FixedUpdate(){
        OnMove(moveDirection);
    }

    void OnMove(Vector3 moveDir){
        //rb.velocity
    }
}
