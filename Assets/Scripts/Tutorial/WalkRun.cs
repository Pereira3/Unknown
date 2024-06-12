using UnityEngine;

public class Tutorial : MonoBehaviour{
    public GameObject[] actions;
    private int n;

    void Update(){
        for(int i = 0; i < actions.Length; i++){
            if(i == n){
                actions[i].SetActive(true);
            }else{
                actions[i].SetActive(false);
            }
        }
        
        if(n == 0){
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
                n++;
            }
        }else if(n == 1){
            if(Input.GetKey(KeyCode.LeftShift)){
                n++;
            }
        }
    }
}
