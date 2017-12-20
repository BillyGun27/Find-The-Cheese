using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour {
    public GameObject[] Item;
    public int[] GetChance;
    float Wait;
    float Timer = 0;
    bool ItemFull = false;
    // Use this for initialization
    void Start () {
        Wait = Random.Range(5, 15);
    }

    void FixedUpdate() {
        Empty(ItemFull);

    }

    void Empty(bool check) {
        if (check == false) {
            PreparingItem(transform.position);

        }
    }

    public void PreparingItem(Vector2 Spammer) {

        Timer += Time.deltaTime;
        if (Timer > Wait) {
           // Debug.Log("waiting");
            ItemAppear(Spammer);
            Wait = Random.Range(5, 15);
            Timer = 0;
        }
      //  NoItem = false;
    }

    public void ItemAppear(Vector2 Spammer) {
        int current = Random.Range(0, Item.Length);
        int Chance = Random.Range(0, 10);
        if (Chance >= GetChance[current]) {
            Instantiate(Item[current],Spammer,Item[current].transform.rotation);
        }
        else {
            Instantiate(Item[0],Spammer,Item[0].transform.rotation);
          //  Debug.Log("common");
        }
    }

    void OnTriggerExit2D(Collider2D other) {

            ItemFull = false;

       // Debug.Log("exit");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Item") {
            ItemFull = true;

           // Debug.Log("enter");
        }
    }
   



}
