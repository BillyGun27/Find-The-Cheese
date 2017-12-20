using UnityEngine;
using System.Collections;

public class CatChase : MonoBehaviour {
    Animator Anim;
    Rigidbody2D rb;
    GamePoint Point;

	// Use this for initialization
	void Start () {
        Point = FindObjectOfType<GamePoint>();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
     //   Patrol();
	
	}

  //  void Patrol() {
        //rb.velocity = new Vector2(0, -1);
        //  transform.Translate(new Vector2(0,-1)*2f*Time.deltaTime);

   // }
  // void OnTriggerEnter2D(Collider2D other) {
   //     if(other.tag == "Player") {
     //       other.transform.position = new Vector2(0, -6.5f);
       // }
    //}

    void OnTriggerStay2D(Collider2D other) {
        switch (other.tag) {
            case "Up":
                Anim.SetFloat("Turn", 0);
                transform.eulerAngles = new Vector2(180, 0);
                rb.velocity = new Vector2(0, 1)*Point.CatSpeed;
                break;
            case "Down":
                Anim.SetFloat("Turn", 0);
               transform.eulerAngles = new Vector2(0, 0);
                rb.velocity = new Vector2(0, -1)*Point.CatSpeed;
                break;
            case "Left":
                Anim.SetFloat("Turn", 1);
                transform.eulerAngles = new Vector2(0, 180);
                rb.velocity = new Vector2(-1, 0)*Point.CatSpeed;
                break;
            case "Right":
                Anim.SetFloat("Turn", 1);
                transform.eulerAngles = new Vector2(0, 0);
                rb.velocity = new Vector2(1, 0)*Point.CatSpeed;
                break;
        }
    }
    

   // void Direction()

}
