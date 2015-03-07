using UnityEngine;
using System.Collections;

/*
 * 
 * 

// Add a few machines that we can use to direct the object
  // We need to figure out what paths our objects will actually take.
  // And create the needed subclasses and explosions .. etc
  void MoveComplete() 
  {
		Debug.Log ("Move Complete");
  }

 void RotateComplete()
{
	List <MachineState> machineList = new List<MachineState> ();  	
	machineList.Add(new MRotate(gameObject, 25.0f, 500));
	machineList.Add(new MColor(gameObject, attackColor, 500));
	machineList.Add(new MFire(gameObject));
	machineList.Add(new MSleep(200));
	machineList.Add(new MColor(gameObject, colorStart, 500));
	machineList.Add (new MMEvent (this.gameObject, "RotateComplete"));
	machineQueue.AddMachine (machineList);
}

  public void  SetupMachine()
  {
	List <MachineState> machineList = new List<MachineState> ();  	
    machineList.Add(new MRotate(gameObject, 25.0f, 500));
    machineList.Add(new MColor(gameObject, attackColor, 500));
    machineList.Add(new MFire(gameObject));
	machineList.Add(new MSleep(200));
    machineList.Add(new MColor(gameObject, colorStart, 500));
	machineList.Add (new MMEvent (this.gameObject, "RotateComplete"));
	machineQueue.AddMachine (machineList);

	List <MachineState> machineList2 = new List<MachineState> ();  	
	machineList2.Add(new MMove(gameObject, new Vector3(0.0f, 0.0f, 0.0f), 500));
	machineList2.Add(new MMove(gameObject, new Vector3(0.0f, 3.0f, 0.0f), 500));
	machineList2.Add (new MMEvent (this.gameObject, "MoveComplete"));
	machineQueue.AddMachine (machineList2);
  }
*/
using System.Collections.Generic;

public class MachineScriptEnemy1 : MonoBehaviour {

	Vector3 worldMin = new Vector3(-10.0f, -10.0f, 0.0f);
	Vector3 worldMax = new Vector3(10.0f, 10.0f, 0.0f);
	
	public Color colorStart     = Color.red;
	public Color attackColor    = Color.red;
	public float duration       = 1.0F;
	void Test1()
	{
		Debug.Log ("Test 1 Called");
	}

	// Use this for initialization
	void Start () 
	{
	
	}

	void RotateComplete()
	{
		Debug.Log ("Rotation Finished!");
		List <MachineState> machineList = new List<MachineState> ();  	
		machineList.Add(new MRotate(gameObject, 25.0f, 500));
		machineList.Add(new MColor(gameObject, attackColor, 500));
		machineList.Add(new MFire(gameObject));
		machineList.Add(new MSleep(200));
		machineList.Add(new MColor(gameObject, colorStart, 500));
		machineList.Add (new MMEvent (this.gameObject, "RotateComplete"));

		Enemy enemyScript = gameObject.GetComponent<Enemy>();
		enemyScript.AddMachine (machineList);
	}

	public void SetGameObject(GameObject go)
	{
		List <MachineState> machineList = new List<MachineState> ();  	
		machineList.Add(new MRotate(go, 25.0f, 500));
		machineList.Add(new MColor(go, attackColor, 500));
		machineList.Add(new MFire(go));
		machineList.Add(new MSleep(200));
		machineList.Add(new MColor(go, colorStart, 500));
		machineList.Add (new MMEvent (go, "RotateComplete"));
		Enemy enemyScript = go.GetComponent<Enemy>();
		enemyScript.AddMachine (machineList);
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
