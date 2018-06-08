using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    public GameObject player;
    public GameObject theArrow;
    public float sensitiveDistance;
    public float targetSensitiveDis;
    private void Start()
    {
        StartCoroutine(Look());
    }
    // Update is called once per frame
    void Update () {

    }

    IEnumerator Look()
    {
        while (true)
        {
            float distance = Vector3.Distance(player.transform.position, theArrow.transform.position);
            float distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
            if (distance > sensitiveDistance && distanceToTarget > targetSensitiveDis)
            {
                theArrow.SetActive(true);
                Vector3 relativePos = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                Vector3 eulerRotation = rotation.eulerAngles;
                Vector3 correctedRotation = new Vector3(0, eulerRotation.y, 0);
                transform.rotation = Quaternion.Euler(correctedRotation);
            }
            else {
                theArrow.gameObject.SetActive(false);
            }
            //Debug.Log(distanceToTarget);
            if(distanceToTarget < 3) {
                DisableMe();
            }
            yield return null;
        }
    }



    private void DisableMe()
    {
        gameObject.SetActive(false);   
    }
}
