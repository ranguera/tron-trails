using UnityEngine;
using System.Collections;

public class CameraMovementScript : MonoBehaviour {
	
	public GameObject navegador;
	
	private NavegadorScript navegadorScript;	
	
	// Use this for initialization
	void Start () {
		navegadorScript = GameObject.Find("Navegador").GetComponent<NavegadorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = navegadorScript.GetCameraPosition();
		this.transform.LookAt(navegadorScript.GetDirection());
	}
}
