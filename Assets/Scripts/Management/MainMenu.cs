using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Hàm gọi từ UI Button
    public void PlayGame()
    {
        Debug.Log("PlayGame() được gọi - đang chuyển sang scene index 1");
        SceneManager.LoadSceneAsync(1);
    }
}
