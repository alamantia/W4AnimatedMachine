using System;
using UnityEngine;
public class MRotate : MachineState
{
	float target;
	float total_moved;
	
	public override ResultState Tick ()
	{
		// TODO make this bound by time as well
		Vector3 r = gameObject.transform.eulerAngles;			
		r.z  += 1.0f;
		total_moved += 1.0f;
		gameObject.transform.eulerAngles = r;
		if (total_moved >= target) {
			return ResultState.Finished;
		}
		return ResultState.Notfinished;
	}
	
	public MRotate (GameObject gameObject, float value, int time)
	{
		this.target = value;
		this.gameObject = gameObject;		
	}	
}
