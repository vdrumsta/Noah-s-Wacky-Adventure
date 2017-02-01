using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	
	private Vector3 spawnPos;
	public Vector3 defaultSpawnPos;
	public int checkPointNum;

	// Use this for initialization
	void Start () {
	
		//DontDestroyOnLoad (this);

		spawnPos.x = PlayerPrefs.GetFloat("spawnPosX");
		spawnPos.y = PlayerPrefs.GetFloat("spawnPosY");
		spawnPos.z = PlayerPrefs.GetFloat("spawnPosZ");

		if (spawnPos == new Vector3 (0,0,0)){
			//			spawnPos = new Vector3 (-44, 55, 1);
			spawnPos = defaultSpawnPos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 getSpawn(){

		return spawnPos;
	}

	public void SetSpawn(Vector3 spawnPos2){

		spawnPos = spawnPos2;
		PlayerPrefs.SetFloat("spawnPosX", spawnPos.x);
		PlayerPrefs.SetFloat("spawnPosY", spawnPos.y);
		PlayerPrefs.SetFloat("spawnPosZ", spawnPos.z);
		PlayerPrefs.Save ();
		//checkPointNum = num;
	}
}
