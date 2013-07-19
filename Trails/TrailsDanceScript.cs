using UnityEngine;
using System.Collections;

public class TrailsDanceScript : MonoBehaviour {
	
	public float danceAmplitude = 6.0f;
	public float danceSpeed = 1.0f;
	public TrailRenderer trailRenderer;
	
	private float xSeed;
	private float ySeed;
	private float zSeed;
	
	// Use this for initialization
	void Start () {
		xSeed = Random.Range(50.0f, 3500.0f);
		ySeed = Random.Range(50.0f, 3500.0f);
		zSeed = Random.Range(50.0f, 3500.0f);
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

		this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, v, Time.deltaTime * danceSpeed);
		//trailRenderer.startWidth = x;
		//trailRenderer.endWidth = y;
	}
}
