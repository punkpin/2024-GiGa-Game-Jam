using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseCanvas;
    private bool isPaused = false;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
            if(Keyboard.current.escapeKey.wasPressedThisFrame){
                if(!isPaused){
                    pauseCanvas.SetActive(true);
                    Time.timeScale = 0f;
                    isPaused = true;
                }else{
                    pauseCanvas.SetActive(false);
                    Time.timeScale = 1f;
                    isPaused = false;
                }    
            } 
    }

    public void GameOver(){
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart(){
        SceneManager.LoadScene(1);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }
}
