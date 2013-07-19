using UnityEngine;
using System.Collections;

public class NavegadorScript : MonoBehaviour {
	
	public float rumbSpeed = 0.1f;
	public float rumbAmplitude = 20.0f;
	
	private Vector3 direction;
	private Vector3 lastPosition;
	
	// Use this for initialization
	void Start () {
		lastPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		RandomPoint();
		this.transform.position = Vector3.Slerp(this.transform.position, direction, Time.deltaTime * rumbSpeed);
		this.transform.LookAt(direction);
		
	}
	
	private void RandomPoint()
	{
		float x = (Mathf.PerlinNoise(Time.time * rumbAmplitude, 1.0f)*1000.0f) - 500;
		float y = (Mathf.PerlinNoise(7.0f, Time.time * rumbAmplitude)*1000.0f) - 500;
		float z = (Mathf.PerlinNoise(Time.time * rumbAmplitude, 13.0f)*1000.0f) - 500;
		
		direction = new Vector3(x, y, z);
	}
	
	public Vector3 GetDirection()
	{
		return Vector3.Slerp(this.transform.position, direction, Time.deltaTime * rumbSpeed);	
	}
	
	public Vector3 GetCameraPosition()
	{
		Vector3 move = Vector3.MoveTowards(lastPosition, this.transform.position, -20.0f);
		//Debug.Log(this.transform.position + " | " + lastPosition + " | " + move);
		lastPosition = this.transform.position;
		return move;
	}
}
