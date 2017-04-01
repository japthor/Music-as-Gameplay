using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioScore : MonoBehaviour {

  public Text ScoreText;

  public TextMesh[] FeedBack = new TextMesh[4];

  private bool IsFadingPoints;
  private bool IsFadingSpeed;
  private bool IsFadingPowerUp;

  // Use this for initialization
  void Start ()
  {
    for(int i = 0; i < FeedBack.Length; i++)
    {
      FeedBack[i].gameObject.SetActive(false);
    }

    IsFadingPoints = false;
    IsFadingSpeed = false;
    IsFadingPowerUp = false;
}
	
	// Update is called once per frame
	void Update ()
  {
    if (!AudioManager.GetInstance.GetIsPaused)
    {
      UpdateScoreText();
      ScoreActivityRoad();
      PowerUpTime();

      Fading(FeedBack[0], IsFadingPoints);
      Fading(FeedBack[2], IsFadingPowerUp);
      Fading(FeedBack[1], IsFadingSpeed);
    }
  }

  void UpdateScoreText()
  {
    ScoreText.text = AudioManager.GetInstance.GetScore.ToString();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Obstacle")
    {
      AudioManager.GetInstance.GetHasCollideWithObstacle = true;
      SubstracPoints(300);

      if (AudioManager.GetInstance.GetObjectsVelocity > AudioManager.GetInstance.GetMinObjectsVelocity)
      {
        ActiveFeedBackText(FeedBack[1], "-Speed");
        IsFadingSpeed = true;
      }

      IsFadingPoints = true;
    }
    else if (other.gameObject.tag == "Points")
    {
      AddPoints(500);

      if (AudioManager.GetInstance.GetObjectsVelocity < AudioManager.GetInstance.GetMaxObjectsVelocity)
      {
        ActiveFeedBackText(FeedBack[1], "+Speed");
        IsFadingSpeed = true;
      }

      IsFadingPoints = true;
    }
    else if (other.gameObject.tag == "Power Up")
    {
      AddPoints(150);

      if (!AudioManager.GetInstance.GetGotPowerUp)
      {
        ActiveFeedBackText(FeedBack[2], "+PowerUp");
        AudioManager.GetInstance.GetGotPowerUp = true;
        IsFadingPowerUp = true;
      }

      IsFadingPoints = true;
    }
  }

  void AddPoints(int score)
  {
    AudioManager.GetInstance.AddScore(score);
    ActiveFeedBackText(FeedBack[0], "+" + score.ToString());
  }

  void SubstracPoints(int score)
  {
    AudioManager.GetInstance.SubstractScore(300);
    ActiveFeedBackText(FeedBack[0], "-" + score.ToString());
  }

  void ActiveFeedBackText(TextMesh text, string name)
  {
    text.text = name;
    text.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    text.gameObject.SetActive(true);
  }

  void ScoreActivityRoad()
  {
    if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) >= 1 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) < 5)
      AudioManager.GetInstance.AddScore(1);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) >= 5 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) < 10)
      AudioManager.GetInstance.AddScore(2);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) >= 10 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) < 15)
      AudioManager.GetInstance.AddScore(3);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) >= 15 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) < 20)
      AudioManager.GetInstance.AddScore(4);

    else if (AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) >= 20 && AudioManager.GetInstance.GetActivity(AudioManager.GetInstance.GetPlayerPosition) < 25)
      AudioManager.GetInstance.AddScore(5);
  }

  void PowerUpTime()
  {
    if (AudioManager.GetInstance.GetIsActivePowerUp)
    {
      FeedBack[3].gameObject.SetActive(true);
      FeedBack[3].text = ((int)AudioManager.GetInstance.GetPowerUpTime).ToString();
    }
    else
    {
      if (FeedBack[3].gameObject.activeSelf)
        FeedBack[3].gameObject.SetActive(false);
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
