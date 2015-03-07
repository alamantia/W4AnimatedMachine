using System;
using UnityEngine;

public class MFire : MachineState
{ 
	private int duration;
	public MFire (GameObject gameObject)
	{
			this.gameObject = gameObject;
			this.startTime = -1;
			this.duration = duration;
	}
	public override ResultState Tick ()
	{	
		gameObject.SendMessage ("FireBullet");
		return ResultState.Finished;
	}
}
