/// <summary>
/// Door Behaviour Script
/// M A Plant
/// 02.07.2015
/// 
/// Controller for Animation Delay of the Doors at each section inter change.
/// </summary>

using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {
	
	public  bool playAnim ;
	public int _timer = 10;
	public int time;
	public int increment = 1;
	public TextMesh timer;
	public Animation move;

	void Start(){

		playAnim = true;
		StartCoroutine (countdown());		// This starts the Timer Co-Routine
	}
	
	void Update(){
		
		if(playAnim){
			
			playAnim = false;
			StartCoroutine(Wait());			// This starts the Animation Wait Co-Routine
			
		}
	}

	//This Co-Routine Controls the Animation Delay 
	
	public  IEnumerator Wait(){
		
		yield return new WaitForSeconds(_timer);
		move.Play("DoorClose 1");
	}


	// This Co-Routine Controls the counter

	IEnumerator countdown()
	{
		while (time >= 0)
		{
			yield return new WaitForSeconds(1);
			
			timer.text = time.ToString();
			
			time -= increment;
		}
		
		timer.text = "Door Sealed";
	}
}