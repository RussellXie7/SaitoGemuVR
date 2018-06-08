using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonInteractive : MonoBehaviour
{

    private Color savedColor;
    private bool fogState;
    // Use this for initialization
    void Start()
    {
        savedColor = transform.GetComponentInParent<Image>().color;
        fogState = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("LALALA");
        if (collision.gameObject.tag == "FingerTip")
        {
            transform.GetComponentInParent<Image>().color = Color.red;
            Debug.Log(this.tag);
               
            if(this.tag == "FogMenu") {
                ToggleFog();
            }

            if(this.tag == "RestartMenu") {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }


        }
    }


    void ToggleFog() {
        fogState = !fogState;
        RenderSettings.fog = fogState;
    }


    void OnTriggerExit(Collider collision)
    {
        transform.GetComponentInParent<Image>().color = savedColor;
    }
}
