using UnityEngine;

public class Crouch : MonoBehaviour{
    public GameObject presss;
    private bool triggered = false;
    private int pressed = 0;

    void Update(){
        if (triggered){
            presss.SetActive(true);
            if(Input.GetKeyDown(KeyCode.S)){
                pressed = 1;
            }
        }
        if(pressed == 1){
            presss.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        triggered = false;
        presss.SetActive(false);
    }
}
