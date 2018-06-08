using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFingerTip : MonoBehaviour {

    public GameObject fingertip;
    public float offset;

	// Use this for initialization
	void Start () {
        StartCoroutine(addCube());
	}
	
    IEnumerator addCube() {
        while(true) {
            if(transform.childCount != 0) {
                Transform finger = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0);
                Debug.Log(finger.gameObject.name + "!!!!!!!!!!!!!!");
                GameObject myTip = (GameObject)Instantiate(fingertip, finger.position, finger.rotation);
                myTip.transform.parent = finger;
                myTip.transform.localPosition = new Vector3(offset, 0, 0);
                break;
            }
            yield return null;
        }
        yield return null;
    }
	// Update is called once per frame
	void Update () {
	    	
	}
}
