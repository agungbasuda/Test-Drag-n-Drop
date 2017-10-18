using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

	//public List<GameObject> pilihan = new List<GameObject>();
	//public List<GameObject> hidup = new List<GameObject>();
	//public List<GameObject> mati = new List<GameObject>();

	public GameObject cleared;

	public int itemNumber;

	public int itemCount;

	void Update(){
		if(itemNumber == itemCount){
			cleared.SetActive (true);
		}
	}
}