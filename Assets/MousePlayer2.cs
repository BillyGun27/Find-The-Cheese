using UnityEngine;
using System.Collections;

public class MousePlayer2 : MonoBehaviour {

    Animator Anim;
    public float speed = 2f;
    public GameObject Unlock;
    public GameObject Particle;
    public GameObject Bye;
    GamePoint Pcheese;
    int Vertical, Horizontal, Activate;

    // Use this for initialization
    void Start() { 
        Anim = GetComponent<Animator>();
        Pcheese = FindObjectOfType<GamePoint>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Horizontal2")) {
            MoveHorizontal(Input.GetAxisRaw("Horizontal2"));
        }
        else if (Input.GetButton("Vertical2")) {
            MoveVertical(Input.GetAxisRaw("Vertical2"));
        }

        if (Input.GetButton("Unlock2")) {
            Opener();
        }
        MoveHorizontal(Horizontal);
        MoveVertical(Vertical);

    }

    public void MoveHorizontal(float direction) {
        if (direction == 1 || direction == -1) {
            Anim.SetFloat("Turn", 1);
        }
        if (direction == 1) {
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else if (direction == -1) {
            transform.localScale = new Vector2(-0.5f, 0.5f);
        }
        Vector2 Dir = new Vector2(0, 0);
        Dir.x = direction;
        transform.Translate(Dir * speed * Time.deltaTime);
    }

    public void MoveVertical(float direction) {
        if (direction == 1 || direction == -1) {
            Anim.SetFloat("Turn", 0);
        }
        Vector2 Dir = new Vector2(0, 0);
        Dir.y = direction;
        transform.Translate(Dir * speed * Time.deltaTime);
        Dir = transform.localScale;
        if (direction > 0 && Dir.y > 0 || direction < 0 && Dir.y < 0) {
            Dir.y *= -1;
            transform.localScale = Dir;
        }
    }

    public void Opener() {
        StartCoroutine(Activator());
    }

    IEnumerator Activator() {
        Unlock.SetActive(true);
        yield return new WaitForSeconds(2);
        Unlock.SetActive(false);
    }

    public void DirectionMover(string Name, int Dir) {
        if (Name == "Vertical") {
            Vertical = Dir;
        }
        else if (Name == "Horizontal") {
            Horizontal = Dir;
        }
    }

    public void ClickVertical(int vertical) {
        Vertical = vertical;
    }
    public void ClickHorizontal(int horizontal) {
        Horizontal = horizontal;
    }

    void OnTriggerEnter2D(Collider2D other) {

        switch (other.tag) {
            case "CheesePoint":
                other.transform.position = new Vector2(10, -20);
                Instantiate(Particle, transform.position, transform.rotation);
                Destroy(other.gameObject, 3f);
                Pcheese.PtwoScore(1f);
                break;
            case "PizzaPoint":
                other.transform.position = new Vector2(10, -20);
                Instantiate(Particle, transform.position, transform.rotation);
                Destroy(other.gameObject, 3f);
                Pcheese.PtwoScore(10f);
                break;
            case "Cat":
                Instantiate(Bye, transform.position, transform.rotation);
                transform.position = new Vector2(0, -6.5f);
                Pcheese.PtwoScore(Pcheese.CatAtt);
                break;
        }
    }

}
