using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour{

    //----------MENU INTERFACE----------
    public void Play(){
        SceneManager.LoadScene("Levels");
    }
    public void Quit(){
        Application.Quit();
    }


    //----------LEVEL INTERFACE---------- 
    public void Lvl1(){
        SceneManager.LoadScene("Lvl1");
    }
    public void Lvl2(){
        SceneManager.LoadScene("Lvl2");
    }
    public void Lvl3(){
        SceneManager.LoadScene("Lvl3");
    }
    public void Lvl4(){
        SceneManager.LoadScene("Lvl4");
    }
    public void Lvl5(){
        SceneManager.LoadScene("Lvl5");
    }


    //----------GAME OVER INTERFACE----------
    void OnTriggerEnter2D(){
        SceneManager.LoadScene("GameOver");
    }
    public void Levels(){
        SceneManager.LoadScene("Levels");
    }
    public void Menu(){
        SceneManager.LoadScene("Main_Menu");
    }
}