using UnityEngine;
using UnityEngine.SceneManagement;

public class FDoor : MonoBehaviour{
    
    //DOOR LOCKED
    public GameObject dialog, pressq;
    private bool triggered = false;
    private int pressed = 0;
    
    int diamonds;

    //DOOR UNLOCKED / TRASNFORMATION
    public GameObject doorLocked, doorOpenned;

    void Update(){
        if (triggered){
            pressq.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Q)){
                //LEVEL 1
                if(gameObject.name == "FinishDoors1"){
                    if(diamonds < 3){
                        dialog.SetActive(true);
                        pressed = 1;
                    }else{
                        doorLocked.SetActive(false);
                        doorOpenned.SetActive(true);
                        SceneManager.LoadScene("Lvl2");
                        diamonds = 0;
                    }
                }
                //LEVEL 2
                if(gameObject.name == "FinishDoors2"){
                    if(diamonds < 4){
                        dialog.SetActive(true);
                        pressed = 1;
                    }else{
                        doorLocked.SetActive(false);
                        doorOpenned.SetActive(true);
                        SceneManager.LoadScene("Lvl3");
                    }
                }
                //LEVEL 3
                if(gameObject.name == "FinishDoors3"){
                    if(diamonds < 3){
                        dialog.SetActive(true);
                        pressed = 1;
                    }else{
                        doorLocked.SetActive(false);
                        doorOpenned.SetActive(true);
                        SceneManager.LoadScene("Lvl4");
                    }
                }
                //LEVEL 4
                if(gameObject.name == "FinishDoors4"){
                    if(diamonds < 7){
                        dialog.SetActive(true);
                        pressed = 1;
                    }else{
                        doorLocked.SetActive(false);
                        doorOpenned.SetActive(true);
                        SceneManager.LoadScene("Lvl5");
                    }
                }
            }
        }

        if(pressed == 1){
            pressq.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        diamonds = collider.gameObject.GetComponent<Character>().dquantity;
        triggered = true;
        pressed = 0;
    }

    void OnTriggerExit2D(){
        triggered = false;
        dialog.SetActive(false);
        pressq.SetActive(false);
    }

}
