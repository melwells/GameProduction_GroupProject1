using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public Transform[] waypoints;
  int current = 0;

  public float speed = 8f;
  float wayRadius = 1;

  void FixedUpdate()
  {
    if (Vector2.Distance(waypoints[current].transform.position, transform.position) < wayRadius)
    {
      current ++;
      if (current >= waypoints.Length)
      {
        current = 0;
      }
    }
  }
}
