// Control movement of the entity over time.
// Standard linear interpolation method
//
// This must touch the state of the gameObject itself
//x
using System;
using UnityEngine;

public class MMove : MachineState
{
  private  int duration;
  private  Vector3 startPosition;
  private  Vector3 endPosition;
  private  Vector3 finishedPosition;

  public override ResultState Tick ()
  {
    int currentTime = Environment.TickCount & Int32.MaxValue;

    if (this.startTime == -1) {
      startTime = currentTime;
    }
    
    double input = MapValue (currentTime - startTime, 0.0, 1.0, 0, this.duration);		
    float  t = (float) input;

    // Now just interpolate beteen the start and end points using whatever function we would like to
    Vector3 position = Utils.Lerp(startPosition, endPosition, t);
    /*
    Vector3 position = Utils.Curve(startPosition, endPosition, 
			     new Vector3(startPosition.x - 4.0f, startPosition.y + 0.5f, 0.0f), 
			     new Vector3(startPosition.x - 4.0f, endPosition.y, 0.0f), 
			     t);
    */
    gameObject.transform.position = position;

    // Check the time for an exit condition (this terminates the current process)

    if (currentTime >= (startTime + duration)) {
      return ResultState.Finished;
    }

    return ResultState.Notfinished;
  }

	public override void Start ()
	{
		this.startPosition = gameObject.transform.position;
	}
  public MMove (GameObject gameObject, Vector3 dst, int duration)
  {
    this.gameObject = gameObject;	
    this.startTime = -1;
    this.duration = duration;
    this.startPosition = gameObject.transform.position;
    this.endPosition = dst;
  }
}

