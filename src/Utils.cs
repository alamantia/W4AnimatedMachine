// Some simple utility functions, mostly for quick animation related things
using UnityEngine;
using System.Collections;

public class Utils {
  // amount of milliseconds we should save for a move animation/card activation delay
  public static int TurnTime = 500;
  // Compute the index of a tiled encoded sprite
  public static Vector2 SpriteIndex(int index, int units_wide)
  {        
    if (index < units_wide)
      {
	return new Vector2(index, 0);
      }
    int y = index / units_wide;
    return new Vector2(index - (units_wide * y), y);
  }

  // compute the time we would like a tweening effect to take place
  // we don't want very slow tweens taking place
  public static int TimeForTween(Vector3 start, Vector3 finish, float speed)
  {
    speed = 0.1f;  
    Vector3 delta = finish - start;
    float dist = delta.magnitude;
    return (int) (dist / speed);
  }

  public static double  MapValue (float value, float toMin, float toMax, float fromMin, float fromMax)
  {
    return toMin + (toMax - toMin) *  ((value - fromMin) / (fromMax - fromMin));
  }
  

  public static Vector3 Lerp(Vector3 start, Vector3 end, float t)
  {
    Vector3 result = new Vector3(0.0f, 0.0f, 0.0f);
    result.x = start.x + (end.x - start.x) * t;
    result.y = start.y + (end.y - start.y) * t;
    result.z = start.z + (end.z - start.z) * t;
    return result;
  }

  public static Vector3 Curve(Vector3 P1, Vector3 P2, Vector3 CP1, Vector3 CP2, float t)
  {
    Vector3 result = new Vector3();
		
    Vector3 ab = Lerp (P1, CP1, t);
    Vector3 bc = Lerp (CP1, CP2, t);
    Vector3 cd = Lerp (CP2, P2, t);
		
    Vector3 abbc = Lerp (ab, bc, t);
    Vector3 bccd = Lerp(bc, cd, t);
    Vector3 dest = Lerp (abbc, bccd, t);
    return dest;
  }
}
