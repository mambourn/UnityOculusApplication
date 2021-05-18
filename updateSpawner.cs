using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateSpawner : MonoBehaviour
{
	private spawner spawner;
	
    // Start is called before the first frame update
    void Start()
    {
         //access random distance from spawner script
		GameObject thePlayer = GameObject.Find("OVRPlayerController");
		spawner = thePlayer.GetComponent<spawner>();
        
		transform.position = new Vector3(spawner.posX,0,spawner.posZ);

    }

    // Update is called once per frame
    void Update()
    {
       
		
    }
}

