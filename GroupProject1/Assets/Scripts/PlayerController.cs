using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public float speed = 5.0f;

  private Vector2 direction = Vector2.zero;
  private int acornCount;
  private Rigidbody2D rb2d;
  private int score;
  private int lives;
  private bool pizzaBool;

    // Start is called before the first frame update
    void Start()
    {
      //rb2d = GetComponent<Rigidbody2D>();
       acornCount = 0;
       score = 0;
       lives = 3;
       pizzaBool = false;
    }

    void Update()
    {
      PlayerInput();
      Move (direction);
      RotateSquirrel();
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

    void RotateSquirrel()
    {
      if (direction == Vector2.left)
      {
        transform.localScale = new Vector3 ((float)1.5, (float)1.5, 1);
        transform.localRotation =  Quaternion.Euler (0, 0, 0);
      }

      else if (direction == Vector2.right)
      {
        transform.localScale = new Vector3 ((float)-1.5, (float)1.5, 1);
        transform.localRotation =  Quaternion.Euler (0, 0, 0);
      }

      else if (direction == Vector2.up)
      {
        transform.localScale = new Vector3 ((float)1.5, (float)-1.5, 1);
        transform.localRotation =  Quaternion.Euler (0, 0, -90);
      }

      else if (direction == Vector2.down)
      {
        transform.localScale = new Vector3 ((float)1.5, (float)1.5, 1);
        transform.localRotation =  Quaternion.Euler (0, 0, 90);
      }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("AcornPickup"))
        {
          other.gameObject.SetActive(false);
          acornCount += 1;
          score += 1;
          Debug.Log ("Acorns picked up " + acornCount);
        }

        else if (other.gameObject.CompareTag("PizzaPickUp"))
        {
          other.gameObject.SetActive(false);
          score += 500;
          Debug.Log("Pizza Crust aquired");

          pizzaBool = true;
        }

        else if (other.gameObject.CompareTag("Enemy") && pizzaBool != true)
        {
          Respawn();
        }

        else if (other.gameObject.CompareTag("Enemy") && pizzaBool == true)
        {
          EnemyRun();
        }
      }


      void NextLevel()
      {
        if ( acornCount == 220)
        Debug.Log ("All pickups collected");
      }

      void Respawn()
      {
        direction = Vector2.zero;
        transform.localPosition = new Vector3 ((float)14.3, (float)-7, 0);
        lives = lives - 1;

        if (lives <= 0)
        {
          Destroy (this);
        }
      }

      void EnemyRun()
      {


      }

}
