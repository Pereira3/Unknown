using UnityEngine;

public class EDoor : MonoBehaviour{

    public GameObject character, internalDoorLocked, internalDoorUnlocked, dialog, ground;
    private bool triggered = false;
    [HideInInspector] public int nstorys, nstorysL4K, nstorysL4T;
    private float dialogtime = 8.0f;

    //AUDIO
    public AudioSource doors;
    
    void Update(){
        if(triggered && Input.GetKeyDown(KeyCode.Q)){
            doors.Play();
            //LEVEL 3
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "Jail"){
                character.transform.position = new Vector3(50f, 16.85f, 0.0f);
            }
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "InsideJailUnlocked"){
                character.transform.position = new Vector3(0.0f, 14.9f, 0.0f);
                ground.SetActive(true);
            }
            //LEVEL 4
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "Kitchen"){
                character.transform.position = new Vector3(60f, 20f, 0.0f);
            }
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "InsideKUnlocked"){
                character.transform.position = new Vector3(34.1f, -0.13f, 0.0f);
            }
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "Training"){
                character.transform.position = new Vector3(95f, 20f, 0.0f);
            }
            if(gameObject.GetComponentInChildren<SpriteRenderer>().name == "InsideTUnlocked"){
                character.transform.position = new Vector3(47.1f, -0.13f, 0.0f);
            }
        }

        if(nstorys == 3){
            dialogtime -= Time.deltaTime;
            dialog.SetActive(true);
        }

        if(nstorysL4K == 2){
            dialogtime -= Time.deltaTime;
            dialog.SetActive(true);
        }
        if(nstorysL4T == 2){
            dialogtime -= Time.deltaTime;
            dialog.SetActive(true);
        }

        if(dialogtime < 0){
            dialogtime = -2.0f;
            dialog.SetActive(false);
            internalDoorLocked.SetActive(false);
            internalDoorUnlocked.SetActive(true);
        }
    }

    void OnTriggerEnter2D(){
        triggered = true;
    }
    void OnTriggerExit2D(){
        triggered = false;
    }
}
