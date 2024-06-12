using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour{

    public GameObject ground, ground2, diamond, diamond2;
    private bool timeRunning = false;
    private float timeLeft = 10.0f;

    // Level 4 Time
    private float timeLeftLvl4 = 4.0f;

    //AUDIO
    public AudioSource gd, gddestroyed;

    void OnTriggerEnter2D(Collider2D collider){
        if(gameObject.GetComponent<TilemapRenderer>().name == "GD_L4"){
            // Reset the timer when entering again in the Ground Tile
            timeRunning = false;
            timeLeftLvl4 = 4.0f;

            // Play the sound of the the ground discovery
            gd.Play();
            // Ground falling -> TRAP
            ground.SetActive(false);
            ground2.SetActive(true);
            if(diamond){
                diamond.SetActive(true);
            }
        }else if(gameObject.GetComponent<TilemapRenderer>().name == "GD2_L4"){
            // Ground falling -> TRAP
            ground.SetActive(false);
            ground2.SetActive(true);
            if(diamond){
                diamond.SetActive(true);
            }
        }else{
            // Reset the timer when entering again in the Ground Tile
            ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,1f);
            timeRunning = false;
            timeLeft = 10.0f;

            // Play the sound of the the ground discovery
            gd.Play();
            ground.SetActive(true);
            if(diamond){
                diamond.SetActive(true);
            }
            if(diamond2){
                diamond2.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        timeRunning = true;
    }

    void Update(){

        if(timeRunning){
            if(gameObject.GetComponent<TilemapRenderer>().name == "GD_L4"){
                // 4 seconds
                timeLeftLvl4 -= Time.deltaTime;
            }else{
                // 10 seconds
                timeLeft -= Time.deltaTime;
            }
        }

        if(gameObject.GetComponent<TilemapRenderer>().name == "GD_L4"){
            if(timeLeftLvl4 < 0){
                gddestroyed.Play();
                ground.SetActive(true);
                ground2.SetActive(false);
                timeRunning = false;
                timeLeftLvl4 = 4.0f;
            }
        }else{
            //Platform Time Control based on Aplha Values
            if(((int)timeLeft) == 4){
                ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,0.8f);
            }
            if(((int)timeLeft) == 3){
                ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,0.6f);
            }
            if(((int)timeLeft) == 2){
                ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,0.4f);
            }
            if(((int)timeLeft) == 1){
                
                ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,0.2f);
            }

            if(timeLeft < 0){
                gddestroyed.Play();
                ground.SetActive(false);
                ground.GetComponentInChildren<Tilemap>().color = new Color(1f,1f,1f,1f);
                if(diamond){
                    diamond.SetActive(false);
                }
                if(diamond2){
                    diamond2.SetActive(false);
                }
                timeRunning = false;
                timeLeft = 10.0f;
            }
        }
    }
}
