using UnityEngine;
using System.Collections;

public class AudioManager {

  private static AudioManager Instance = null;
  float[] FrequencyBand = new float[8];
  float[] FrequencyBandBackGround = new float[8];

  float[] MaximumValue = new float[8];
  float[] Result = new float[8];

  float[] MaximumValueBackGround = new float[8];
  float[] ResultBackGround = new float[8];

  public static AudioManager GetInstance()
  {
    if (Instance == null)
    {
      Instance = new AudioManager();
    }

    return Instance;
  }

  void Start()
  {
    for(int i = 0; i < 8; i++)
    {
      FrequencyBandBackGround[i] = 0;
      MaximumValue[i] = 1;
      Result[i] = 0;
    }
  }

  public void SetFrequencyBand(int band, float frequency)
  {
    FrequencyBand[band] = frequency;
  }

  public float GetFrequencyBand(int band)
  {
    return FrequencyBand[band];
  }

  public void SetMaximumValue(int band, float value)
  {
    MaximumValue[band] = value;
  }

  public float GetMaximumValue(int band)
  {
    return MaximumValue[band];
  }

  public void SetResult(int band, float result)
  {
    Result[band] = result;
  }

  public float GetResult(int band)
  {
    return Result[band];
  }

  public void LinearMapping(int band)
  {
    float value = FrequencyBand[band];

    if (value < 0)
    {
      value = 0;
    }

    if (value > MaximumValue[band])
    {
      MaximumValue[band] = FrequencyBand[band];
    }

    Result[band] = (value - 0) / (MaximumValue[band] - 0);

    if (float.IsNaN(Result[band]))
    {
      Result[band] = 0;
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
