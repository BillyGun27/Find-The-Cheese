using UnityEngine;
using System.Collections;

public class FirstFloor : MonoBehaviour {
    Renderer Otren;
    void Start() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        Otren = other.GetComponent<Renderer>();
       // if(other.tag == "Player")
        Otren.sortingLayerName = "FirstFloor";
        other.gameObject.layer = 8;
    }
}
