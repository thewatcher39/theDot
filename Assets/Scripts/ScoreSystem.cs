using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
  [SerializeField] private Text _bestScore, _scoreTxt;
  private bool _startLoopTime = true;

  private void Awake()
  {
    _bestScore.text = "Best: " + GameManager.Instance.bestScore.ToString();
  }

  private void FixedUpdate()
  {
    if(GameManager.Instance.isPlaying && _startLoopTime)
    {
      InvokeRepeating("scorePointUp", 1, 1);
      _startLoopTime = false;
    }
  }

  private void scorePointUp()
  {
    GameManager.Instance.score++;
    _scoreTxt.text = GameManager.Instance.score.ToString();

    if(GameManager.Instance.score % 10 == 0)
    {
      GameManager.Instance.camSpeed += 0.002f;
      GameManager.Instance.spawnRate -= 0.5f;
    }

    if(GameManager.Instance.score > GameManager.Instance.bestScore)
      GameManager.Instance.bestScore = GameManager.Instance.score;
  }

}
