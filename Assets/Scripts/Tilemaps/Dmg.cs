using UnityEngine;
using UnityEngine.SceneManagement;

public class Dmg : MonoBehaviour{
    private bool isPressed;

    void Update(){
        //IN FADE MODE -> NO GAME OVER
        if(Input.GetKey(KeyCode.L)){
            isPressed = true;
        }else{
            isPressed = false;
        }
    }

    void OnTriggerEnter2D(){
        if(!isPressed){
            SceneManager.LoadScene("GameOver");
        }
    }
    void OnTriggerStay2D(){
        if(!isPressed){
            SceneManager.LoadScene("GameOver");
        }
    }
}
