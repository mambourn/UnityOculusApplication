using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    //30 frames per second, 5 seconds = 150 frames
	public float lifeTime = 150;
	private light singleLight;

	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {		
		//lifetime of object
        if(lifeTime >0){
			lifeTime -= Time.deltaTime;		//count down of object life
			if(lifeTime <=0){
				Destruction();
			}
		}
		
		
    }
	
	void Destruction(){
		//turn out lights
		for(int i = 1; i<6; i++){
			//access target destroy function
			GameObject lightI = GameObject.Find($"light{i}");
			singleLight = lightI.GetComponent<light>();
			//when item is destroyed, signal light.cs to turn off the lights
			singleLight.lightsOff = true;
		}
		
		Destroy(this.gameObject);
	}
	
	
}
