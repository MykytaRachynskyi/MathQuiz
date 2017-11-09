using UnityEngine;
using System.Collections;

public class SpawningCubes : MonoBehaviour {

	public GameObject spawn;
	public GameObject cube;
	public Texture One, Two, Three;

	private int dice;
	private Renderer rend;

	void Start ()
	{
		

		for (int i = 0; i < 5; i++) {
			spawnBlocks();
		}


		StartCoroutine(SpawningBlocks());
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}

	void spawnBlocks (){
		GameObject clone;
			Vector3 pos = spawn.transform.position;
			pos.x += Random.Range(-15.0f, 15.0f);
			pos.y += Random.Range(-3.0f, 3.0f);
			pos.z += Random.Range(-15.0f, 15.0f);

			Quaternion rotation = Quaternion.Euler (Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

			clone = Instantiate(cube, pos, rotation) as GameObject;

			rend = clone.GetComponent<Renderer>();

			dice = Random.Range(1, 4);
			switch (dice) {
				case 1: 
					rend.material.mainTexture = One;
					break;
				case 2:
					rend.material.mainTexture = Two;
					break;
				case 3:
					rend.material.mainTexture = Three;
					break;
				}
	}

	public IEnumerator SpawningBlocks ()
	{
		while (true) {
			spawnBlocks ();
			yield return new WaitForSeconds (Random.Range (1.0f, 5.0f));
		}
	}
}
