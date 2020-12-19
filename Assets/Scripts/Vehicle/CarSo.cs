using UnityEngine;

namespace Vehicle{
    
    [CreateAssetMenu(fileName = "NewCar", menuName = "CarData")]
    public class CarSo : ScriptableObject{
        [SerializeField] float speed;
        [SerializeField] float turnSpeed;
        [SerializeField] float handling;
        public float Speed => speed;

        public float TurnSpeed => turnSpeed;
    }
}
