using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Utilities : MonoBehaviour {

	void Start () {
		PlayerPrefs.DeleteAll();
		Debug.Log ("PLAYER PREFS DELETED");
	}
	
}
