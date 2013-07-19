using UnityEngine;
using System.Collections;

public class CameraMovementScript : MonoBehaviour {
	
	public GameObject navegador;
	
	private NavegadorScript navegadorScript;
	private Transform baseTransform;
	
	
	// Use this for initialization
	void Start () {
		baseTransform = GameObject.Find("Navegador").GetComponent<TrailRenderer>().transform;
		navegadorScript = GameObject.Find("Navegador").GetComponent<NavegadorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = baseTransform.position;
		this.transform.position = navegadorScript.GetCameraPosition();
		this.transform.LookAt(navegadorScript.GetDirection());
	}
}
