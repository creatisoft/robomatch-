using UnityEngine;
using System.Collections;

public class BoxDestroyer : MonoBehaviour {

    GameLogic gLogic;
	// Use this for initialization
	void Start () {

        gLogic = GameObject.FindWithTag("Glogic").GetComponent<GameLogic>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {


        coll.gameObject.SetActive(false);
        gLogic.SpeedUpGame(0.8f);
        gLogic.RemoveLife();
        gLogic.RemovePointFromScore();
        gLogic.UpdateUIText();

    }


}
