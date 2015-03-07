using System;
using UnityEngine;

public class MMEvent : MachineState
{
  private String eName;

  public override ResultState Tick ()
  {
    gameObject.SendMessage(eName);
    return ResultState.Finished;
  }
  
  public MMEvent (GameObject gameObject, String eventName)
  {
    this.gameObject = gameObject;
    this.eName = eventName;
  }
  
}