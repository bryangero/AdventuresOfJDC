using UnityEngine;
using System.Collections;

public class tester : MonoBehaviour {

	public Animator anm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){anm.SetTrigger ("attack");}

	}
}
