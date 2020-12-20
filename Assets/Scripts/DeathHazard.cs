using Patient;
using UnityEngine;

public class DeathHazard : MonoBehaviour{
    [SerializeField] StringEvent gameOverEvent;

    void GameOver(){
        gameOverEvent?.Invoke("Mission failed!");
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
            Invoke(nameof(GameOver),1);
        }
    }
}
