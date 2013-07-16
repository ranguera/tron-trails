using UnityEngine;
using System.Collections;

public class NavegadorScript : MonoBehaviour {
	
	public float rumbSpeed = 0.1f;
	public float rumbAmplitude = 20.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 newPosition = RandomPoint();
		this.transform.position = Vector3.Slerp(this.transform.position, newPosition, Time.deltaTime * rumbSpeed);
		this.transform.LookAt(newPosition);
	}
	
	private Vector3 RandomPoint()
	{
		float x = (Mathf.PerlinNoise(Time.time * rumbAmplitude, 1.0f)*1000.0f) - 500;
		float y = (Mathf.PerlinNoise(20.0f, Time.time * rumbAmplitude)*1000.0f) - 500;
		float z = (Mathf.PerlinNoise(Time.time * rumbAmplitude, 10.0f)*1000.0f) - 500;
		
		return new Vector3(x, y, z);
	}
}
