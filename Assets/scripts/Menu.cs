using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private bool isShowing;
    public GameObject menu; // Assign in inspector


    // Use this for initialization
    void Start () {
        Debug.Log("menu script is on");
        menu.SetActive(false);

        StartCoroutine(CheckingMenu());

    }
	
    IEnumerator CheckingMenu() {
        while(true) {
            //Debug.Log(OVRInput.GetDown(OVRInput.RawButton.Y));
/*            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                isShowing = !isShowing;
                menu.SetActive(isShowing);
            }
 */

            bool currentShowState = UDP_RecoServer.isShowingMenu;
            menu.SetActive(currentShowState);


            yield return null;
        }
    }



	// Update is called once per frame
	void Update () {




    }
}
