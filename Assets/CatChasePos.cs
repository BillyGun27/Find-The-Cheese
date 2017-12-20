using UnityEngine;
using System.Collections;

public class CatChasePos : MonoBehaviour {

    Animator Anim;
    Rigidbody2D rb;
    GamePoint Point;
    public GameObject[] Targets;
    int curr = 0;
    // Use this for initialization
    void Start() {
        Point = FindObjectOfType<GamePoint>();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate() {

        //       CatPatrol();
        CatTarget();
        

    }

    void CatTarget() {
        //int i = 0;

        Vector2 location = transform.position;
        Vector2 TargetPos = Targets[curr].transform.position;

        Vector2 Straight = TargetPos - location;
        Vector2 StraightNorm = Straight.normalized;
        rb.velocity = StraightNorm * Point.CatSpeed;
        //up
        if(StraightNorm.y > 0 && Mathf.Abs( StraightNorm.x ) < Mathf.Abs(StraightNorm.y)) {
            Anim.SetFloat("Turn", 0);
            transform.eulerAngles = new Vector2(180, 0);
        }
        //right
        if (StraightNorm.x > 0 && Mathf.Abs(StraightNorm.y) < Mathf.Abs(StraightNorm.x)) {
            Anim.SetFloat("Turn", 1);
            transform.eulerAngles = new Vector2(0, 0);
        }
        //down
        if (StraightNorm.y < 0 && Mathf.Abs(StraightNorm.x) < Mathf.Abs(StraightNorm.y) ) {
            Anim.SetFloat("Turn", 0);
            transform.eulerAngles = new Vector2(0, 0);
        }
        //left
        if (StraightNorm.x < 0 && Mathf.Abs(StraightNorm.y) < Mathf.Abs(StraightNorm.x)) {
            Anim.SetFloat("Turn", 1);
            transform.eulerAngles = new Vector2(0, 180);
        }

        Debug.Log(StraightNorm);
        Debug.Log(curr + "curr");
        if(Straight.magnitude <= 1) {
            curr++;
            if(curr >= Targets.Length) {
                curr = 0;
            }
        }

    }

/*
    void CatPatrol() {
        Vector2 location = transform.position;
        GameObject Destin = FindClosest();
        Vector2 Despos = Destin.transform.position;
        Vector2 straight = Despos - location;
        Vector2 StraightNorm = straight.normalized;
        float straightLength = straight.magnitude;
        //Debug.Log("location = " + location);
        // Debug.Log("Despos = " + Despos);
        // Debug.Log(straightLength);
        // Anim.SetFloat("Turn", 0);
        //transform.eulerAngles = new Vector2(180, 0);
        if (Vector2.Distance(location, Despos) >= 1 ) {
            rb.velocity = StraightNorm * Point.CatSpeed;
            Debug.Log(Vector2.Distance(location, Despos));
        }
        
        else if (Vector2.Distance(location,Despos) <= 0.5f ) {
            Debug.Log("hit");
            rb.velocity = Vector2.up * Point.CatSpeed;
        }
        

    }


    GameObject FindClosest() {
        Targets = GameObject.FindGameObjectsWithTag("Target");
        //GameObject Prev = null;
        GameObject Closest = null;
        float Distance = Mathf.Infinity;
        
       // Prev = Closest;
        for(int i = 0 ; i < Targets.Length; i++) {
            Vector2 Diff = Targets[i].transform.position - transform.position;
            float curDistance = Diff.sqrMagnitude;
            if (curDistance < Distance) {
                Debug.Log(i);
                Closest = Targets[i];
                Distance = curDistance;
                Debug.Log(Closest + "curr");
                //selected = i;
            }            
        }

        return Closest;
    }
    */

}
