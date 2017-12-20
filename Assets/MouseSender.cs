using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseSender : MonoBehaviour {

    MouseFollower Choice;
    public GameObject LevelSelect;
    GameObject Warn, Gobut, Toga, Togu;
    GameObject SS,TIS,TAS;
    Text Warning;
    public Text SpeedRead,TimerRead,TargetRead;
    Button Go;
    Toggle Tog1,Tog2;
    Slider SpeedSet, TimerSet, TargetSet;
    void Awake() {
        Choice = FindObjectOfType<MouseFollower>();

        Toga = GameObject.Find("P1Select");
        Togu = GameObject.Find("P2Select");
        Warn = GameObject.Find("Warning");
        Gobut = GameObject.Find("Go");
        SS = GameObject.Find("CatSpeed");
        TIS = GameObject.Find("TimerClock");
        TAS = GameObject.Find("TargetCheese");
    }

    void Start() {
        SpeedSet = SS.GetComponent<Slider>();
        TimerSet = TIS.GetComponent<Slider>();
        TargetSet = TAS.GetComponent<Slider>();
        Go = Gobut.GetComponent<Button>();
        Tog1 = Toga.GetComponent<Toggle>();
        Tog2 = Togu.GetComponent<Toggle>(); 
        Warning = Warn.GetComponent<Text>();
         
        Choice.Mouse1 = false;
        Choice.Mouse2 = false;
        Choice.Speed = 4;
        Choice.Timer = 180;
        Choice.Target = 500;

    }

    public void SelectArena() {
        LevelSelect.SetActive(true);
    }
    public void CloseArena() {
        LevelSelect.SetActive(false);
    }

    void Update() {
        if( !Tog1.isOn && !Tog2.isOn) {
            if(Go != null) {
                Warning.text = "Choose At Least One Mouse to Play ";
                Go.enabled = false;
            }
        }else if(Tog1.isOn || Tog2.isOn) {
           
            if(Go != null) {
                Warning.text = "Mouse Is Ready";
                Go.enabled = true;
            }
            
        }


    }

    public void SpeedMeter() {
        if(SpeedSet.value == 0) {
            SpeedRead.text = "The Walking Cats \nSpeed";
            Choice.Speed = 4;
        }else if (SpeedSet.value == 1) {
            SpeedRead.text = "The Hunting Cats ! \nSpeed";
            Choice.Speed = 6;
        }else if (SpeedSet.value == 2) {
            SpeedRead.text = "The Flash Cats !? \nSpeed";
            Choice.Speed = 8;
        }

    }


    public void TimerMeter() {
        if (TimerSet.value == 0) {
            Choice.Timer = 60;
            TimerRead.text = "Leisure Time \n" + Choice.Timer +" Seconds";    
        }else if (TimerSet.value == 1) {
            Choice.Timer = 120;
            TimerRead.text = "Snack Time \n" + Choice.Timer + " Seconds";
        }
        else if(TimerSet.value == 2) {
            Choice.Timer = 180;
            TimerRead.text = "Brunch Time  \n" + Choice.Timer + " Seconds";
        }
        else if(TimerSet.value == 3) {
            Choice.Timer = 240;
            TimerRead.text = "Family Dinner Time \n" + Choice.Timer + " Seconds";
        }
    }

    public void TargetMeter() {
        if (TargetSet.value == 0) {
            Choice.Target = 200;
            TargetRead.text = "Playing Mice Target \n" + Choice.Target +"Cheese";       
        }
        else if (TargetSet.value == 1) {
            Choice.Target = 300;
            TargetRead.text = "Hungry Mice Target \n" + Choice.Target + " Cheese";
        }
        else if (TargetSet.value == 2) {
            Choice.Target = 500;
            TargetRead.text = "Competitive Mice Target \n" + Choice.Target + "Cheese";
        }
        else if (TargetSet.value == 3) {
            Choice.Target = 700;
            TargetRead.text = "World Record Mice Target \n" + Choice.Target + "Cheese";      
        }
        else if (TargetSet.value == 4) {
            Choice.Target = 10000f;
            TargetRead.text = "Liberty Mice Target \n No Target";
            
        }
    }

    public void BrownMouse() {
        if (Tog1.isOn) {
            Choice.Mouse1 = true;
        }
        else {
            Choice.Mouse1 = false;
        }
    }

    public void GreyMouse() {
        if (Tog2.isOn) {
            Choice.Mouse2 = true;
        }
        else {
            Choice.Mouse2 = false;
        }
    }

}
