using System;
using UnityEngine;
public class MColor : MachineState
{
  private Color targetColor;
  private Color startColor;
  private int     duration;
	
  public MColor (GameObject gameObject, Color targetColor, int duration)
  {
    this.gameObject     = gameObject;
    this.targetColor 	= targetColor;
	if (gameObject.GetComponent<Renderer> () != null) {
		this.startColor = gameObject.GetComponent<Renderer> ().material.color;
	}
    this.duration 		= duration;
    this.startTime 		= -1;
  }
	
  public override ResultState Tick ()
  {	
    // Abstract this.
    int currentTime = Environment.TickCount & Int32.MaxValue;
    if (this.startTime == -1) {
      startTime = currentTime;
    }		
    int runTime = this.duration;
    double timeLerp = TimeLerp(runTime);
    gameObject.GetComponent<Renderer>().material.color = Color.Lerp(startColor, targetColor, (float)timeLerp);
    if (timeLerp >= 1.0) {
	  gameObject.GetComponent<Renderer>().material.color = this.targetColor;
      return ResultState.Finished;
    }
    return ResultState.Notfinished;
  }
}
