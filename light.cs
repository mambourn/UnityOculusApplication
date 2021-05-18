using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
	Light myLight;
	public bool lightsOff;
	
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
		lightsOff = false;
    }

    // Update is called once per frame
    void Update()
    {		
		//turn on lights when button pressed
		if(Input.GetButtonUp("Lights")){
			myLight.enabled = true;
		}
		
		//if destroyer class changed lightsOff to true
		if(lightsOff){
			myLight.enabled = false;
			lightsOff = false; 		//reset variable
		}
		
    }
}
