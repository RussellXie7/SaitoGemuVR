using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    public Transform handTransform; // Gets the transformation of the hand
    private GameObject myLine; // The line that gets drawn
    public GameObject player;
    public GameObject port;
    public GameObject rightController;

    private GameObject myPort;
    


    private bool isShowRay;



    public void toggleShowRay(bool isShow) {
        isShowRay = isShow;
    }

	// Use this for initialization
	void Start () {
        isShowRay = true;

        myLine = new GameObject(); // Initialize raycast line that gets drawn

        myLine.AddComponent<LineRenderer>();
        myLine.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		if(isShowRay && !OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            ActivateRaycast();
        } else {
            DeactivateRaycast();
        }
	}


    void ActivateRaycast() {
        myLine.SetActive(true);

        Ray myRay = new Ray(handTransform.position, handTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, Mathf.Infinity)) {
            DrawLine(handTransform.position, hit.point, Color.green);

            if(hit.collider.gameObject.CompareTag("Ground"))
            {
                if (OVRInput.GetDown(OVRInput.RawButton.X))
                {
                    if (myPort == null) {
                        Vector3 relativePos = new Vector3(hit.point.x - player.transform.position.x, 0, hit.point.z - player.transform.position.z);
                        Quaternion rotation = Quaternion.LookRotation(relativePos);
                        myPort = (GameObject)Instantiate(port, hit.point, rotation);
                       

                    }
                }

                if (OVRInput.Get(OVRInput.RawButton.X)) {
                    if(myPort == null)
                    {
                        Vector3 relativePos = new Vector3(hit.point.x - player.transform.position.x, 0, hit.point.z - player.transform.position.z);
                        Quaternion littleRotation = Quaternion.LookRotation(relativePos);
                        myPort = (GameObject)Instantiate(port, hit.point, littleRotation);
                    }
                    myPort.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                    Quaternion rotation = Quaternion.LookRotation(rightController.transform.forward);
                    Vector3 eulerRotation = rotation.eulerAngles;
                    Vector3 correctedRotation = new Vector3(0, eulerRotation.y, 0);
                    myPort.transform.rotation = Quaternion.Euler(correctedRotation);
                }
                

                if (OVRInput.GetUp(OVRInput.RawButton.X))
                {
                    if (myPort)
                    {

                        player.transform.position = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
                        player.transform.forward = myPort.transform.GetChild(1).transform.forward;
                        Debug.Log(myPort.transform.GetChild(1).gameObject);
                        GameObject.Destroy(myPort);
                        myPort = null;
                    }
                }

            }
            else
            {
                if (myPort)
                {
                    GameObject.Destroy(myPort);
                    myPort = null;
                }
            }


        }

    }

    void DeactivateRaycast() {
        myLine.SetActive(false);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color) {
        myLine.transform.position = start;
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.01f, 0.01f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

}
