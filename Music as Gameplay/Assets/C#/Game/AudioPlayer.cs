using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

  private int Position;
  private bool IsMoving;
  private bool IsMovingLeft;
  private Vector3 ActualPosition;

  public Material[] Materials = new Material[16];
  private Renderer Renderer;

  void Start ()
  {
    Position = 7;
    IsMoving = false;
    IsMovingLeft = false;

    Renderer = GetComponent<Renderer>();
    ChangeMaterial();
  }

	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      Inputs();
      Move();
    }
  }

  void Inputs()
  {
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
      LeftMovement();

    else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
      RightMovement();

    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
      UsePowerUp();
  }

  void LeftMovement()
  {
    if(Position > 0 && !IsMoving)
    {
      IsMoving = true;
      IsMovingLeft = true;
      Position--;
      AudioManager.GetInstance.SetPlayerPosition(Position);
      ActualPosition = transform.localPosition;
    }
  }

  void RightMovement()
  {
    if (Position < 15 && !IsMoving)
    {
      IsMoving = true;
      IsMovingLeft = false;
      Position++;
      AudioManager.GetInstance.SetPlayerPosition(Position);
      ActualPosition = transform.localPosition;
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
          ChangeMaterial();
          IsMoving = false;
        }
        else
          transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(ActualPosition.x - 2.01f, ActualPosition.y, ActualPosition.z), 0.45f);
      }
      else
      {
        if (transform.localPosition.x >= ActualPosition.x + 2.0f)
        {
          ChangeMaterial();
          IsMoving = false;
        }
        else
          transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(ActualPosition.x + 2.01f, ActualPosition.y, ActualPosition.z), 0.45f);
      }
    }
  }

  void UsePowerUp()
  {
    if (AudioManager.GetInstance.GetGotPowerUp())
    {
      AudioManager.GetInstance.SetPowerUpTime(4.0f);
      AudioManager.GetInstance.SetIsActivePowerUp(true);
      AudioManager.GetInstance.SetGotPowerUp(false);
    }
  }

  void ChangeMaterial()
  {
    Renderer.material = Materials[Position];

    Color newColor = new Color((Renderer.material.color.r * 0.5f) / 1, (Renderer.material.color.g * 0.5f) / 1, (Renderer.material.color.b * 0.5f) / 1);
    Renderer.material.SetColor("_EmissionColor", newColor * 2.0f);
  }
}
