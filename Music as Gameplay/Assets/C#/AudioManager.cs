using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour{

  private static AudioManager Instance;
  float[] MuteFrequencyBand = new float[8];
  float[] MuteMaximumValue = new float[8];
  float[] MuteResult = new float[8];

  float[] NoMuteFrequencyBand = new float[8];
  float[] NoMuteMaximumValue = new float[8];
  float[] NoMuteResult = new float[8];

  float[] FrequencyBandBackGround = new float[8];
  float[] MaximumValueBackGround = new float[8];
  float[] ResultBackGround = new float[8];


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
    for(int i = 0; i < 8; i++)
    {
      MuteFrequencyBand[i] = 0;
      MuteMaximumValue[i] = 1;
      MuteResult[i] = 0;

      NoMuteFrequencyBand[i] = 0;
      NoMuteMaximumValue[i] = 1;
      NoMuteResult[i] = 0;

      FrequencyBandBackGround[i] = 0;
      MaximumValueBackGround[i] = 1;
      ResultBackGround[i] = 0;
    }
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

}
