using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemy : MonoBehaviour {

    public GameObject explode;


    private GameObject myExplode;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy") {
            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>();
            }
            myExplode = (GameObject)Instantiate(explode, other.transform.position, Quaternion.Euler(-90f, -90f, -90f));
            Destroy(other,0.1f);
            Destroy(myExplode, 10f);
        }
    }
}
