using UnityEngine;
using System.Collections;

public class CameraMovementScript : MonoBehaviour {
	
	public Transform baseTransform;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(baseTransform.position);	
	}
}
