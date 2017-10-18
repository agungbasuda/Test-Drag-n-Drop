using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject clear;

	public GameObject failed;

	public GameObject tombolstart;

	private bool timerOn = false;

	public float timeLimit = 5f;

	public Text timeText;

	// Use this for initialization
	void Start () {
		tombolstart.SetActive (true);
		clear.SetActive (false);
		failed.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = "" + Mathf.Round (timeLimit);

		if(timerOn){
			timeLimit -= Time.deltaTime;
		}

		if(timeLimit <=0){
			failed.SetActive (true);
			Time.timeScale = 0;
		}
	}


	public void Pressstart(){
		tombolstart.SetActive (false);
		timerOn = true;
	}
}
