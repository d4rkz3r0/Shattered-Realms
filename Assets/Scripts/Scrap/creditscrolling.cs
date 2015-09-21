using UnityEngine;
using System.Collections;
// Fidn the text unclude

public class creditscrolling : MonoBehaviour {

	//float speed = .5f;
	// public Text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmpposition = new Vector3 (0, 1, 0);
		//tmpposition.y += GameObject.Find ("Credits Scroll Rect").GetComponentInChildren<TextEditor> ().position.y * Time.deltaTime;
		tmpposition.y += GameObject.Find ("Credits Scroll Rect").transform.localPosition.y;

		//GameObject.Find ("Credits Text").GetComponent<TextAsset>().text.
	}
}
