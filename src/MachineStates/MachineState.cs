// For the most part this is just used for keeping track of time within the machine.
using System;
using UnityEngine;

public class MachineState
{
	public enum ResultState
	{
		Finished,
		Notfinished,
	};
  
	protected GameObject gameObject;
	protected int startTime  = -1; 
	public int  stage; // This will be used when we desire to run more then one of the machines at once.
							  // Part of me would really like to experiment with just making use of multiple machines and supporting that.

	public bool loop;
	
	// These are deprecated -- they should not be used anymore
	public  double d1;
	public  double d2;
	public  double d3;
	
	public int Time()
	{
		int currentTime = Environment.TickCount & Int32.MaxValue;
		return currentTime - startTime;
	}
	
	public double TimeLerp(int endTime)
	{
		int totalTime =  (Environment.TickCount & Int32.MaxValue) - startTime;
		return MapValue(totalTime, 0.0, 1.0, 0, endTime); 		
	}
	
	public double MapValue (double value, double toMin, double toMax, double fromMin, double fromMax)
	{
		return toMin + (toMax - toMin) *  ((value - fromMin) / (fromMax - fromMin));
	}
	
	// This is not an actual lerp why is this here.
	public double Lerp(int runTime, double startValue, double endValue)
	{
		int endTime = startTime + runTime;
		return 0.0;
	}

	public void Reset()
	{
		Debug.Log("Reset");
		d1 = 0.0;
		d2 = 0.0;
		d3 = 0.0;
		startTime  = Environment.TickCount & Int32.MaxValue; 
	}

	public virtual void Start()
	{

	}

	public virtual ResultState Tick()
	{
		return ResultState.Notfinished;
	}
	
	public MachineState()
	{

	}
}
