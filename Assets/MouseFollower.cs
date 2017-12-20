using UnityEngine;
using System.Collections;

public class MouseFollower : MonoBehaviour {
    static MouseFollower instance = null;
    public bool Mouse1, Mouse2;
    public float Speed, Timer, Target;
    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        Mouse1 = false;
        Mouse2 = false;
        Speed = 4;
        Timer = 180;
        Target = 500;
	}

}
