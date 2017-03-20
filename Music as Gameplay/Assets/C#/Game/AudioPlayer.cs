using UnityEngine;
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
          Position--;
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
          Position++;
          ChangeMaterial();
          IsMoving = false;
        }
        else
          transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(ActualPosition.x + 2.01f, ActualPosition.y, ActualPosition.z), 0.45f);
      }
    }
  }

  void ChangeMaterial()
  {
    Renderer.material = Materials[Position];

    Color newColor = new Color((Renderer.material.color.r * 0.2f) / 1, (Renderer.material.color.g * 0.2f) / 1, (Renderer.material.color.b * 0.2f) / 1);
    Renderer.material.SetColor("_EmissionColor", newColor * 2.0f);
  }
}
