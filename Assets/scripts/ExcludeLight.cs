 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 public class ExcludeLight : MonoBehaviour {
 
     public Light light;
     public bool cullLights = true;
 
     
     void OnPreCull(){
         if(cullLights == true) {
             
                 light.enabled = false;
             
         }
     }
     
     void OnPostRender(){
         if(cullLights == true) {

                 light.enabled = true;
             
         }
     }
     
 }