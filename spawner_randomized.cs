using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;	//for enumerables
using System;		//for Math functions

public class spawner_randomized : MonoBehaviour
{
	public Transform spawnPos;
	public GameObject spawnee;
	public float posZ;
	public float posX;
	float posZ_noOffset;
	float posX_noOffset;
	int[] arr;
	int dist;
	
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
				
		if(Input.GetButtonUp("Appear")){	//mapped in project settings -> input manager		
					
			//randomize the distance to be used
			foundUnusedRandom = false; 	//false until unused random has been selected
			while(!foundUnusedRandom){
				
				//randomize the distance with exclusions 
				var range = Enumerable.Range(1, 5).Where(i => !exclude.Contains(i));
				index = rand.Next(0, 5 - exclude.Count);
				dist = range.ElementAt(index);
								
				if(arr[dist-1] < 3){		
					//distance hasn't been used 3 times
					foundUnusedRandom = true;
					arr[dist-1]= arr[dist-1]+1;
				}
				else{
					//add item to exlusions hashset
					exclude.Add(dist);
				}
			}
						
			Debug.Log($"Distance: {dist}");		//displays distance in console
			
			
			//for variable position of start
			GameObject startPos = GameObject.Find("startPoint");
						
			float calculated_dist = (float) Math.Sqrt(Math.Pow(dist,2)/2);	// value in units
			//35 units = 9.3m by 34.5 units = 9.17m, 1m = 3.76
			//multiply by real world ratio 1.95
			posX_noOffset = calculated_dist*((float)3.76);
			posZ_noOffset = calculated_dist*((float)3.76);
						
			//account for starting position (around 11.232,0,8.352)
			posX = startPos.transform.position.x - posX_noOffset;
			posZ = startPos.transform.position.z - posZ_noOffset;
			
			
			Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
			
			
			
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

