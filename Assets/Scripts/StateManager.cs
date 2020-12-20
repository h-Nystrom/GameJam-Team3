using Patient;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour{
    bool pause;
    [SerializeField] Canvas pauseMenu, startMenu, GameOverMenu;
    [SerializeField] StringEvent gameOverEvent;

    void Start(){
        Time.timeScale = 0;
        startMenu.enabled = true;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void Pause(){
        pause = !pause;
        pauseMenu.enabled = pause;
        Time.timeScale = pause ? 0 : 1;
    }
    public void StartGame(){
        startMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void GameOver(string gameOverText){
        print("GameOver");
        gameOverEvent?.Invoke(gameOverText);
        GameOverMenu.enabled = true;
        Time.timeScale = 0;
    }
}
