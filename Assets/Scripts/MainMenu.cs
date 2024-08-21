using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("BallDropGame");
    }

    public void Exit(){
        Application.Quit();
    }
}
