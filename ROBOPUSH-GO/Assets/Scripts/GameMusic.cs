using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMusic : MonoBehaviour {

    AudioSource aSource;
    public Toggle music;

    // Use this for initialization
    void Start () {

        aSource = gameObject.GetComponent<AudioSource>();

	}

	
	// Update is called once per frame
	void Update () {

        Debug.Log(music);

        if (music.isOn) {
            aSource.enabled = true;
        } else {
            aSource.enabled = false;
        }



	}


    

}
