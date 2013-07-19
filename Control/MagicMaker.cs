using UnityEngine;
using System.Collections;

public class MagicMaker : MonoBehaviour {
	
	public GameObject trail;
	public int maxTrails = 100;
	
	private ArrayList trails;
	private int numTrails;
	// Use this for initialization
	void Start () {
		numTrails = 0;
		trails = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		if( Random.value < 0.01f && numTrails < maxTrails)
		{
			GameObject tmp = (GameObject) Instantiate(trail, this.transform.position, Quaternion.identity);
			tmp.transform.parent = this.transform;
			TrailSetup ts = tmp.GetComponent<TrailSetup>();
			ts.Setup();
			ts.TrailIntensity(Random.value);
			trails.Add(ts);
			numTrails++;
		}
	}
}
