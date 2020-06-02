using UnityEngine;
using Singleton;

public class GameManager : Singleton<GameManager>
{
  public int bestScore;
  public int score = 0;
  public float camSpeed = 0.024f;
  public float spawnRate = 4.5f;
  public bool isPlaying = false;
  public bool hideMainMenuUI = false;
  public bool canSpawn = false;

  private void Awake()
  {
    bestScore = PlayerPrefs.GetInt("bestScore");
  }
}
