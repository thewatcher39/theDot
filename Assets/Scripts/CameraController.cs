using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform _cameraTransform;

  private void FixedUpdate()
  {
    if(GameManager.Instance.isPlaying)
      _cameraTransform.position += new Vector3(0, GameManager.Instance.camSpeed, 0);
  }
}
