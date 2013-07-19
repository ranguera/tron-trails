using UnityEngine;
using System.Collections;

public class TrailSetup : MonoBehaviour {

	public TrailRenderer trailRenderer;
	public Material[] materialArray;
	
	public void Setup()
	{
		
		float x = 10.0f*Mathf.Sin(Random.value);
		float y = 10.0f*Mathf.Cos(Random.value);
		Vector3 v = new Vector3(x, y, 6.0f);
		this.transform.localPosition = this.transform.parent.position + v;
		
		trailRenderer.startWidth = Random.Range(0.1f, 2.0f);
		trailRenderer.endWidth = Random.Range(0.1f, 2.0f);
		
		int mat = Random.Range (0, materialArray.Length-1);
		trailRenderer.material = materialArray[mat];
	}
	
	public void TrailIntensity(float f)
	{
		renderer.material.SetColor ("_TintColor", new Color(f, f, f, f));
	}
}