using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public static playerMovement instance;

	[SerializeField] Rigidbody2D rb;
	[SerializeField] SpriteRenderer sr;
	[SerializeField] Parameter playerParameter;

	Vector2 pos = new Vector2(0, 0);
	Quaternion qLeft = new Quaternion(0, -1, 0, 0);
	Quaternion qRight = new Quaternion(0, 0, 0, 1);
	public bool canMove = true;

	void Awake() {
		instance = this;
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
		if (canMove) {
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

		}


		// movement
		Common.SetPosAndLane(ref x, ref y, ref playerParameter, dx, dy, delta);
		pos.x = x;
		pos.y = y;
		rb.MovePosition(pos);

		// miscellaneous
		Other(oldLane, dx, dy);

		return;

	}


	void Other(int oldLane, float dx, float dy) {

		// lane effect
		if (playerParameter.lane != oldLane) laneEffect.instance.StartFlash(playerParameter.lane);


		// rotate
		if (dx > 0) {
			this.transform.rotation = qRight;
		}
		else if (dx < 0) {
			this.transform.rotation = qLeft;
		}


		// animate
		if (dx != 0 || dy != 0) {
			playerAnimate.instance.StartRun();
		}
		else {
			playerAnimate.instance.EndRun();
		}

		return;

	}
}
