using UnityEngine;
using System.Collections;

public class TrailSetup : MonoBehaviour {

	public TrailRenderer trailRenderer;
	public Material[] materialArray;
	
	public void Setup()
	{
		trailRenderer.startWidth = Random.Range(0.1f, 2.0f);
		trailRenderer.endWidth = Random.Range(0.1f, 2.0f);
		
		int mat = Random.Range (0, materialArray.Length-1);
		trailRenderer.material = materialArray[mat];
	}
}
