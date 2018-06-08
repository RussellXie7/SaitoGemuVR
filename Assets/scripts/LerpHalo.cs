using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHalo : MonoBehaviour {
    bool shouldActive;
    Behaviour myHalo;
    Light myLight;
    float lightIntensity;

	// Use this for initialization
	void Start () {
        shouldActive = true;
        myHalo = (Behaviour)gameObject.GetComponent("Halo");
        myLight = gameObject.GetComponent<Light>();
        lightIntensity = 0;
        myLight.intensity = lightIntensity;
    }

    private void Update()
    {
        myLight.intensity = Mathf.Lerp(0f, 6f, Mathf.PingPong(Time.time, 1));
    }

    public bool DisableHalo()
    {
        myHalo.enabled = false;
        myLight.enabled = false;
        return true;
    }
}
