using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtlet : MonoBehaviour {
    public GameObject bullet;
    public GameObject gunExplode;
    public Transform spawnPos;
    public float fireForce = 500f;

    private GameObject myBullet;
    private GameObject myExplode;


	public void Fire() {
        myBullet = (GameObject)Instantiate(bullet, spawnPos.transform.position, Quaternion.Euler(-90f,-90f,-90f));
        myExplode = (GameObject)Instantiate(gunExplode, spawnPos.transform.position, Quaternion.Euler(-90f, -90f, -90f));
        myBullet.GetComponentInChildren<Rigidbody>().velocity = gameObject.transform.forward * fireForce;
        myBullet.GetComponentInChildren<Rigidbody>().useGravity = false;

        Destroy(myBullet, 1);
        Destroy(myExplode, 0.2F);
        myBullet = null;
    }
}
