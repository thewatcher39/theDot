using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	public Rigidbody2D ball;
	public GameObject arrowPrefab;
	private Vector2 pos1, pos2, power, rawPos;
	private GameObject arrow;

	private void FixedUpdate()
	{
		if(power != Vector2.zero)
		{
			ball.velocity = power;
			power = Vector2.Lerp(power, Vector2.zero, 0.5f);
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 lookDir = _mousePos - ball.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
		arrow.transform.rotation = Quaternion.Euler(0, 0, angle - 180);
		arrow.transform.localScale = new Vector3(0.1f, Vector3.Magnitude(pos1  - eventData.position) * 0.001f, 0);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		pos1 = eventData.position;
		Vector2 touchposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 b = Camera.main.ScreenToWorldPoint(touchposition);
		arrow = Instantiate(arrowPrefab, b, Quaternion.identity);
		rawPos = Camera.main.ScreenToWorldPoint(pos1);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pos2 = eventData.position;
		power = pos1 - pos2;
		power = power * 0.05f;
		Destroy(arrow);
	}
}
