using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chapter1 : MonoBehaviour {

	public int scoreNeeded;

	public int currentScore;

    public float elapsedTime;
    public float timeLimit;
    float startTime;

	public void DisableBoolAnimator (Animator anim)
	{
		anim.SetBool ("IsDisplayed", false);
	}

	public void EnableBoolAnimator (Animator anim)
	{
		anim.SetBool ("IsDisplayed", true);
	}

	void Start(){
		scoreNeeded = choices.Count;
	}

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        // check mouse up
        if (Input.GetMouseButtonUp(0)) CheckChoices();
#endif

//#if UNITY_ANDROID || UNITY_IOS
//      if (Input.touches[0].phase == TouchPhase.Ended)
//      {
//      	CheckChoices();
//  	}
//#endif
    }

    public List<GameObject> choices = new List<GameObject>();
    public List<GameObject> alive = new List<GameObject>();
    public List<GameObject> dead = new List<GameObject>();

    public RectTransform aliveRect;
    public RectTransform deadRect;

    public void CheckChoices()
    {
        foreach (GameObject obj in choices)
        {
			if (alive.Contains(obj)) {
				alive.Remove (obj);
				if (currentScore != 0 && obj.tag == "hidup") {
					currentScore--;
				}
			}

			if (dead.Contains (obj)) {
				dead.Remove (obj);
				if (currentScore != 0 && obj.tag == "mati") {
					currentScore--;
				}
			}

			if (RectTransformUtility.RectangleContainsScreenPoint (aliveRect, obj.transform.GetChild (0).GetComponent<RectTransform> ().position)) {
				alive.Add (obj);
				if (obj.tag == "hidup") {
					currentScore = currentScore + 1;
				} 
			} else if (RectTransformUtility.RectangleContainsScreenPoint (deadRect, obj.transform.GetChild (0).GetComponent<RectTransform> ().position)) {
				dead.Add (obj);
				if (obj.tag == "mati") {
					currentScore = currentScore + 1;
				}
			}
        }
			


		if (currentScore >= scoreNeeded)
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