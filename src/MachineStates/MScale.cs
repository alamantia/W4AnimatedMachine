// handlers interpolation of scale over time
using System;
using UnityEngine;

public class MScale : MachineState
{
  private int duration;
  private  Vector3 startPosition;
  private  Vector3 endPosition;
  private  Vector3 finishedPosition;

  public override ResultState Tick()
  {
    int currentTime = Environment.TickCount & Int32.MaxValue;

    if (this.startTime == -1) {
      startTime = currentTime;
    }
    
    double input = MapValue (currentTime - startTime, 0.0, 1.0, 0, this.duration);		
    float  t = (float) input;

    Vector3 position = Utils.Lerp(startPosition, endPosition, t);
    gameObject.transform.localScale = position;
    
    if (currentTime >= (startTime + duration)) {
      return ResultState.Finished;
    }
	
    return ResultState.Notfinished;
  }

  public MScale (GameObject gameObject, Vector3 dst, int duration)
  {
    this.gameObject = gameObject;	
    this.startTime = -1;
    this.duration = duration;
    this.startPosition = gameObject.transform.localScale;
    this.endPosition = dst;
  }
}


