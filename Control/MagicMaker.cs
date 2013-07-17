using UnityEngine;
using System.Collections;

public class MagicMaker : MonoBehaviour {
	
	public GameObject trail;
	public int maxTrails = 100;
	
	private int numTrails;
	// Use this for initialization
	void Start () {
		numTrails = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if( Random.value < 0.01f && numTrails < maxTrails)
		{
			float x = 3*Mathf.Sin(Random.value);
			float y = 3*Mathf.Cos(Random.value);
			
			Vector3 v = new Vector3(x, y, 0.0f);
			
			GameObject tmp = (GameObject) Instantiate(trail, this.transform.position + v, Quaternion.identity);
			tmp.transform.parent = this.transform;
			TrailSetup ts = tmp.GetComponent<TrailSetup>();
			ts.Setup();
			numTrails++;
		}
	}
}
