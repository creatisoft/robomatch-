using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public GameObject gameover;
    public GameObject player;
   

    public Text PointsUI;
    public Text LivesUI;
    public Text PointsUIGameOver;

    private int points = 0;
    private int lives = 3;

    public GameObject[] Indicators;

    public int rX = 0;

    private int r0 = 0;
    private int r1 = 0;
    private int r2 = 0;
    private int r3 = 0;

    private bool l1enabled = false;
    private bool l2enabled = false;
    private bool l3enabled = false;

    float seconds = 0;
    public float new_seconds = 8;
    
    


	// Use this for initialization
	void Start () {


        UpdateUIText();
      

}

   public void UpdateUIText() {

        LivesUI.text = "Lives: " + lives.ToString();
        PointsUI.text = "Score: " + points.ToString();

    }

    public void InitRandomIndicator() {

        rX = Random.Range(0, 4);

        switch (rX) {
            case 0:
                r0 = 0;
                r1 = 2;
                r2 = 3;
                r3 = 1;
                break;
            case 1:
                r0 = 3;
                r1 = 0;
                r2 = 1;
                r3 = 2;
                break;
            case 2:
                r0 = 1;
                r1 = 3;
                r2 = 2;
                r3 = 0;
                break;
            case 3:
                r0 = 2;
                r1 = 1;
                r2 = 0;
                r3 = 3;
                break;
            default:
                break;
        }

    }

    void EnableIndicators() {

        if (l1enabled) {
            Indicators[r1].SetActive(true);
            Indicators[r1].GetComponent<IndicatorDetection>().ChangeColour();
        }
        if (l2enabled) {
            Indicators[r2].SetActive(true);
            Indicators[r2].GetComponent<IndicatorDetection>().ChangeColour();
        } 
        if (l3enabled) {
            Indicators[r3].SetActive(true);
            Indicators[r3].GetComponent<IndicatorDetection>().ChangeColour();

        } 

    }

    public void RandomIndicator() {


        InitRandomIndicator();
        EnableIndicators();
        Indicators[r0].SetActive(true);
        Indicators[r0].GetComponent<IndicatorDetection>().ChangeColour();

        if (points >= 4) {

            l1enabled = true;
           //Indicators[r1].SetActive(true);
           //Indicators[r1].GetComponent<IndicatorDetection>().ChangeColour();

        }
        if (points >= 8) {

            l2enabled = true;
            //Indicators[r2].SetActive(true);
            //Indicators[r2].GetComponent<IndicatorDetection>().ChangeColour();

        }
        if (points >= 10) {

            l3enabled = true;
            //Indicators[r3].SetActive(true);
            //Indicators[r3].GetComponent<IndicatorDetection>().ChangeColour();

        }

    }

    public void ResetTimer() {

        seconds = 0;
     

    }

    public void SpeedUpGame(float ourseconds) {

        if(new_seconds > 2.8f) {

            new_seconds -= ourseconds;

        } else {

            new_seconds = 2.8f;

        }
        
            
    }

    void ChangeIndicatorSpawn() {

       

        if (seconds >= 0.0f) {

            seconds -= Time.deltaTime;

        } else if (seconds <= 0) {

            Indicators[r0].SetActive(false);
            Indicators[r1].SetActive(false);
            Indicators[r2].SetActive(false);
            Indicators[r3].SetActive(false);

            RandomIndicator();

            seconds += new_seconds;
        }


    }

    public void RestartGame() {

        points = 0;

        RandomIndicator();

        lives = 3;

       

        new_seconds = 10;

        UpdateUIText();


        gameover.SetActive(false);
        player.SetActive(true);

        

        //SceneManager.LoadScene(1);

    }

    // Update is called once per frame
    void Update () {

        UpdateUIText();
        Random.seed = (int)Time.time;

        
        if (lives <= 0) {

            lives = 0;
            
            player.SetActive(false);
            gameover.SetActive(true);

            l1enabled = false;
            l2enabled = false;
            l3enabled = false;
            Indicators[r1].SetActive(false);
            Indicators[r2].SetActive(false);
            Indicators[r3].SetActive(false);

        } else {

            ChangeIndicatorSpawn();

        }
        
	
	}

    public void AddPointToScore() {
        points += 1;
        PointsUI.text = "Score: " + points.ToString();
        PointsUIGameOver.text = "Score: " + points.ToString();
    }
    public void RemovePointFromScore() {

        points -= 1;
        if(points <= 0) {
            points = 0;
        }
        PointsUI.text = "Score: " + points.ToString();
        PointsUIGameOver.text = "Score: " + points.ToString();
    }
    public void RemoveLife() {

        lives -= 1;
        LivesUI.text = "Lives: " + lives.ToString();
    }

}
