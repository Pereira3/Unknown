using UnityEngine;

public class Diamond : MonoBehaviour{
    public AudioSource dbreak;
    void OnTriggerEnter2D(Collider2D collider){
        dbreak.Play();
        Destroy(gameObject);
        collider.gameObject.GetComponent<Character>().dquantity++;
        collider.gameObject.GetComponent<Character>().dCount.text = collider.gameObject.GetComponent<Character>().dquantity.ToString();
    }
}
