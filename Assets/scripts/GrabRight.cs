using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRight : MonoBehaviour {


    public OVRInput.Controller controller;
    private bool preparedForGrab;
    private GameObject objToGrab;
    private bool botherCheckingRayCast;
    private bool checkEnter;

    void Start()
    {
        checkEnter = true;
        preparedForGrab = false;
        botherCheckingRayCast = true;
        StartCoroutine(checkGrabbing());
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the tag is equal to grabble, then call the lightmeUp method
        // grabbale need a rigidbody (change kinematic) grabbable need 
        // and disable the raycast on the hand
        // if the index is touched, then call the grab method in this script
        // if index is no longer touched, call the drop method,
        // need to save the parent of grabbable,
        if (checkEnter)
        {
            if (other.tag == "myMap")
            {
                preparedForGrab = true;
                objToGrab = other.gameObject;

            }

            else if (other.tag == "Gun")
            {
 
                preparedForGrab = true;
                objToGrab = other.gameObject;

            }
            else if (other.tag == "WalkieTalkie")
            {

                preparedForGrab = true;
                objToGrab = other.gameObject;

            }
            else if (other.tag == "BadWalkieTalkie")
            {

                preparedForGrab = true;
                objToGrab = other.gameObject;


            }
        }
    }
    IEnumerator checkGrabbing()
    {

        while (true)
        {
            if (preparedForGrab)
            {
                if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
                {
                    botherCheckingRayCast = false;
                    GrabObj(objToGrab);
                    checkEnter = false;

                }
                else if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
                {
                    botherCheckingRayCast = true;
                    DropObj(objToGrab);
                    checkEnter = true;
                }


                if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
                {
                    if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                    {
                        if (objToGrab.gameObject.tag == "Gun")
                        {
                            objToGrab.gameObject.GetComponentInChildren<ShootButtlet>().Fire();
                        }
                    }
                }
            }
            yield return null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "myMap" || other.tag == "Gun" || other.tag =="WalkieTalkie" || other.tag == "BadWalkieTalkie")
        {
            preparedForGrab = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        preparedForGrab = false;
    }

    void GrabObj(GameObject myObj)
    {
        if (myObj.tag == "myMap")
        {
            myObj.GetComponent<LerpHalo>().DisableHalo();
            myObj.transform.parent = gameObject.transform;

            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(-0.202f, 0.074f, 0.812f);
            myObj.transform.localRotation = Quaternion.Euler(-20.64f,163.45f, 0.047f);
        }

        else if (myObj.tag == "Gun")
        {
            myObj.GetComponent<LerpHalo>().DisableHalo();
            myObj.transform.parent = gameObject.transform;
            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(0.147f, -0.106f, 0.219f);
            myObj.transform.localRotation = Quaternion.Euler(-106.74f, 130.049f, 64.38f);
            myObj.GetComponentInChildren<spotLightControl>().toggleSpotLight(true);
        }

        else if (myObj.tag == "WalkieTalkie")
        {
            Debug.Log("Grabbing the walkie talkie");
            myObj.GetComponent<LerpHalo>().DisableHalo();

            myObj.transform.parent = gameObject.transform;
            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(-0.043f,-0.738f,-0.243f);
            myObj.transform.localRotation = Quaternion.Euler(11.177f,91.484f,16.345f);

            myObj.GetComponent<AudioSource>().Play();
        }

        else if (myObj.tag == "BadWalkieTalkie")
        {
            Debug.Log("Grabbing the walkie talkie");
            myObj.GetComponent<LerpHalo>().DisableHalo();

            myObj.transform.parent = gameObject.transform;
            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(-0.043f, -0.738f, -0.243f);
            myObj.transform.localRotation = Quaternion.Euler(11.177f, 91.484f, 16.345f);

            myObj.GetComponent<AudioSource>().Play();
            BonusLevel.bonusLevelActivated = true;

        }
    }

    void DropObj(GameObject myObj)
    {
        if (myObj.tag == "myMap")
        {
            myObj.transform.parent = null;
            myObj.GetComponent<Rigidbody>().isKinematic = false;
            myObj = null;
        }

        else if (myObj.tag == "Gun")
        {
            myObj.transform.parent = null;
            myObj.GetComponent<Rigidbody>().isKinematic = false;
            myObj = null;
        }

        else if (myObj.tag == "WalkieTalkie")
        {
            myObj.transform.parent = null;
            myObj.GetComponent<Rigidbody>().isKinematic = false;
            myObj = null;
        }

        else if (myObj.tag == "BadWalkieTalkie")
        {
            myObj.transform.parent = null;
            myObj.GetComponent<Rigidbody>().isKinematic = false;
            myObj = null;
        }
    }
}
