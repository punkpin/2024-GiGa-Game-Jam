using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // 标记游戏是否已经开始  
    private bool gameStarted = false;

    void Update()
    {
        // 如果游戏尚未开始，并且检测到任意键被按下  
        if (!gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // 标记游戏为已开始  
        gameStarted = true;

        SceneManager.LoadScene(1);
        Debug.Log("游戏开始！");
    }

    /*public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }*/

    //退出
    /*public void OnExitGame()
    {
        Application.Quit();
    }*/
}
