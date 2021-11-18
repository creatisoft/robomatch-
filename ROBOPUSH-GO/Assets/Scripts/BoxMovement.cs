using UnityEngine;
using System.Collections;

public class BoxMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.up * 3.4f * Time.deltaTime);
       // transform.SetParent(null);

	}
}
