using UnityEngine;

public class AnimationController : MonoBehaviour
{
  [SerializeField] private Animation _gameNameOff,  _tapHereOff, _bestScore, _scoreTxt;

  private void FixedUpdate()
  {
    if(GameManager.Instance.isPlaying)
    {
      if(GameManager.Instance.hideMainMenuUI)
      {
        _gameNameOff.Play("GameNameFadeOff");
        _tapHereOff.Play("tapHereTextFadeOff");
        _bestScore.Play("bestTextFadeOff");
        _scoreTxt.Play("scoreTxtOn");
        GameManager.Instance.hideMainMenuUI = false;
      }
    }
  }
}
