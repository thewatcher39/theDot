using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField] private Rigidbody2D _ball;
	[SerializeField] private GameObject _arrowPrefab;
	private Vector2 _pos1, _pos2, _power, _rawPos;
	private GameObject _arrow;

	private const int MAX_FORCE_MULTIPLIER = 30;
	private const float FORCE_MULTIPLIER = 0.0003f;
	private const float MAGNITUDE_MULTIPLIER = 0.005f;

	public void OnDrag(PointerEventData eventData)
	{
    if(GameManager.Instance.isPlaying)
    {
  		Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
  		Vector2 lookDir = _mousePos - _ball.position;
  		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
  		_arrow.transform.rotation = Quaternion.Euler(0, 0, angle - 180);
			if(Vector3.Magnitude(_pos1  - eventData.position) * MAGNITUDE_MULTIPLIER <= 2)
  			_arrow.transform.localScale = new Vector3(0.5f, Vector3.Magnitude(_pos1  - eventData.position) * MAGNITUDE_MULTIPLIER, 0);
    }
  }

	public void OnPointerDown(PointerEventData eventData)
	{
    if(GameManager.Instance.isPlaying)
    {
  		_pos1 = eventData.position;
  		Vector2 touchposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
  		_arrow = Instantiate(_arrowPrefab, _ball.position, Quaternion.identity);
			_arrow.transform.localScale = new Vector3(0,0,0);
  		_rawPos = Camera.main.ScreenToWorldPoint(_pos1);
			Time.timeScale = 0.5f;
    }
	}

	public void OnPointerUp(PointerEventData eventData)
	{
    if(GameManager.Instance.isPlaying)
    {
  		_pos2 = eventData.position;
  		_power = _pos1 - _pos2;

			if(Vector3.Magnitude(_power) * MAGNITUDE_MULTIPLIER <= 1.9f)
				_power = _power * Vector3.Magnitude(_power) * FORCE_MULTIPLIER;
			else
				_power = _power.normalized *  MAX_FORCE_MULTIPLIER;

			_ball.AddForce(_power, ForceMode2D.Impulse);
			Time.timeScale = 1;
  		Destroy(_arrow);
	  }
    else
		{
			GameManager.Instance.isPlaying = true;
			GameManager.Instance.hideMainMenuUI = true;
			GameManager.Instance.canSpawn = true;
		}
  }
}
