using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimatedObject : MonoBehaviour {
  public Material spriteSheet;
  public int animationSpeed = 20;

  public Vector2 spriteSize = new Vector2(24.0f, 24.0f);
  public int spriteIndex    = 0;

  public bool animationRunning = true;
  public int  animationFrame;
  public int  animationLastTick = -1;

  public Vector2[] currentAnimation;

  public Mesh mesh;
  public MeshFilter meshFilter;

  // Adjust the UVs to match a specific frame
  // Ok the base didn't work for horizontal space durr!


  // Trying to abstract these out a little
  List <MachineState> machineList = new List<MachineState> ();  

  protected MachineQueue machineQueue;
  
  public void SetAnimation (Vector2[] animation) 
  {
    currentAnimation = animation;
    animationFrame = 0;
  }

  public void SetFrame(int x, int y)
  {
    float unitsX    = spriteSheet.mainTexture.width / spriteSize.x;
    float unitsY    = spriteSheet.mainTexture.height / spriteSize.y;
    float unitsWide = 1.0f / unitsX;
    float unitsTall = 1.0f / unitsY;

    float xCurrent = (unitsWide * x);
    float yCurrent = (unitsTall * unitsY) - (unitsTall * y);

    float x1 = xCurrent;
    float y1 = yCurrent;

    float x2 = x1 + unitsWide;
    float y2 = y1;

    float x3 = x1;
    float y3 = y1 - unitsTall;

    float x4 = x1 + unitsWide;
    float y4 = y1 - unitsTall;

    Vector2 a = new Vector2(x3, y3);
    Vector2 b = new Vector2(x1, y1);
    Vector2 c = new Vector2(x2, y2);

    Vector2 d = new Vector2(x4, y4);

    mesh.uv = new Vector2[] {
      a, b, c, d
    };
  }

  public void GenerateQuad()
  {
    float min = -0.5f;
    float max = 0.5f;

    meshFilter = gameObject.AddComponent<MeshFilter>();
    MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
    mesh = GetComponent<MeshFilter>().mesh;
    mesh.Clear();

    mesh.vertices = new Vector3[] {
      new Vector3(min, min, 0),
      new Vector3(min, max, 0),
      new Vector3(max, max, 0),
      new Vector3(max, min, 0),
    };

    mesh.uv = new Vector2[] 
      {
	new Vector2 (0, 0), new Vector2 (0, 1), new Vector2 (1, 1),  new Vector2 (1, 0)
      };

    mesh.normals = new Vector3[] 
      {
	new Vector3 (0, 1, 0), new Vector3 (0, 1,0), new Vector3 (0,1, 0),  new Vector3 (0,1, 0)
      };

    mesh.triangles = new int[] { 
      0, 1, 2, 3, 0, 2 
    };

    MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
    meshCollider.isTrigger = true;

    Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
    rigidBody.mass = 5;
    rigidBody.useGravity = false;
    GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    renderer.material = spriteSheet;
  }

  public void UpdateAnimation()
  {
    if (currentAnimation.Length == 0)
      {
	return;
      }

    int currentTick = Environment.TickCount & Int32.MaxValue;
    
    if ((currentTick - animationLastTick) <= animationSpeed)
      {
	return;
      }

    animationFrame = animationFrame + 1;

    if (animationFrame >= currentAnimation.Length)
      {
	animationFrame = 0;
      }

    Vector2 animation = currentAnimation[animationFrame];
   
    SetFrame((int)animation.x, (int)animation.y);
    animationLastTick = Environment.TickCount & Int32.MaxValue;
 
  }

  // Use this for initialization
  public virtual void Start () {
    animationLastTick = 0;
    machineQueue = new MachineQueue(this.gameObject);
  }
  
  // Update is called once per frame
  public virtual  void Update () {
    machineQueue.Update();
    UpdateAnimation();
  }
  
}
