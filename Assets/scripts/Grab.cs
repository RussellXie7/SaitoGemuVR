using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {


    public OVRInput.Controller controller;
    public HandController raySource;
    private bool preparedForGrab;
    private GameObject objToGrab;
    private bool botherCheckingRayCast;
    private bool checkEnter;

    void Start() {
        preparedForGrab = false;
        checkEnter = true;
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
        if (checkEnter)
        {
            if (other.tag == "myMap")
            {
                raySource.toggleShowRay(false);
                preparedForGrab = true;
                objToGrab = other.gameObject;

            }

            else if (other.tag == "Gun")
            {
                //raySource.toggleShowRay(false);
                //preparedForGrab = true;
                //objToGrab = other.gameObject;

            }
            else if (other.tag == "WalkieTalkie")
            {
                raySource.toggleShowRay(false);
                preparedForGrab = true;
                objToGrab = other.gameObject;
            }
            else if(other.tag == "BadWalkieTalkie") {
                raySource.toggleShowRay(false);
                preparedForGrab = true;
                objToGrab = other.gameObject;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "myMap" || other.tag == "WalkieTalkie" || other.tag == "BadWalkieTalkie") {
            preparedForGrab = true;
        }
    }

    IEnumerator checkGrabbing() {
        
        while(true) {
            
            if(preparedForGrab) {
                if(OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) {
                    botherCheckingRayCast = false;
                    GrabObj(objToGrab);
                    checkEnter = false;
                    raySource.toggleShowRay(true);
                }
                else if(OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)) {
                    botherCheckingRayCast = true;
                    DropObj(objToGrab);
                    checkEnter = true;
                }

                if(OVRInput.Get(OVRInput.RawButton.LHandTrigger)) {
                    if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {
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

    private void OnTriggerExit(Collider other)
    {
        raySource.toggleShowRay(true);
        preparedForGrab = false;
    }

    void GrabObj(GameObject myObj)
    {
        if(myObj.tag == "myMap") {
            myObj.GetComponent<LerpHalo>().DisableHalo();
            myObj.transform.parent = gameObject.transform;

            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(0.157f, 0.413f, 0.751f);
            myObj.transform.localRotation = Quaternion.Euler(-0.154f, 11.883f, -1.062f);
            raySource.toggleShowRay(true);
        }


        else if (myObj.tag == "WalkieTalkie")
        {
            myObj.GetComponent<LerpHalo>().DisableHalo();
            Debug.Log("Grabbing the walkie talkie");
            myObj.transform.parent = gameObject.transform;
            myObj.GetComponent<Rigidbody>().isKinematic = true;
            myObj.transform.localPosition = new Vector3(-0.043f, -0.738f, -0.243f);
            myObj.transform.localRotation = Quaternion.Euler(11.177f, 91.484f, 16.345f);

            myObj.GetComponent<AudioSource>().Play();
        }

        else if (myObj.tag == "BadWalkieTalkie") {
            myObj.GetComponent<LerpHalo>().DisableHalo();
            Debug.Log("Grabbing the walkie talkie");
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
