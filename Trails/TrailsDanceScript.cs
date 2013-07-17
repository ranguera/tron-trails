using UnityEngine;
using System.Collections;

public class TrailsDanceScript : MonoBehaviour {
	
	public float danceAmplitude = 6.0f;
	public float danceSpeed = 1.0f;
	
	private float xSeed;
	private float ySeed;
	private float zSeed;
	
	private Vector3 initialPosition;
	
	// Use this for initialization
	void Start () {
		xSeed = Random.Range(50.0f, 200.0f);
		ySeed = Random.Range(50.0f, 200.0f);
		zSeed = Random.Range(50.0f, 200.0f);
		
		initialPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		DanceMagicDance();
	}
	
	private void DanceMagicDance()
	{
		float x = Mathf.PerlinNoise(Time.time, xSeed)*danceAmplitude - (danceAmplitude/2.0f);
		float y = Mathf.PerlinNoise(ySeed, Time.time)*danceAmplitude - (danceAmplitude/2.0f);
		float z = Mathf.PerlinNoise(Time.time, zSeed)*danceAmplitude - (danceAmplitude/2.0f);
		
		Vector3 v = new Vector3(x, y, z);
		this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, initialPosition + v, Time.deltaTime * danceSpeed);
	}
}
