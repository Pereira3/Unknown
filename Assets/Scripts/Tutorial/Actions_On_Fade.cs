using UnityEngine;

public class Actions_On_Fade : MonoBehaviour{
    public GameObject presswf; //Press while Faded
    private bool triggered = false;
    private int pressed = 0;

    void Update(){
        if (triggered){
            presswf.SetActive(true);
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift)){
                pressed = 1;
            }
        }
        if(pressed == 1){
            presswf.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        triggered = false;
        presswf.SetActive(false);
    }
}
