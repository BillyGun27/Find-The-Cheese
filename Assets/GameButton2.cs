using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameButton2 : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
    //MousePlayer1 M1;
     MousePlayer2 M2;
    public string dirName;
    public int direction;

    void Awake() {
      //  M1 = FindObjectOfType<MousePlayer1>();
          M2 = FindObjectOfType<MousePlayer2>();

    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerDown(PointerEventData eventData) {
        M2.DirectionMover(dirName, direction);

    }

    public void OnPointerUp(PointerEventData eventData) {
        M2.DirectionMover(dirName, 0);

    }
}
