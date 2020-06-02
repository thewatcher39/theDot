using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

  private void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.tag == "Player")
      Die();
    else if(other.gameObject.tag != "outOfCam")
      Destroy(other.gameObject);
  }

  private void Die()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    PlayerPrefs.SetInt("bestScore", GameManager.Instance.bestScore);
  }

}
