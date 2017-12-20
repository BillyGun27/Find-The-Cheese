using UnityEngine;
using System.Collections;

public class SecondFloor : MonoBehaviour {
    Renderer Otren;
    void Start() {
       
    }

    void OnTriggerEnter2D(Collider2D other) {
        Otren = other.GetComponent<Renderer>();
       // if(other.tag == "Player")
        Otren.sortingLayerName = "SecondFloor";
        other.gameObject.layer = 9;
    }
}
