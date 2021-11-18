using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {


    private int direction_count = 0;
    private int r1 = 0;

    Randomizer randomizer;
    private GameObject[] BoxesCopy;

    public Transform BoxSpawnPoint;
    public GameObject[] Boxes;

    public AudioSource aSource;
    public AudioClip aClip;

    bool canMove = false;

    void Start () {

       //PlayerPrefs.DeleteAll();
        BoxesCopy = new GameObject[4];
        randomizer = GameObject.FindWithTag("Randomizer").GetComponent<Randomizer>();

        for(int i = 0; i < 4; i++) {

            BoxesCopy[i] = (GameObject)Instantiate(Boxes[i], BoxSpawnPoint.position, Quaternion.identity);
            Boxes[i].SetActive(false);

        }

	}

	// Update is called once per frame
	void Update () {

       
        KeyboardControlControlInput();


    }

    void ResetPositionBeforeSpawn() {

        for(int i = 0; i < BoxesCopy.Length; i++) {

            if (!BoxesCopy[i].activeInHierarchy) {
                BoxesCopy[i].transform.position = BoxSpawnPoint.position;
            }
           



        }

    }

    public void GoingLeft() {

        if (direction_count > 0) {
            direction_count -= 1;
            transform.position -= new Vector3(1.1f, 0, 0);
        } else {

            direction_count = 0;
        }

    }

   public void GoingRight() {

        if (direction_count < 3) {
            direction_count += 1;
            transform.position += new Vector3(1.1f, 0, 0);
        }

    }

    public void FireBox() {

        r1 = randomizer.R1;
        if (!BoxesCopy[r1].activeInHierarchy) {

            //BoxesCopy[i].transform.position = BoxSpawnPoint.position;
            ResetPositionBeforeSpawn();
            aSource.PlayOneShot(aClip);
            BoxesCopy[r1].SetActive(true);
            // break;
        }

    }


    void KeyboardControlControlInput() {


        if (Input.GetKeyDown(KeyCode.D)) {

            //transform.Translate(Vector2.right * movement_speed * Time.deltaTime);
            if (direction_count < 3) {
                direction_count += 1;
                transform.position += new Vector3(1.1f, 0, 0);
            }


        } 

        if (Input.GetKeyDown(KeyCode.A)) {

            // transform.Translate(Vector2.right * -movement_speed * Time.deltaTime);
            if (direction_count > 0) {
                direction_count -= 1;
                transform.position -= new Vector3(1.1f, 0, 0);
            } else {
               
                direction_count = 0;
            }


        }



        if (Input.GetKeyDown(KeyCode.Space)) {

            r1 = randomizer.R1;
            if (!BoxesCopy[r1].activeInHierarchy) {
                
                //BoxesCopy[i].transform.position = BoxSpawnPoint.position;
                    ResetPositionBeforeSpawn();
                aSource.PlayOneShot(aClip);
                    BoxesCopy[r1].SetActive(true);
                    // break;
                }

        }

    }
}
