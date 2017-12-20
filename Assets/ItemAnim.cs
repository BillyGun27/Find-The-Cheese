using UnityEngine;
using System.Collections;

public class ItemAnim : MonoBehaviour {
    Animator Children;
    Animator Parent;
    public float Limit;
    float Wait;

    // Use this for initialization
    void Start() {
        Children = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Children.SetTrigger("UpDown");

        Wait += Time.deltaTime;
        if(Wait > Limit) {
          //  Debug.Log("timeout");
            Children.SetTrigger("TimeOut");
            Destroy(gameObject, 3f);
            Wait = 0;
        }

	}
}
