using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour{

  private static AudioManager Instance;
  private float[] MuteFrequencyBand = new float[16];
  private float[] MuteMaximumValue = new float[16];
  private float[] MuteResult = new float[16];

  private float[] NoMuteFrequencyBand = new float[16];
  private float[] NoMuteMaximumValue = new float[16];
  private float[] NoMuteResult = new float[16];

  private float[] FrequencyBandBackGround = new float[16];
  private float[] MaximumValueBackGround = new float[16];
  private float[] ResultBackGround = new float[16];

  private bool HasCollideWithObstacle;

  public Text ScoreText;
  private int Score;
  private int[] Activity = new int[16];
  private int[] Multiplier = new int[16];
  private bool[] ActivateParticles = new bool[16];

  public static AudioManager GetInstance()
  {
    if (Instance == null)
    {
      Instance = GameObject.FindObjectOfType<AudioManager>();
    }
    return Instance;
  }

  void Start()
  {
    for(int i = 0; i < 16; i++)
    {
      MuteFrequencyBand[i] = 0.0f;
      MuteMaximumValue[i] = 1.0f;
      MuteResult[i] = 0.0f;

      NoMuteFrequencyBand[i] = 0.0f;
      NoMuteMaximumValue[i] = 1.0f;
      NoMuteResult[i] = 0.0f;

      FrequencyBandBackGround[i] = 0.0f;
      MaximumValueBackGround[i] = 1.0f;
      ResultBackGround[i] = 0.0f;

      Activity[i] = 0;
      Multiplier[i] = 0;

      ActivateParticles[i] = false;
    }

    HasCollideWithObstacle = false;
    Score = 0;
  }

  void Update()
  {
    SetScoreText();
  }

  public void SetMuteFrequencyBand(int band, float frequency)
  {
    MuteFrequencyBand[band] = frequency;
  }

  public float GetMuteFrequencyBand(int band)
  {
    return MuteFrequencyBand[band];
  }

  public void SetMuteMaximumValue(int band, float value)
  {
    MuteMaximumValue[band] = value;
  }

  public float GetMuteMaximumValue(int band)
  {
    return MuteMaximumValue[band];
  }

  public void SetMuteResult(int band, float result)
  {
    MuteResult[band] = result;
  }

  public float GetMuteResult(int band)
  {
    return MuteResult[band];
  }

  public void MuteLinearMapping(int band)
  {
    float value = MuteFrequencyBand[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > MuteMaximumValue[band])
    {
      MuteMaximumValue[band] = MuteFrequencyBand[band];
    }

    MuteResult[band] = (value - 0) / (MuteMaximumValue[band] - 0);

    if (float.IsNaN(MuteResult[band]))
    {
      MuteResult[band] = 0;
    }
  }

  public void SetNoMuteFrequencyBand(int band, float frequency)
  {
    NoMuteFrequencyBand[band] = frequency;
  }

  public float GetNoMuteFrequencyBand(int band)
  {
    return NoMuteFrequencyBand[band];
  }

  public void SetNoMuteMaximumValue(int band, float value)
  {
    NoMuteMaximumValue[band] = value;
  }

  public float GetNoMuteMaximumValue(int band)
  {
    return NoMuteMaximumValue[band];
  }

  public void SetNoMuteResult(int band, float result)
  {
    NoMuteResult[band] = result;
  }

  public float GetNoMuteResult(int band)
  {
    return NoMuteResult[band];
  }

  public void NoMuteLinearMapping(int band)
  {
    float value = NoMuteFrequencyBand[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > NoMuteMaximumValue[band])
    {
      NoMuteMaximumValue[band] = NoMuteFrequencyBand[band];
    }

    NoMuteResult[band] = (value - 0) / (NoMuteMaximumValue[band] - 0);

    if (float.IsNaN(NoMuteResult[band]))
    {
      NoMuteResult[band] = 0;
    }
  }

  public void SetFrequencyBandBackGround(int band, float frequency)
  {
    FrequencyBandBackGround[band] = frequency;
  }

  public float GetFrequencyBandBackGround(int band)
  {
    return FrequencyBandBackGround[band];
  }

  public void SetMaximumValueBackGround(int band, float value)
  {
    MaximumValueBackGround[band] = value;
  }

  public float GetMaximumValueBackGround(int band)
  {
    return MaximumValueBackGround[band];
  }

  public void SetResultBackGround(int band, float result)
  {
    ResultBackGround[band] = result;
  }

  public float GetResultBackGround(int band)
  {
    return ResultBackGround[band];
  }

  public void LinearMappingBackGround(int band)
  {
    float value = FrequencyBandBackGround[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > MaximumValueBackGround[band])
    {
      MaximumValueBackGround[band] = FrequencyBandBackGround[band];
    }

    ResultBackGround[band] = (value - 0) / (MaximumValueBackGround[band] - 0);

    if (float.IsNaN(ResultBackGround[band]))
    {
      ResultBackGround[band] = 0;
    }
  }

  public void SetHasCollideWithObstacle(bool result)
  {
    HasCollideWithObstacle = result;
  }

  public bool GetHasCollideWithObstacle()
  {
    return HasCollideWithObstacle;
  }

  private void SetScoreText()
  {
    if(ScoreText != null)
      ScoreText.text = Score.ToString();
  }

  public void SetScore(int result)
  {
    if (Score < 0)
      Score = 0;
    else
      Score += result;
  }

  public int GetScore()
  {
    return Score;
  }

  public void SetActivity(int band, int result)
  {
    Activity[band] += result;
  }

  public int GetActivity(int band)
  {
    return Activity[band];
  }

  public void SetMultiplier(int band, int result)
  {
    Multiplier[band] = result;
  }

  public int GetMultiplier(int band)
  {
    return Multiplier[band];
  }

  public void SetActivateParticles(int band, bool result)
  {
    ActivateParticles[band] = result;
  }

  public bool GetActivateParticles(int band)
  {
    return ActivateParticles[band];
  }


}
