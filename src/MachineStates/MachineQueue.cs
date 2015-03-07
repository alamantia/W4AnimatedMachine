using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineQueue
{
  List <List<MachineState>> machines = new List <List<MachineState>>();
  
  GameObject gameObject;

  public MachineQueue(GameObject hostObject)
  {
    this.gameObject = hostObject;
  }

  public void AddMachine(List<MachineState> machine)
  {
    machines.Add(machine);
  }
  
  public void Update()
  {
    if (machines.Count == 0)
      {
	return;
      }
    
    for (int index = machines.Count - 1; index >= 0; index--)
      {
	List <MachineState> machine = machines[index];
	if (machine.Count <= 0)
	  {
	    machines.RemoveAt(index);
	    continue;
	  }
	MachineState machinePart = machine[0]; // needs to be removed!
	machinePart.Start();
	if (machinePart.Tick() == MachineState.ResultState.Finished) {
	  machine.Remove(machinePart);
	}
      }
  }
  
  public void Clear()
  {
    machines.Clear();
  }
  
}