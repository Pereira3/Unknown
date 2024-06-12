using UnityEngine;

public class SoloDialog : MonoBehaviour{
    
    public GameObject ground, dialog;
    private bool triggered = false;
    private float dialogtime = 5.0f;

    void Update(){
        if(triggered){
            dialogtime -= Time.deltaTime;
        }
        if(dialogtime < 0){
            dialogtime = 5.0f;
            dialog.SetActive(false);
        }
    }

    void OnTriggerEnter2D(){
        
        if(dialog.name == "FD"){
            dialog.SetActive(true);
        }else{
            dialog.SetActive(true);
            triggered = true;
        }

    }
    void OnTriggerExit2D(){
        if(dialog.name == "FD"){
            dialog.SetActive(false);
        }
    }
}
