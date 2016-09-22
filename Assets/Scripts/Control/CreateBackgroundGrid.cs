using UnityEngine;
using System.Collections;

public class CreateBackgroundGrid : MonoBehaviour {
	
	public GameObject grid;
	
	private ArrayList grids;
	
	// Use this for initialization
	void Start () {
		
		grids = new ArrayList();
		
		for (int i = -2000; i < 2001; i+=500) {
			for (int j = -2000; j < 2001; j+=500) {
				Vector3 v = new Vector3(0, i, j);
				GameObject tmp = (GameObject) Instantiate(grid, v, Quaternion.identity);
				tmp.transform.parent = this.transform;
				grids.Add(tmp);
			}
		}
		
		for (int i = -2000; i < 2001; i+=500) {
			for (int j = -2000; j < 2001; j+=500) {
				Vector3 v = new Vector3(i, 0, j);
				float angle = 56.8f * Mathf.Deg2Rad;
				GameObject tmp = (GameObject) Instantiate(grid, v, new Quaternion(0.0f, 0.0f, 1.0f, angle));
				tmp.transform.parent = this.transform;
				grids.Add(tmp);
			}
		}
		
		for (int i = -2000; i < 2001; i+=500) {
			for (int j = -2000; j < 2001; j+=500) {
				Vector3 v = new Vector3(i, j, 0);
				float angle = 56.8f * Mathf.Deg2Rad;
				GameObject tmp = (GameObject) Instantiate(grid, v, new Quaternion(0.0f, 1.0f, 0.0f, angle));
				tmp.transform.parent = this.transform;
				grids.Add(tmp);
			}
		}
	}
}
