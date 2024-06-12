using UnityEngine;

public class Lever : MonoBehaviour{
    public GameObject leverpushed, levernpushed;
    private bool triggered = false;
    public bool leverPushed = false;

    //AUDIO
    public AudioSource door;

    void Update(){
        if(Input.GetKeyDown(KeyCode.W) && triggered){
            door.Play();
            leverpushed.SetActive(true);
            levernpushed.SetActive(false);
            leverPushed = true;
        }
    }

    void OnTriggerEnter2D(){
        triggered = true;
    }
    void OnTriggerExit2D(){
        triggered = false;
    }
}
