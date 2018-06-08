using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private float savedY;
    private float offsetX;
    private float offsetZ;
    private float updatedX;
    private float updatedZ;


	// Use this for initialization
	void Start () {
        savedY = transform.position.y;
        offsetX = gameObject.transform.position.x - player.position.x;
        offsetZ = gameObject.transform.position.z - player.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        updatedX = player.position.x + offsetX;
        updatedZ = player.position.z + offsetZ;

        transform.position = new Vector3(updatedX, savedY, updatedZ);
	}
}
