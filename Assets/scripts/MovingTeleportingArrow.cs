using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTeleportingArrow : MonoBehaviour {

    public float goUp;
    public float goDown;


    float storedX;
    float storedY;
    float storedZ;

    float bigZ;
    float smallZ;


	// Use this for initialization
	void Start () {
        storedX = transform.localPosition.x;
        storedY = transform.localPosition.y;
        storedZ = transform.localPosition.z;

        bigZ = storedZ + goUp;
        smallZ = storedZ - goDown;

    }
	
	// Update is called once per frame
	void Update () {
        float z = Mathf.Lerp(smallZ, bigZ, Mathf.PingPong(Time.time, 1));

        transform.localPosition = new Vector3(storedX, storedY, z);
    }
}
