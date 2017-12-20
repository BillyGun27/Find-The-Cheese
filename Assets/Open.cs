using UnityEngine;
using System.Collections;

public class Open : MonoBehaviour {
    Animator Anim;
    public RandomItem ri;
    float wait= 15;
    bool opened = false;
    int RoundedWait;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
        ri = ri.GetComponent<RandomItem>();
	}
	
    void FixedUpdate() {
        if (opened == true) {
            wait -= Time.deltaTime;
            RoundedWait = Mathf.RoundToInt(wait);
            specialItem(wait);
           // Debug.Log(RoundedWait);
            if (RoundedWait < 0) {
                Anim.SetBool("Open", false);
                opened = false;
                wait = 15;
            }
        }
        
    }
    void specialItem(float open) {
        Vector2 Obtain = transform.position;
        if(wait >= 14.5) {
            ri.ItemAppear(Obtain);
        }

    }
    
    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Key") {
            Anim.SetBool("Open",true);
            opened = true;
        }
    }

}
