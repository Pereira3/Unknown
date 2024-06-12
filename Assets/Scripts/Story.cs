using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IHistory : MonoBehaviour{

    public GameObject story, story2, story3, dizzy, pressw;
    private bool triggered = false, interaction = false;

    //AUDIO
    public AudioSource intStory;
    private float memlackDelay = 0;
    public AudioSource memLack;
    
    //LVL 2
    private float timeStory = 5.0f, timeDizzyFade = 6.0f, timePostDizzy = 6.0f;
    public Animator animator;
    public bool knocked = false;  

    //LVL 3
    public EDoor edoor;
    private bool increased = false;

    void Update(){
        //LEVEL 1 -> CHAIN STORY
        if(gameObject.GetComponent<SpriteRenderer>().name == "Story1"){
            if(triggered && !interaction){
                pressw.SetActive(true);
                if(Input.GetKeyDown(KeyCode.W)){
                    intStory.Play();
                    story.SetActive(true);
                    interaction = true;
                    timeStory = 7.0f;
                }
            }else{
                pressw.SetActive(false);
            }

            if(interaction){
                pressw.SetActive(false);
                timeStory -= Time.deltaTime;
            }
            if(timeStory < 0){
                story.SetActive(false);
                timeStory = 7.0f;
            }
        }
        //LEVEL 2 -> FLAG MENTAL EXHAUSTION
        if(gameObject.GetComponent<SpriteRenderer>().name == "Story2"){
            if (triggered && !interaction && Input.GetKeyDown(KeyCode.W)){
                intStory.Play();
                story.SetActive(true);
                interaction = true;
            }

            if(interaction){
                timeStory -= Time.deltaTime;
            }

            //Dizziness for the Memory Break
            if (timeStory < 0 && timeDizzyFade > -2.0f){

                story.SetActive(false);
                story2.SetActive(true);
                
                animator.SetInteger("Knock", 1);
                knocked = true;

                timeDizzyFade -= Time.deltaTime;
                
                if((int)timeDizzyFade == 4){
                    StartCoroutine(FadeIn(2.0f));
                }
                if((int)timeDizzyFade == 2){
                    memlackDelay += Time.deltaTime;
                    if(memlackDelay > 0.35f){
                        memLack.Play();
                        memlackDelay = 0;
                    }
                    StartCoroutine(FadeOut(3.0f));
                }
            }

            //Dizziness Fade Away
            if (timeStory < 0){
                //TO STOP THE DECREASING
                timeStory = -2.0f;
                story2.SetActive(true);
            }
            if(timeDizzyFade < 0){
                //TO STOP THE DECREASING
                timeDizzyFade = -2.0f;
                story2.SetActive(false);
                dizzy.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
                animator.SetInteger("Knock", 0);
                knocked = false;
                story3.SetActive(true);
                timePostDizzy -= Time.deltaTime;
            }
            if(timePostDizzy < 0){
                timePostDizzy = -2.0f;
                story3.SetActive(false);
            }
        }
        //LEVEL 3 -> JAIL MEMORY LACK
        if(gameObject.GetComponent<SpriteRenderer>().name == "Story3"
        || gameObject.GetComponent<SpriteRenderer>().name == "Story4"
        || gameObject.GetComponent<SpriteRenderer>().name == "Story5"){
            if(triggered && Input.GetKeyDown(KeyCode.W)){
                
                intStory.Play();
                story.SetActive(true);
                
                if(!increased){
                    edoor.nstorys += 1;
                    increased = true;
                }
            }
            if(!triggered){
                story.SetActive(false);
            }
        }
        //LEVEL 4
        if(gameObject.GetComponent<SpriteRenderer>().name == "Story6" 
        || gameObject.GetComponent<SpriteRenderer>().name == "Story7"
        || gameObject.GetComponent<SpriteRenderer>().name == "Story8"){
            if(triggered && Input.GetKeyDown(KeyCode.W)){
                intStory.Play();
                story.SetActive(true);
            }
            if(!triggered){
                story.SetActive(false);
            }
        }
        if(gameObject.GetComponent<SpriteRenderer>().name == "StoryK1"
        || gameObject.GetComponent<SpriteRenderer>().name == "StoryK2"){
            if(triggered && Input.GetKeyDown(KeyCode.W)){
                
                intStory.Play();
                story.SetActive(true);
                
                if(!increased){
                    edoor.nstorysL4K += 1;
                    increased = true;
                }
            }
            if(!triggered){
                story.SetActive(false);
            }
        }
        if(gameObject.GetComponent<SpriteRenderer>().name == "StoryT1"
        || gameObject.GetComponent<SpriteRenderer>().name == "StoryT2"){
            if(triggered && Input.GetKeyDown(KeyCode.W)){
                
                intStory.Play();
                story.SetActive(true);
                
                if(!increased){
                    edoor.nstorysL4T += 1;
                    increased = true;
                }
            }
            if(!triggered){
                story.SetActive(false);
            }
        }
        //FINAL
        if(gameObject.GetComponent<SpriteRenderer>().name == "FS"){
            if(triggered && Input.GetKeyDown(KeyCode.W)){
                intStory.Play();
                SceneManager.LoadScene("FINAL");
            }
        }
    }

    void OnTriggerEnter2D(){
        if(!interaction){
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            triggered = true;
        }
    }
    void OnTriggerStay2D(){
        if(interaction){
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f,1f,1f,0f);

            if(gameObject.GetComponentInChildren<SpriteRenderer>().Equals("Story1")){
                pressw.SetActive(false);
            }
        }
    }
    void OnTriggerExit2D(){
        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        triggered = false;

        if(gameObject.GetComponentInChildren<SpriteRenderer>().Equals("Story1")){
            pressw.SetActive(false);
        }
    }

    //LEVEL 2 -> EXHAUSTION EFFECT
    IEnumerator FadeIn(float duration){
        for (float t = 0.0f; t < duration; t += Time.deltaTime){
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(0.0f, 1.0f, t));
            dizzy.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
    IEnumerator FadeOut(float duration){
        for (float t = duration; t > 0.0f; t -= Time.deltaTime){
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(0.0f, 1.0f, t));
            dizzy.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }

}
