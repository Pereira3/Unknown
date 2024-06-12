using UnityEngine;

public class PDoor : MonoBehaviour{
    
    //DOOR LOCKED
    public GameObject dialog;
    private bool triggered = false;

    //DOOR UNLOCKED / TRASNFORMATION
    public GameObject doorLocked, doorOpenned, character;

    //Change the variable that controls the lvl exit
    public Lever leverState;

    void Update(){
        if (triggered && Input.GetKeyDown(KeyCode.Q)){
            if(!leverState.leverPushed){
                dialog.SetActive(true);
            }else{
                character.transform.position = new Vector3(-15.3f, 14.86f, 0f);
            }
        }

        if(leverState.leverPushed){
            doorLocked.SetActive(false);
            doorOpenned.SetActive(true);
        }
    }

    void OnTriggerEnter2D(){
        triggered = true;
    }

    void OnTriggerExit2D(){
        triggered = false;
        dialog.SetActive(false);
    }

}
