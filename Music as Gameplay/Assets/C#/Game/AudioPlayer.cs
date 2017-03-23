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

  private TextMesh FeedBackPoints;
  private bool IsFading;

  void Start ()
  {
    Position = 7;
    IsMoving = false;
    IsMovingLeft = false;

    Renderer = GetComponent<Renderer>();
    ChangeMaterial();

    FeedBackPoints = GameObject.Find("FeedbackPointsText").GetComponent<TextMesh>();
    FeedBackPoints.gameObject.SetActive(false);
    IsFading = false;
  }

	void Update ()
  {
    Movement();
    Move();
    ScoreActivityRoad();
    Fading();
  }

  void Movement()
  {
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      if(Position > 0 && !IsMoving)
      {
        IsMoving = true;
        IsMovingLeft = true;
        Position--;
        ActualPosition = transform.localPosition;
      }
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      if(Position < 15 && !IsMoving)
      {
        IsMoving = true;
        IsMovingLeft = false;
        Position++;
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

  void ChangeMaterial()
  {
    Renderer.material = Materials[Position];

    Color newColor = new Color((Renderer.material.color.r * 0.5f) / 1, (Renderer.material.color.g * 0.5f) / 1, (Renderer.material.color.b * 0.5f) / 1);
    Renderer.material.SetColor("_EmissionColor", newColor * 2.0f);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Obstacle")
    {
      AudioManager.GetInstance().SetHasCollideWithObstacle(true);
      AudioManager.GetInstance().SetScore(-300);

      FeedBackPoints.text = "-300";
      FeedBackPoints.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
      FeedBackPoints.gameObject.SetActive(true);
      IsFading = true;

      Destroy(other.gameObject);
    }

    if (other.gameObject.tag == "Points")
    {
      AudioManager.GetInstance().SetScore(500);

      FeedBackPoints.text = "+500";
      FeedBackPoints.color = new Vector4(1.0f,1.0f,1.0f,1.0f);
      FeedBackPoints.gameObject.SetActive(true);
      IsFading = true;

      Destroy(other.gameObject);
    }
  }

  void ScoreActivityRoad()
  {
    if (AudioManager.GetInstance().GetActivity(Position) >= 1 && AudioManager.GetInstance().GetActivity(Position) < 5)
      AudioManager.GetInstance().SetScore(1);

    else if (AudioManager.GetInstance().GetActivity(Position) >= 5 && AudioManager.GetInstance().GetActivity(Position) < 10)
      AudioManager.GetInstance().SetScore(2);

    else if (AudioManager.GetInstance().GetActivity(Position) >= 10 && AudioManager.GetInstance().GetActivity(Position) < 15)
      AudioManager.GetInstance().SetScore(3);

    else if (AudioManager.GetInstance().GetActivity(Position) >= 15 && AudioManager.GetInstance().GetActivity(Position) < 20)
      AudioManager.GetInstance().SetScore(4);

    else if (AudioManager.GetInstance().GetActivity(Position) >= 20 && AudioManager.GetInstance().GetActivity(Position) < 25)
      AudioManager.GetInstance().SetScore(5);
  }

  void Fading()
  {
    if (IsFading)
    {
      if(FeedBackPoints.color.a <= 0.0f)
      {
        FeedBackPoints.gameObject.SetActive(false);
        IsFading = true;
      }
      else
      {
        float alpha = FeedBackPoints.color.a;
        alpha -= 0.01f;
        FeedBackPoints.color = new Vector4(1.0f, 1.0f, 1.0f, alpha);
      }
    }
  }
}
