
using UnityEngine;

public class Audio : MonoBehaviour{

    public AudioSource ambMusic;
    public static Audio existence_ambmusic;

    void Awake(){
        //If the Ambient Music was not created
        if(!existence_ambmusic){
            existence_ambmusic = this;
            DontDestroyOnLoad(gameObject);
        }else{ //Avoid having multiple Ambient Musics playing at the same time
            Destroy(gameObject);
        }
    }
    void Start(){
        ambMusic.Play();
    }
}
