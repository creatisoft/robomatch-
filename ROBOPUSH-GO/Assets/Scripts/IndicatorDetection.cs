using UnityEngine;
using System.Collections;

public class IndicatorDetection : MonoBehaviour {

    // Use this for initialization

    private SpriteRenderer Sprite_renderer;
    public Sprite[] IndicatorSprite;

    

    GameLogic Glogic;

    int r1 = 0;

   	void Awake () {

        Glogic = GameObject.FindWithTag("Glogic").GetComponent<GameLogic>();
        Sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    public void ChangeColour() {

        r1 = Random.Range(0, 4);
        Sprite_renderer.sprite = IndicatorSprite[r1];

    }


    void OnCollisionEnter2D(Collision2D coll) {

 
        switch (r1) {

            case 0:
                if(coll.gameObject.tag == "BlueBox") {
                    //increment point
                    //Debug.Log("Hit Blue");
                    Glogic.AddPointToScore();

                   

                    coll.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);

                    Glogic.SpeedUpGame(0.8f);

                    Glogic.ResetTimer();

                } else {


                    Glogic.SpeedUpGame(1.2f);
                    Glogic.RemovePointFromScore();
                    Glogic.RemoveLife();
                    coll.gameObject.SetActive(false);
                    //this.gameObject.SetActive(false);
                    Glogic.ResetTimer();

                }
                break;
            case 1:
                if (coll.gameObject.tag == "OrangeBox") {
                    //increment point
                    //Debug.Log("Hit Orange");
                    Glogic.AddPointToScore();


                    Glogic.SpeedUpGame(0.8f);
                    coll.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);

                    

                    Glogic.ResetTimer();

                } else {

                    Glogic.SpeedUpGame(1.2f);
                    Glogic.RemovePointFromScore();
                    Glogic.RemoveLife();
                    coll.gameObject.SetActive(false);
                    //this.gameObject.SetActive(false);
                    Glogic.ResetTimer();
                }
                break;
            case 2:
                if (coll.gameObject.tag == "RedBox") {
                    //increment point
                    //Debug.Log("Hit Red");
                    Glogic.AddPointToScore();

                    Glogic.SpeedUpGame(0.8f);

                    coll.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);

                    Glogic.ResetTimer();

                } else {

                    Glogic.SpeedUpGame(1.2f);
                    Glogic.RemovePointFromScore();
                    Glogic.RemoveLife();
                    coll.gameObject.SetActive(false);
                    //this.gameObject.SetActive(false);
                    Glogic.ResetTimer();
                }
                break;
            case 3:
                if (coll.gameObject.tag == "YellowBox") {
                    //increment point
                    //Debug.Log("Hit Yellow");
                    Glogic.AddPointToScore();

                    Glogic.SpeedUpGame(0.8f);

                    coll.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);

                    Glogic.ResetTimer();

                } else {

                    Glogic.SpeedUpGame(1.2f);
                    Glogic.RemovePointFromScore();
                    Glogic.RemoveLife();
                    coll.gameObject.SetActive(false);
                    //this.gameObject.SetActive(false);
                    Glogic.ResetTimer();
                }
                break;
            default:
                break;
        }

       
    }
}
