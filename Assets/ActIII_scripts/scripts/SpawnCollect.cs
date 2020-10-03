using UnityEngine;
using System.Collections;

public class SpawnCollect : MonoBehaviour {

    public GameObject collectible;
    int spawnNum = 8;

    void spawn()
    {
        for(int i = 0; i< spawnNum; i++)
        {
            Vector3 collPos = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f),
                this.transform.position.y + Random.Range(0.0f, 2.0f),
                this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(collectible, collPos, Quaternion.identity);
        }
    }
	// Use this for initialization
	void Start () {
        spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
