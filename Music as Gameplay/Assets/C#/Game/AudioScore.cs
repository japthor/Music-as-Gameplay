using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioScore : MonoBehaviour {

  public Text ScoreText;

  private TextMesh FeedBackPoints;
  private TextMesh FeedBackSpeed;
  private TextMesh FeedBackPowerUp;
  private TextMesh FeedBackPowerUpTime;

  private bool IsFadingPoints;
  private bool IsFadingSpeed;
  private bool IsFadingPowerUp;

  // Use this for initialization
  void Start ()
  {
    FeedBackPoints = GameObject.Find("FeedBackPointsText").GetComponent<TextMesh>();
    FeedBackPoints.gameObject.SetActive(false);

    FeedBackSpeed = GameObject.Find("FeedBackSpeedText").GetComponent<TextMesh>();
    FeedBackSpeed.gameObject.SetActive(false);

    FeedBackPowerUp = GameObject.Find("FeedBackPowerUpText").GetComponent<TextMesh>();
    FeedBackPowerUp.gameObject.SetActive(false);

    FeedBackPowerUpTime = GameObject.Find("FeedBackPowerUpTimeText").GetComponent<TextMesh>();
    FeedBackPowerUpTime.gameObject.SetActive(false);

    IsFadingPoints = false;
    IsFadingSpeed = false;
    IsFadingPowerUp = false;
}
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused())
    {
      UpdateScoreText();
      ScoreActivityRoad();
      PowerUpTime();

      Fading(FeedBackPoints, IsFadingPoints);
      Fading(FeedBackPowerUp, IsFadingPowerUp);
      Fading(FeedBackSpeed, IsFadingSpeed);
    }
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
      ActiveFeedBackText(FeedBackPoints, "-300");

      if (AudioManager.GetInstance.GetObjectsVelocity() > AudioManager.GetInstance.GetMinObjectsVelocity() )
      {
        ActiveFeedBackText(FeedBackSpeed, "-Speed");
        IsFadingSpeed = true;
      }

      IsFadingPoints = true;
    }
    else if (other.gameObject.tag == "Points")
    {
      AudioManager.GetInstance.AddScore(500);
      ActiveFeedBackText(FeedBackPoints, "+500");

      if (AudioManager.GetInstance.GetObjectsVelocity() < AudioManager.GetInstance.GetMaxObjectsVelocity())
      {
        ActiveFeedBackText(FeedBackSpeed, "+Speed");
        IsFadingSpeed = true;
      }

      IsFadingPoints = true;
    }
    else if (other.gameObject.tag == "Power Up")
    {
      AudioManager.GetInstance.AddScore(150);
      ActiveFeedBackText(FeedBackPoints, "+150");

      if (!AudioManager.GetInstance.GetGotPowerUp())
      {
        ActiveFeedBackText(FeedBackPowerUp, "+PowerUp");
        AudioManager.GetInstance.SetGotPowerUp(true);
        IsFadingPowerUp = true;
      }

      IsFadingPoints = true;
    }
  }

  void ActiveFeedBackText(TextMesh text, string name)
  {
    text.text = name;
    text.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    text.gameObject.SetActive(true);
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

  void PowerUpTime()
  {
    if (AudioManager.GetInstance.GetIsActivePowerUp())
    {
      FeedBackPowerUpTime.gameObject.SetActive(true);
      FeedBackPowerUpTime.text = ((int)AudioManager.GetInstance.GetPowerUpTime()).ToString();
    }
    else
    {
      if (FeedBackPowerUpTime.gameObject.activeSelf)
        FeedBackPowerUpTime.gameObject.SetActive(false);
    }
  }

  void Fading(TextMesh text, bool fade)
  {
    if (fade)
    {
      if (text.color.a <= 0.0f)
      {
        text.gameObject.SetActive(false);
        fade = true;
      }
      else
      {
        float alpha = text.color.a;
        alpha -= 0.01f;
        text.color = new Vector4(1.0f, 1.0f, 1.0f, alpha);
      }
    }
  }
}
