using UnityEngine;

public class Jump : MonoBehaviour{
    public GameObject pressspace;
    private bool triggered = false;
    private int pressed = 0;

    void Update(){
        if (triggered){
            pressspace.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)){
                pressed = 1;
            }
        }
        if(pressed == 1){
            pressspace.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        triggered = false;
        pressspace.SetActive(false);
    }
}
