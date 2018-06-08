using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KeypadInteractive : MonoBehaviour
{

    public GameObject inputValue; // Modify this text field 
    private Color savedColor;
    public static bool doorOpened = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Keypad Interactive started");
        savedColor = transform.GetComponentInParent<Image>().color;
        inputValue.GetComponent<Text>().text = ""; // Initialize text field as the empty string

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("KeypadInteractive tigger entered");
        if (collision.gameObject.tag == "FingerTip")
        {
            transform.GetComponentInParent<Image>().color = Color.red;
            //Debug.Log(this.tag);

            //Debug.Log("the name of the collided object is: " + this.gameObject.name);


            this.gameObject.GetComponent<AudioSource>().Play();


            if (this.gameObject.name != "clear" && this.gameObject.name != "submit")
            {

                string curr_val = inputValue.GetComponent<Text>().text;
                inputValue.GetComponent<Text>().text = curr_val + this.gameObject.name;
            }

            if (this.gameObject.name == "clear") {
                clearText();
            }

            if (this.gameObject.name == "submit") {
                handleSubmit();
            }


        }
    }

    void handleSubmit() {
        Debug.Log("Handle the submit!!!!");

        if (inputValue.GetComponent<Text>().text == "1153")
        {
            inputValue.GetComponent<Text>().text = "SUCCESS";
            doorOpened = true;
        }
        else
        {
            inputValue.GetComponent<Text>().text = "Please Clear and try again";
        }

    }


    void clearText() {
        inputValue.GetComponent<Text>().text = "";
    }

    void OnTriggerExit(Collider collision)
    {
        transform.GetComponentInParent<Image>().color = savedColor;
    }
}
