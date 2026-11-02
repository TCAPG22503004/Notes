using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rb;
	[SerializeField] SpriteRenderer sr;
	[SerializeField] Parameter playerParameter;
	[SerializeField] laneEffect effect;

	Vector2 pos = new Vector2(0, 0);

	void Start()
	{
		
	}
	
	void FixedUpdate() 
	{
		sr.sortingOrder = (int)(-10 * rb.position.y);

		Movement();
	}

	void Movement() {

		// values
		float x = rb.position.x;
		float y = rb.position.y;
		float dx = 0;
		float dy = 0;
		float delta = playerParameter.speed * Time.fixedDeltaTime;
		int oldLane = playerParameter.lane;

		// input
		if (
			Input.GetKey(KeyCode.W) ||
			Input.GetKey(KeyCode.UpArrow)
		) {
			dy += delta;
		}

		if (
			Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.LeftArrow)
		) {
			dx -= delta;
		}

		if (
			Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.DownArrow)
		) {
			dy -= delta;
		}

		if (
			Input.GetKey(KeyCode.D) ||
			Input.GetKey(KeyCode.RightArrow)
		) {
			dx += delta;
		}

		// movement
		Common.SetPosAndLane(ref x, ref y, ref playerParameter, dx, dy, delta);
		pos.x = x;
		pos.y = y;
		rb.MovePosition(pos);

		// lane effect
		if (playerParameter.lane != oldLane) effect.StartFlash(playerParameter.lane);

		return;

	}
}
