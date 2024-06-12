using UnityEngine;

public class Fade : MonoBehaviour{
    public GameObject pressctrl;
    private bool triggered = false;
    private int pressed = 0;

    void Update(){
        if (triggered){
            pressctrl.SetActive(true);
            if(Input.GetKeyDown(KeyCode.L)){
                pressed = 1;
            }
        }
        if(pressed == 1){
            pressctrl.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        triggered = false;
        pressctrl.SetActive(false);
    }
}
