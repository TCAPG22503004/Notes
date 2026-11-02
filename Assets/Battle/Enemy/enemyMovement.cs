using UnityEngine;

public class enemyMovement : MonoBehaviour 
{
	[SerializeField] Rigidbody2D rb;
	[SerializeField] SpriteRenderer sr;
	[SerializeField] Parameter enemyParameter, playerParameter;

	Transform player;
	Vector2 v = new Vector2(0, 0);
	bool isMoving = true;
	float playerBoxSize, enemyBoxSize;

	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;

		playerBoxSize = player.gameObject.GetComponent<BoxCollider2D>().size.x;
		enemyBoxSize = this.gameObject.GetComponent<BoxCollider2D>().size.x;
	}

	void FixedUpdate()
	{
		sr.sortingOrder = (int)(-10 * rb.position.y);

		if (isMoving) Movement();
		SetIsMoving();
	}

	void Movement() {

		// values
		float x = rb.position.x;
		float y = rb.position.y;
		float px = player.position.x;
		float py = player.position.y;
		float dx = 0;
		float dy = 0;
		float delta = enemyParameter.speed * Time.fixedDeltaTime;

		// set dx
		float d = enemyParameter.attackRange * 0.9f;
		if (x < px) d *= -1;
		float x2 = px + d;

		if (System.Math.Abs(x2 - x) > 0.01f) {
			dx = delta;
			if (x2 < x) dx *= -1;
		}
		
		// set dy
		int n = System.Math.Abs(enemyParameter.lane - playerParameter.lane);
		if (n != 0) {
			bool b1 = ((px + playerBoxSize / 2) < (x - enemyBoxSize / 2));
			bool b2 = ((px - playerBoxSize / 2) > (x + enemyBoxSize / 2));

			if ((b1 || b2) || (n > 1)) {
				dy = delta;
				if (y > py) dy *= -1;
			}
		}

		// movement
		Common.SetPosAndLane(ref x, ref y, ref enemyParameter, dx, dy, delta);
		v.x = x;
		v.y = y;
		rb.MovePosition(v);

		return;
	}


	void SetIsMoving() {

		// lane
		if (System.Math.Abs(rb.position.y - player.position.y) > 0.001f) {
			isMoving = true;
			return;
		}

		// distance
		v.x = player.position.x;
		v.y = player.position.y;

		float d1 = (rb.position - v).sqrMagnitude;
		float d2 = enemyParameter.attackRange * enemyParameter.attackRange;

		isMoving = (d1 >= d2);

		return;
	}
}
