using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Level1 : MonoBehaviour{

	public int pilihan;

	public List<GameObject> choices = new List<GameObject>();
	public List<GameObject> alive = new List<GameObject>();
	public List<GameObject> dead = new List<GameObject>();

	public RectTransform aliveRect;
	public RectTransform deadRect;

	void Start(){
		pilihan = choices.Count;
	}

	public void CheckChoices()
	{
		foreach (GameObject obj in choices)
		{
			if (alive.Contains(obj)) alive.Remove(obj);
			if (dead.Contains(obj)) dead.Remove(obj);

			if (RectTransformUtility.RectangleContainsScreenPoint(aliveRect, obj.transform.GetChild(0).GetComponent<RectTransform>().position))
			{
				alive.Add(obj);
			}

			else if (RectTransformUtility.RectangleContainsScreenPoint(deadRect, obj.transform.GetChild(0).GetComponent<RectTransform>().position))
			{
				dead.Add(obj);
			}
		}

		if (alive.Count + dead.Count >= pilihan)
		{
			ShowPane();
		}
	}

	public GameObject pane;

	void ShowPane()
	{
		pane.SetActive(true);
	}
}
