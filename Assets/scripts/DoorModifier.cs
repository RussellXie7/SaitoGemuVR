using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorModifier : MonoBehaviour {

    public GameObject finalWayfinding;

	// Use this for initialization
	void Start () {
        Debug.Log("Current door state is " + KeypadInteractive.doorOpened);
	}
	
	// Update is called once per frame
	void Update () {
        if (KeypadInteractive.doorOpened)
        {
            Vector3 startPos = this.gameObject.transform.position;
            Vector3 targetPos = new Vector3(-13f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            float speed = 0.05f;

            this.gameObject.transform.position = Vector3.MoveTowards(startPos, targetPos, speed);
            finalWayfinding.SetActive(true);

            //this.gameObject.transform.localScale = new Vector3(0.75f, 2.53754f, 0.19853f);

        }
	}
}
