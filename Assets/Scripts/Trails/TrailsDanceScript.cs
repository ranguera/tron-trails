using UnityEngine;
using System.Collections;

public class TrailsDanceScript : MonoBehaviour {
	
	public float danceVariation = 0.5f;
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
		float x = (Mathf.PerlinNoise(Time.time * danceVariation, xSeed) - 0.5f) * danceAmplitude;
		float y = (Mathf.PerlinNoise(ySeed, Time.time * danceVariation) - 0.5f) * danceAmplitude;
		float z = (Mathf.PerlinNoise(Time.time * danceVariation, zSeed) - 0.5f) * danceAmplitude;
					
		Vector3 v = new Vector3(x, y, z);

		this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, v, Time.deltaTime * danceSpeed);
	}
	
	public void SetWidthVariation(float f)
	{
		trailRenderer.startWidth += f;
		trailRenderer.endWidth += f;
	}
}
