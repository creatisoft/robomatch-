using UnityEngine;
using System.Collections;

public class Randomizer : MonoBehaviour {

    public Sprite[] BoxSprite;
    private SpriteRenderer Sprite_Renderer;

    // Use this for initialization
    float seconds = 0f;
    public float new_seconds = 2.5f;

    int r1 = 0;

    public int R1 {
        get { return r1; }
    }

    void Start () {


        seconds = new_seconds;
        Sprite_Renderer = gameObject.GetComponent<SpriteRenderer>();
        
        

    }


    public void InitRandom() {

        
        r1 = Random.Range(0, 4);
        Sprite_Renderer.sprite = BoxSprite[r1];
        

    }

    void ChangeColourTimer() {

        if (seconds >= 0.0f) {

            seconds -= Time.deltaTime;

        } else if (seconds <= 0) {

            InitRandom();

            seconds += new_seconds;
        }


    }




    // Update is called once per frame
    void Update () {

        Random.seed = (int)Time.time;
        //Debug.Log(seconds);
        ChangeColourTimer();
        

	
	}
}
