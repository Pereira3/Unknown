using TMPro;
using UnityEngine;

public class Character : MonoBehaviour{

    private bool bc_direction = false; //Base Character Direction

    //Movement
    [Header("\nMovement")]
    public int bspeed = 2; //Base Speed
    public int sspeed = 4; //Sprint Speed
    public Vector2 mdirection; //Move Directions
    
    //Char & Animations
    [Header("\nCharacter/Animations")]
    public Rigidbody2D rb;
    public BoxCollider2D cc;
    public Animator animator;
    private bool isFading = false, isJumping = false, isCrouching = false;
    public Transform sprite;
    //Crouch Control
    private bool triggered = false;
    private float timeCrouch = 0.08f;
    public GameObject positionfaded;

    //Diamonds
    [Header("\nDiamonds")]
    public int dquantity = 0;
    public TextMeshProUGUI dCount;

    //Audio
    [Header("\nAudio")]
    private float stepsDelay = 0;
    public AudioSource walking;
    public AudioSource crouching;
    public AudioSource fadingIn;
    public AudioSource fadingOut;

    //Esc Control
    [Header("\nPAUSE")]
    public GameObject pauseScene;
    private bool EscPressed = false;

    void Start(){
        sprite = transform.Find("Unknown");
        dquantity = 0;
    }

    bool IsMoving(){
        return rb.velocity.x != 0f;
    }
    bool JumpingUp(){
        return rb.velocity.y > 0.1f;
    }

    bool IsGrounded(){
        return rb.velocity.y == 0;
    }
    // Changing the Value of pause Scene clicking on Resume
    public void falsEsc(){
        EscPressed = false;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseScene.SetActive(true);
            EscPressed = true;
        }

        if(EscPressed){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
            // Update the coordenates directions in the moviment array
            mdirection.x = Input.GetAxisRaw("Horizontal");
            mdirection.y =  Input.GetAxisRaw("Vertical");

            if(animator.GetInteger("Knock") == 0){
                //Move Character
                if(!Input.GetKey(KeyCode.LeftShift)){ //Walking
                    rb.velocity = new Vector2(bspeed * mdirection.x, rb.velocity.y);
                }else{ //Running
                    rb.velocity = new Vector2(sspeed * mdirection.x, rb.velocity.y);
                }

                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
                    rb.velocity = new Vector2(rb.velocity.x, 7.5f);
                }

                C_Direction(mdirection.x);
                C_Animations();
            }

            //LEVEL 2 ANIMATION
            // Bugged, if u walk before the knock it will continue without this piece of code
            if(animator.GetInteger("Knock") == 1 && IsGrounded()){
                rb.velocity = new Vector2(0, 0);
            }else if(animator.GetInteger("Knock") == 1 && !IsGrounded()){ //In case the animation is in the middle of the jump
                rb.velocity = new Vector2(0, -10f);
            }
        }
    }
    
    //Function in charge of changing the animations based on Animation Speed variable
    void C_Animations(){
        if(IsMoving()){
            if(Input.GetKey(KeyCode.LeftShift)){ //Running

                stepsDelay += Time.deltaTime;
                //Avoid Looping the Audio
                if (!isFading && !isJumping && !isCrouching && IsMoving() && stepsDelay > 0.3f){
                    stepsDelay = 0;
                    walking.Play();
                }
                //Step sound Crouching
                if(!isFading && !isJumping && isCrouching && IsMoving() && stepsDelay > 0.3f){
                    stepsDelay = 0;
                    crouching.Play();
                }

                animator.SetFloat("Speed", 1);

            }else{ //Walking

                stepsDelay += Time.deltaTime;
                //Avoid Looping the Audio
                if (!isFading && !isJumping && !isCrouching && IsMoving() && stepsDelay > 0.35f){
                    stepsDelay = 0;
                    walking.Play();
                }
                //Step sound Crouching
                if(!isFading && !isJumping && isCrouching && IsMoving() && stepsDelay > 0.35f){
                    stepsDelay = 0;
                    crouching.Play();
                }
                animator.SetFloat("Speed", 0.5f);

            }
        }else{ //Idle
            animator.SetFloat("Speed", 0);
        }

        if(Input.GetKey(KeyCode.Space) && JumpingUp()){ //Going Upward
            isJumping = true;
            animator.SetInteger("Jumping", 1);
        }else if(!JumpingUp()){ //Start Goind Down
            animator.SetInteger("Jumping", 0);
            //If the other inputs are not declared as true, it will continue to play the audio when he is grounded
            if(IsGrounded()){
                isJumping = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.S) || (triggered && IsGrounded())){
            isCrouching = true;
            //DECREASING COLIDER
            cc.offset = new Vector2(cc.offset.x, -0.058498f);
            cc.size = new Vector2(cc.size.x, 0.2005498f);
            animator.SetInteger("Crouch", 1);
        }else if((Input.GetKeyUp(KeyCode.S) || (!Input.GetKey(KeyCode.S) && !triggered && IsGrounded())) &&  animator.GetInteger("Crouch") == 1){
            //RETURN COLIDER
            cc.offset = new Vector2(cc.offset.x, -0.02691872f);
            cc.size = new Vector2(cc.size.x, 0.2736809f);
            animator.SetInteger("Crouch", 2);
        }
        if(animator.GetInteger("Crouch") == 2){
            isCrouching = false;
            timeCrouch -= Time.deltaTime;
            if(timeCrouch < 0){
                timeCrouch = 0.08f;
                animator.SetInteger("Crouch", 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.L)){
            fadingIn.Play();
            isFading = true;
            animator.SetInteger("Fading", 1);
            //CHARACTER ICON
            positionfaded.SetActive(true);
        }else if(Input.GetKeyUp(KeyCode.L)){
            fadingOut.Play();
            isFading = false;
            animator.SetInteger("Fading", 2);
            //CHARACTER ICON
            positionfaded.SetActive(false);
        }else{
            animator.SetInteger("Fading", 0);
        }

        if(Input.GetKeyDown(KeyCode.W)){
            animator.SetBool("Interaction", true);
        }else{
            animator.SetBool("Interaction", false);
        }
    }

    //Function in charge of changing the directions of the Character in x axis
    void C_Direction(float x){
        //Character Change Direction
        if((bc_direction == false && x < 0f) || (bc_direction == true && x > 0f)){
            bc_direction = !bc_direction; 
            sprite.localScale = new Vector3(sprite.localScale.x * -1, sprite.localScale.y, sprite.localScale.z);
        }
    }
    
    //Check if the character have something blocking the stand
    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.name == "Ground"){
            triggered = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.name == "Ground"){
            triggered = false;
        }
    }
}
