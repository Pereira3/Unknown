using UnityEngine;
using UnityEngine.SceneManagement;

//Was using the Dmg Code File but if the character was faded it would not load the GameOver Scene
public class GameOver : MonoBehaviour{
    void OnTriggerEnter2D(){
        SceneManager.LoadScene("GameOver");
    }
    void OnTriggerStay2D(){
        SceneManager.LoadScene("GameOver");
    }
    void OnTriggerExit2D(){
        SceneManager.LoadScene("GameOver");
    }
}
