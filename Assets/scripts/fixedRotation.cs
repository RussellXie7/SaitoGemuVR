using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedRotation : MonoBehaviour {
    public Transform basedOn;
    private float savedY;
    private float myX;
    private float myZ;

	// Use this for initialization
	void Start () {
        savedY = gameObject.transform.forward.y;
	}
	
	// Update is called once per frame
	void Update () {
        myX = basedOn.forward.x;
        myZ = basedOn.forward.z;

        gameObject.transform.forward = new Vector3(myX, savedY, myZ);

	}
}
