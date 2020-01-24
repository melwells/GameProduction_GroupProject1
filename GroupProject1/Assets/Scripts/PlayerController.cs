using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  private Rigidbody2D rb2d;

  public float speed = 5.0f;

  private Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
      //rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
      PlayerInput();

      Move (direction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

//find Input
    void PlayerInput()
    {
      if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
      {
        direction = Vector2.left;
      }

      else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
      {
        direction =  Vector2.right;
      }

      else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
      {
        direction = Vector2.up;
      }

      else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
      {
        direction = Vector2.down;
      }
    }

//determining movement direction
    void Move(Vector2 d)
    {
      transform.localPosition += (Vector3)d * speed * Time.deltaTime;

    }
}
