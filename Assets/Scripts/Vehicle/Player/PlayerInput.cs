using UnityEngine;
namespace Vehicle.Player{
    
    public class PlayerInput : MonoBehaviour, ICarHandler{

        Vector2 direction;
        float handBreak;
        public Vector2 Direction => direction;
        public float HandBreak => handBreak;

        void Update(){
            direction = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
            if (Input.GetAxis("Jump") == 0){
                if(handBreak <= 1)
                    handBreak += 0.5f * Time.deltaTime;
            }
            else{
                handBreak = 0.01f;
            }
                
        }
    }

    public interface ICarHandler{
        Vector2 Direction{
            get;
        }

        float HandBreak{
            get;
        }
    }
}


