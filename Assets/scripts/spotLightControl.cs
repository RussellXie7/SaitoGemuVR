using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLightControl : MonoBehaviour {
    private void Start()
    {
        gameObject.GetComponent<Light>().enabled = false;
        ((Behaviour)gameObject.GetComponent("Halo")).enabled = false;
    }
    public void toggleSpotLight(bool toggle) {
        gameObject.GetComponent<Light>().enabled = toggle;
        ((Behaviour)gameObject.GetComponent("Halo")).enabled = toggle;
         
    }
}
