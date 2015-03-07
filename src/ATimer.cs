// Small helper class to assist with timing .. etc
using UnityEngine;
using System.Collections;
using System;

public class ATimer  {
	public String payload; // not 100% sure if we actually want to use this
  	private int lastTick = Environment.TickCount & Int32.MaxValue; 
	private int tickMS;
	public delegate void OnTickCallback();
	private bool running = false;
	private bool looping = false;
	private OnTickCallback FireCallback;
	public bool CanDestory()
	{
		return false;
	}

	public void Start (int ms, bool loop, OnTickCallback callback) 
	{
		tickMS = ms;
		looping = loop;
		running = true;
		FireCallback = callback;
	}
	
	void Tick()
	{
		int currentTime = Environment.TickCount & Int32.MaxValue;
		if (currentTime - lastTick < tickMS) {
			return;
		}	
		FireCallback();
		lastTick = Environment.TickCount & Int32.MaxValue;
	}

	// Update is called once per frame
	public void Update () {
		if (running == true) {
			Tick();	
		}
	}
}
