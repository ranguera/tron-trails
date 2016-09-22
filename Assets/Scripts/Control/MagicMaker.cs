using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MagicMaker : MonoBehaviour {
	
	public GameObject trail;
	public Transform emotionTransform;
	public UnityStandardAssets.ImageEffects.Bloom leftBloom;
	
	private GameObject[] trails;
	private TrailRenderer[] trailRenderers;
	private ParticleSystem[] particleSystems;
	private TrailsDanceScript[] trailDanceScripts;
	
	private NavegadorScript navegadorScript;
	
	// Use this for initialization
	void Start () {
		
		trails = new GameObject[50];
		trailRenderers = new TrailRenderer[50];
		particleSystems = new ParticleSystem[50];
		trailDanceScripts = new TrailsDanceScript[50];
		
		navegadorScript = this.GetComponent<NavegadorScript>();
		
		for (int i = 0; i < 50; i++) {
			GameObject tmp = (GameObject) Instantiate(trail, this.transform.position, Quaternion.identity);
			tmp.transform.parent = this.transform;
			TrailSetup ts = tmp.GetComponent<TrailSetup>();
			ts.Setup();
			trails[i] = tmp;
			trailRenderers[i] = trails[i].GetComponent<TrailRenderer>();
			particleSystems[i] = trails[i].GetComponent<ParticleSystem>();
			trailDanceScripts[i] = trails[i].GetComponent<TrailsDanceScript>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float emotion = emotionTransform.position.x;
		
		leftBloom.bloomIntensity = emotion / 5.0f;
		
		for (int i = 0; i < 50; i++) {
						
			this.navegadorScript.rumbSpeed = 0.05f + (emotion / 50.0f);
			//this.navegadorScript.rumbAmplitude = 0.05f + (emotion / 1000.0f);
			
			float tintRatio = emotion / 30.0f;
			float variation = (Mathf.PerlinNoise(i*10.0f, Time.time) - 0.5f) / 2.0f;
			//float newTint = Mathf.Clamp(tintRatio + variation, 0.0f, 0.8f);
			Color currentTint = trailRenderers[i].GetComponent<Renderer>().material.GetColor ("_TintColor");
			Color c = new Color(0.5f, 0.5f, 0.5f, 0.8f);
			c.a = (i < emotion) ? 0.8f : Mathf.Lerp(currentTint.a, 0.0f, Time.deltaTime);
			trailRenderers[i].GetComponent<Renderer>().material.SetColor ("_TintColor", c);
			
			trailRenderers[i].startWidth = (emotion / 20.0f) + variation;
			trailRenderers[i].endWidth = 0.5f + Mathf.Cos(Time.time*trailRenderers[i].startWidth)*trailRenderers[i].startWidth;
			
			trailDanceScripts[i].danceAmplitude = (5.0f + emotion*4.0f) + variation * 10.0f;
			trailDanceScripts[i].danceSpeed = (emotion / 35.0f) + variation * 5.0f;
			trailDanceScripts[i].SetWidthVariation(variation*(emotion/25.0f));
			
			particleSystems[i].emissionRate = (emotion > 15.0f) ? c.a*emotion*2.0f : 0.0f;
			particleSystems[i].startColor = c;
			particleSystems[i].startSize = Mathf.Pow(emotion / 45.0f, 2.0f);
		}
	}
}