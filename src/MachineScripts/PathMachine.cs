using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

class PathMachine
{
	private Vector3 startPosition;
	private Vector3 endPosition;
	// in time this should accept an object that impls some interface for pathing to a specific point
	private int pathType = 0;

	// the most simple method we can use 	
	//  (1 cos^2(x)) + (3 sin^2(x))
	void Function_1 (float t)
	{
		double s = 0.0;
		double e = 40.0;
		// unwrap the two endpoints of the equation so the solver can operate effectively 
		double r = s * Mathf.Pow(Mathf.Cos(t), 2);		
	}
	
	public PathMachine()
	{

	}

}
