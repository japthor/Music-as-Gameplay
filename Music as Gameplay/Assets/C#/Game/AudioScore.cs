using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioScore : MonoBehaviour {

  public Text ScoreText;

  private TextMesh FeedBackPoints;
  private TextMesh FeedBackSpeed;
  private TextMesh FeedBackPowerUp;

  private enum FeedBack
  {
    kFeedBack_Points,
    kFeedBack_Speed,
    kFeedBack_PowerUp
  }

  private bool IsFading;

  // Use this for initialization
  void Start ()
  {
    FeedBackPoints = GameObject.Find("FeedBackPointsText").GetComponent<TextMesh>();
    FeedBackPoints.gameObject.SetActive(false);

    FeedBackSpeed = GameObject.Find("FeedBackSpeedText").GetComponent<TextMesh>();
    FeedBackSpeed.gameObject.SetActive(false);

    FeedBackPowerUp = GameObject.Find("FeedBackPowerUpText").GetComponent<TextMesh>();
    FeedBackPowerUp.gameObject.SetActive(false);

    IsFading = false;
}
	
	// Update is called once per frame
	void Update ()
  {
    UpdateScoreText();
    ScoreActivityRoad();
    Fading();
  }

  void UpdateScoreText()
  {
    ScoreText.text = AudioManager.GetInstance.GetScore().ToString();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Obstacle")
    {
      AudioManager.GetInstance.SetHasCollideWithObstacle(true);
      AudioManager.GetInstance.SubstractScore(300);
      ActiveFeedBackText(FeedBack.kFeedBack_Points, "-300");

      if (AudioManager.GetInstance.GetObjectsVelocity() > AudioManager.GetInstance.GetMinObjectsVelocity())
        ActiveFeedBackText(FeedBack.kFeedBack_Speed, "-Speed");

      IsFading = true;
    }
    else if (other.gameObject.tag == "Points")
    {
      AudioManager.GetInstance.AddScore(500);
      ActiveFeedBackText(FeedBack.kFeedBack_Points, "+500");

      if (AudioManager.GetInstance.GetObjectsVelocity() < AudioManager.GetInstance.GetMaxObjectsVelocity())
        ActiveFeedBackText(FeedBack.kFeedBack_Speed, "+Speed");

      IsFading = true;
    }
    else if (other.gameObject.tag == "Power Up")
    {
      AudioManager.GetInstance.AddScore(150);
      ActiveFeedBackText(FeedBack.kFeedBack_Points, "+150");

      if (!AudioManager.GetInstance.GetGotPowerUp())
      {
        ActiveFeedBackText(FeedBack.kFeedBack_PowerUp, "+PowerUp");
        AudioManager.GetInstance.SetGotPowerUp(true);
      }

      IsFading = true;
    }
  }

  void ActiveFeedBackText(FeedBack fb, string text)
  {
    switch (fb)
    {
      case FeedBack.kFeedBack_Points:
        FeedBackPoints.text = text;
        FeedBackPoints.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        FeedBackPoints.gameObject.SetActive(true);
        break;

      case FeedBack.kFeedBack_Speed:
        FeedBackSpeed.text = text;
        FeedBackSpeed.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        FeedBackSpeed.gameObject.SetActive(true);
        break;

      case FeedBack.kFeedBack_PowerUp:
        FeedBackPowerUp.text = text;
        FeedBackPowerUp.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        FeedBackPowerUp.gameObject.SetActive(true);
        break;

      default:
        break;
    }
  }

  void ScoreActivityRoad()
  {
    if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) >= 1 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) < 5)
      AudioManager.GetInstance.AddScore(1);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) >= 5 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) < 10)
      AudioManager.GetInstance.AddScore(2);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) >= 10 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) < 15)
      AudioManager.GetInstance.AddScore(3);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) >= 15 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) < 20)
      AudioManager.GetInstance.AddScore(4);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) >= 20 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition()) < 25)
      AudioManager.GetInstance.AddScore(5);
  }

  void Fading()
  {
    if (IsFading)
    {
      if (FeedBackPoints.color.a <= 0.0f && FeedBackSpeed.color.a <= 0)
      {
        FeedBackPoints.gameObject.SetActive(false);
        FeedBackSpeed.gameObject.SetActive(false);
        FeedBackPowerUp.gameObject.SetActive(false);
        IsFading = true;
      }
      else
      {
        float alpha = FeedBackPoints.color.a;
        alpha -= 0.01f;
        FeedBackPoints.color = new Vector4(1.0f, 1.0f, 1.0f, alpha);
        FeedBackSpeed.color = new Vector4(1.0f, 1.0f, 1.0f, alpha);
        FeedBackPowerUp.color = new Vector4(1.0f, 1.0f, 1.0f, alpha);
      }
    }
  }
}
