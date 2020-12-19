using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float handling;
    Rigidbody rb => GetComponent<Rigidbody>();
    
    public void OnTurn(float angle){
        
    }

    public void OnMove(float direction){
        
    }
}
