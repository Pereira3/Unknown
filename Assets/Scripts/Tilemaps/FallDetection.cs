using UnityEngine;

public class FallDetection : MonoBehaviour{
    public GameObject signal;
    void OnTriggerEnter2D(){
        signal.SetActive(true);
    }
    void OnTriggerStay2D(){
        signal.SetActive(true);
    }
    void OnTriggerExit2D(){
        signal.SetActive(false);
    }
}
