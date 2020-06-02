using UnityEngine;

public class Mover : MonoBehaviour
{
  [SerializeField] private float _distancePerCall, _distance;
  private Vector2 _startPos;
  private bool _canMoveLeft;

  private void Start()
  {
      _startPos = transform.position;
  }

  private void FixedUpdate()
  {
    Move();
  }

  private void Move()
  {
    if(transform.position.x <= _startPos.x - _distance)
      _canMoveLeft = false;
    else if(transform.position.x >= _startPos.x)
      _canMoveLeft = true;

    if(_canMoveLeft)
      transform.position -= new Vector3(_distancePerCall, 0, 0);
    else if (!_canMoveLeft)
      transform.position += new Vector3(_distancePerCall, 0, 0);
  }

}
