using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
    MousePlayer1 M1;

	// Use this for initialization
	void Start () {
        M1 = FindObjectOfType<MousePlayer1>();
	}
	
	// Update is called once per frame
	void Update () {
        for (var i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                if (hit.collider != null) {
                    Debug.Log(hit.collider.name);
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null) {
                Debug.Log(hit.collider.name);
             //   Destroy(hit.collider.gameObject);
                }
            if (hit.collider.tag == "up") {
                Debug.Log("det");
                M1.DirectionMover("Vertical", 1);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
           // M1.DirectionMover("Vertical", 0);
            Debug.Log("rel");
        }

        
    }
}
