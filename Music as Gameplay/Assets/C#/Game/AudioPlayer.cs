using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

  private int Position;
  private bool IsMoving;
  private bool IsMovingLeft;
  private Vector3 ActualPosition;
	void Start ()
  {
    Position = 7;
    IsMoving = false;
    IsMovingLeft = false;
  }

	void Update ()
  {
    Movement();
    Move();
  }

  void Movement()
  {
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      if(Position > 0 && !IsMoving)
      {
        IsMoving = true;
        IsMovingLeft = true;
        ActualPosition = transform.localPosition;
      }
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      if(Position < 15 && !IsMoving)
      {
        IsMoving = true;
        IsMovingLeft = false;
        ActualPosition = transform.localPosition;
      }
    }
  }

  void Move()
  {
    if (IsMoving)
    {
      if (IsMovingLeft)
      {

        if(transform.localPosition.x <= ActualPosition.x - 2.0f)
        {
          IsMoving = false;
        }
        else
        {
          transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(ActualPosition.x - 2.0f, ActualPosition.y, ActualPosition.z), 0.25f);
        }
          
      }
      else
      {
        if (transform.position.x <= ActualPosition.x + 2.0f)
          transform.position = Vector3.Lerp(transform.position, new Vector3(ActualPosition.x + 2.0f, ActualPosition.y, ActualPosition.z), 0.25f);
        else
          IsMoving = false;
      }
    }
  }
}
