using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public string kategori;

	public void OnBeginDrag(PointerEventData eventData){
		
	}

	public void OnDrag(PointerEventData eventData){
		this.transform.position = eventData.position;
		RectTransform rt = GetComponent (typeof(RectTransform))as RectTransform;
		rt.sizeDelta = new Vector2 (100,100);
	}

	public void OnEndDrag(PointerEventData eventData){
		
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == kategori) {
			Option item = other.GetComponentInParent<Option>();
			item.itemCount--;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == kategori) {
			Option item = other.GetComponentInParent<Option>();
			item.itemCount++;
		} 
	}
}