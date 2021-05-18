using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;	//for enumerables

public class spawner : MonoBehaviour
{
	public Transform spawnPos;
	public GameObject spawnee;
	public int posZ;
	public Vector3 pos;
	int[] arr;
	
	// Start is called before the first frame update
	void Start()
    {
        Debug.Log("Starting Experiment");
		arr = new int[]{0,0,0,0,0};
    }


    // Update is called once per frame
    void Update()
    {
		bool endOfTrial;
		
		//for random distance generation
		bool foundUnusedRandom;
		HashSet<int> exclude = new HashSet<int>();
		var rand = new System.Random();;
		int index;
		
		//alternate options for clicks: 
		//Input.GetMouseButtonDown(0) - left click with mouse
		//Input.GetKey("Appear") - oculus controllers, had to change the name in button manager from Fire1
		//Input.GetButtonUp("Submit") - enter on keyboard
		if(Input.GetButtonUp("Submit")){		
					
			//randomize the distance to be used
			foundUnusedRandom = false; 	//false until unused random has been selected
			while(!foundUnusedRandom){
				
				//randomize the distance with exclusions 
				var range = Enumerable.Range(1, 5).Where(i => !exclude.Contains(i));
				index = rand.Next(0, 5 - exclude.Count);
				posZ = range.ElementAt(index);
				
				//posZ = Random.Range(1,5);			//randomize the distance
				if(arr[posZ-1] < 3){		
					//distance hasn't been used 3 times
					foundUnusedRandom = true;
					arr[posZ-1]= arr[posZ-1]+1;
				}
				else{
					//add item to exlusions hashset
					exclude.Add(posZ);
				}
			}
						
			Debug.Log(posZ);		//displays distance in console
			//TODO y should be about the height of item?
			pos = new Vector3(spawnPos.position.x,3,posZ);
		
			Instantiate(spawnee, pos, spawnPos.rotation);
			
			//all distances completed
			endOfTrial = true;
			for(int i =0; i <5; i++){
				if (arr[i]!=3){
						endOfTrial = false;
						break;
				}
			} 
			if(endOfTrial){
					Debug.Log("end of trial");
			}
		}	
    }
}
