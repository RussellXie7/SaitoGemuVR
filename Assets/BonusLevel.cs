using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevel : MonoBehaviour {

    public static bool bonusLevelActivated = false;
    private bool alreadyActivated;
    public Transform crawler;

	// Use this for initialization
	void Start () {
        alreadyActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (bonusLevelActivated == true && alreadyActivated == false) {
            alreadyActivated = true;    
            Debug.Log("Spawning crawler");


            StartCoroutine(SpawnLoop());
        }
    }

    IEnumerator SpawnLoop() {
        int counter = 0;
        while(true) {
            if (counter > 20) { break; }

            yield return new WaitForSeconds(3);

            Debug.Log("spawning another one");

            int spawn_threshold_x = Random.Range(-15, 15);
            int spawn_threshold_z = Random.Range(-15, 15);

            Vector3 spawnloc = new Vector3(this.transform.position.x + spawn_threshold_x, 0.35f, this.transform.position.z + spawn_threshold_z);
            var newCrawler = Instantiate(crawler, spawnloc, transform.rotation);
            newCrawler.GetComponent<chase>().player = this.transform;




        }

    }
}
