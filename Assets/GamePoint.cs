using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class GamePoint : MonoBehaviour {
    MouseFollower SetUp;
    public float CatSpeed = 4,Faster=2;
    public float CatAtt = -50,AttUp=-25;
    float Ts, Ta;
    public Text Pone, Ptwo,TimeClock,Winner,Result;
    float PonePoint, PtwoPoint,RoundClock,SpeedChange;
    public float Clock,TargetCheese = 500;
    public GameObject StartGame,P1Img,P2Img,CatImg,End,MouseA,MouseB,Controller1,Controller2;
    bool UnPause;
    bool TargetReached;

    void Awake() {
        SetUp = FindObjectOfType<MouseFollower>();
    }

    void Start() {
        
        if (SetUp.Mouse1) {
            MouseA.SetActive(true);
            Controller1.SetActive(true);
            Pone.gameObject.SetActive(true);
        }
        else {
            MouseA.SetActive(false);
            Controller1.SetActive(false);
            Pone.gameObject.SetActive(false);
        }

        if (SetUp.Mouse2) {
            MouseB.SetActive(true);
            Controller2.SetActive(true);
            Ptwo.gameObject.SetActive(true);
        }
        else {
            MouseB.SetActive(false);
            Controller2.SetActive(false);
            Ptwo.gameObject.SetActive(false);
        }
        CatSpeed = SetUp.Speed;
        Clock = SetUp.Timer;
        TargetCheese = SetUp.Target;

        SpeedChange = Clock / 3;
        Ts = CatSpeed + Faster;
        Ta = CatAtt + AttUp;

    }
    void Update() {
        Time.timeScale = 0;
        if (Input.anyKeyDown) {
            Play();
        }
        if (UnPause) {
            Time.timeScale = 1;
        }
        else {
            Time.timeScale = 0;
        }

    }

    void FixedUpdate() {
        /*  if (PonePoint >= TargetCheese && PtwoPoint >= TargetCheese) {
              CatImg.SetActive(true);
              Winner.text = "Draw";
              Result.text = (Pone.text + " Cheese");
              UnPause = false;
          }
          else if (PonePoint >= TargetCheese) {
              P1Img.SetActive(true);
              Winner.text = "Brown Mouse Wins !";
              Result.text = (Pone.text + " Cheese");
              UnPause = false;
          }
          else if (PtwoPoint >= TargetCheese) {
              P2Img.SetActive(true);
              Winner.text = "Grey Mouse Wins !";
              Result.text = (Ptwo.text + " Cheese");
              UnPause = false;
          }*/
        if (TargetReached) {
            UnPause = false;
        }
        ClockOut();
    }

    public void Play() {
        StartGame.SetActive(false);
        UnPause = true;
    }


    public void ClockOut() {
        Clock -= Time.deltaTime;
        RoundClock = Mathf.Round(Clock);
        TimeClock.text = RoundClock.ToString();
        if(Clock < SpeedChange) {
            CatAtt = Ta;
            CatSpeed = Ts;
        }

        if(Clock < 0) {
            TimeClock.text = "0";
            End.SetActive(true);
            if (PonePoint <= 0 && PtwoPoint <= 0) {
                CatImg.SetActive(true);
                Winner.text = "Cats Wins";
                Result.text = "No Cheese For The Mouse ";
            }else if (PonePoint > PtwoPoint) {
                P1Img.SetActive(true);
                Winner.text = "Brown Mouse Wins !";
                Result.text = (Pone.text + " Cheese");  
            }else if (PtwoPoint > PonePoint) {
                P2Img.SetActive(true);
                Winner.text = "Grey Mouse Wins !";
                Result.text = (Ptwo.text + " Cheese");
            }else if (PonePoint == PtwoPoint) {
                CatImg.SetActive(true);
                Winner.text = "Draw";
                Result.text = (Pone.text + " Cheese");
            }

            UnPause = false;
        }

    }
        
    public void PoneScore(float Score) {
        PonePoint += Score;
        Pone.text = PonePoint.ToString();
        if (PonePoint >= TargetCheese) {
            End.SetActive(true);
            P1Img.SetActive(true);
            Winner.text = "Brown Mouse Wins !";
            Result.text = (Pone.text + " Cheese");
            TargetReached = true;
        }
    }

    public void PtwoScore(float Score) {
        PtwoPoint += Score;
        Ptwo.text = PtwoPoint.ToString();

        if (PtwoPoint >= TargetCheese) {
            End.SetActive(true);
            P2Img.SetActive(true);
            Winner.text = "Grey Mouse Wins !";
            Result.text = (Ptwo.text + " Cheese");
            TargetReached = true;
        }
    }

}
