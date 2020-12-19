using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VirusMovment : MonoBehaviour{
    Rigidbody rb => GetComponent<Rigidbody>();
    Vector3 travelDirection;
    [SerializeField] float speed;

    void Start(){
        transform.rotation = Quaternion.Euler(0,Random.Range(-180f, 180f),0);
    }
    void FixedUpdate(){
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedTime);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall")){
            transform.rotation = Quaternion.Euler(0,transform.localRotation.y - 90,0);
        }   
    }
}
