using UnityEngine;
using System.Collections;

public class NavegadorScript : MonoBehaviour {
	
	public float rumbSpeed = 0.1f;
	public float rumbAmplitude = 20.0f;
	
	private Vector3 direction;
	private Vector3 lastPosition;
	
	private float xSeed, ySeed, zSeed;
	
	// Use this for initialization
	void Start () {
		lastPosition = this.transform.position;
		
		xSeed = Random.Range(0.0f, 20.0f);
		ySeed = Random.Range(0.0f, 20.0f);
		zSeed = Random.Range(0.0f, 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		RandomPoint();
		this.transform.position = Vector3.Lerp(this.transform.position, direction, Time.deltaTime * rumbSpeed);
		this.transform.LookAt(direction);
		
	}
	
	private void RandomPoint()
	{
		float x = (Mathf.PerlinNoise(Time.time * rumbAmplitude, xSeed)*1500.0f) - 750;
		float y = (Mathf.PerlinNoise(ySeed, Time.time * rumbAmplitude)*1500.0f) - 750;
		float z = (Mathf.PerlinNoise(Time.time * rumbAmplitude, zSeed)*1500.0f) - 750;
		
		direction = new Vector3(x, y, z);
	}
	
	public Vector3 GetDirection()
	{
		return Vector3.Lerp(this.transform.position, direction, Time.deltaTime * rumbSpeed * 0.1f);
		//return direction;
	}
	
	public Vector3 GetCameraPosition()
	{
		Vector3 move = Vector3.MoveTowards(lastPosition, this.transform.position, -12.0f);
		//Debug.Log(this.transform.position + " | " + lastPosition + " | " + move);
		lastPosition = this.transform.position;
		return move;
	}
}
