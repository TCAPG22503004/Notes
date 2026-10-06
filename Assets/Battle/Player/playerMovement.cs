using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[SerializeField] float speed;

	Rigidbody2D rb;

	int lane = 1;

	void Awake() {

		rb = this.gameObject.GetComponent<Rigidbody2D>();

	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void FixedUpdate() {

		Movement();

	}


	void Movement() {

		Vector2 velocity = new Vector2(0, 0);

		// input
		if (
			Input.GetKey(KeyCode.W) ||
			Input.GetKey(KeyCode.UpArrow)
		) {
			velocity.y += speed;
		}

		if (
			Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.LeftArrow)
		) {
			velocity.x -= speed;
		}

		if (
			Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.DownArrow)
		) {
			velocity.y -= speed;
		}

		if (
			Input.GetKey(KeyCode.D) ||
			Input.GetKey(KeyCode.RightArrow)
		) {
			velocity.x += speed;
		}


		// fit lane
		if (velocity.y == 0) velocity.y += ResetY();


		// move
		velocity *= Time.fixedDeltaTime;
		Vector2 newPos = ToTrapezoid(velocity);
		rb.MovePosition(newPos);

		return;
	}


	float ResetY() {

		int sign = 0;

		float y = rb.position.y - (laneParameter.Instance.LaneY[lane]);

		if (Mathf.Abs(y) < 0.0001) {
			// remain 0
		}

		else if (y < 0) {
			sign = 1;
		}

		else {
			sign = -1;
		}

		return speed * sign;

	}


	Vector2 ToTrapezoid(Vector2 v) {

		// correct velocity x
		float dy = laneParameter.Instance.LaneY[2] - laneParameter.Instance.LaneY[0];
		float normalizedY = (1 / dy * rb.position.y) - (laneParameter.Instance.LaneY[0] / dy);
		float ratio = (1 + ((laneParameter.Instance.LenRatio-1) * normalizedY));
		v.x *= ratio;

		// add x when |y| > 0
		float maxLength = laneParameter.Instance.TopLength / 2 * ratio;
		float normalizedX = rb.position.x / maxLength;
		if (v.x == 0) v.x += ratio * -normalizedX * v.y;

		// into stage
		v += rb.position;
		normalizedY = (1 / dy * v.y) - (laneParameter.Instance.LaneY[0] / dy);
		ratio = (1 + ((laneParameter.Instance.LenRatio-1) * normalizedY));

		float xMax = laneParameter.Instance.TopLength / 2 * ratio;
		float xMin = -xMax;
		float yMax = laneParameter.Instance.LaneY[0];
		float yMin = laneParameter.Instance.LaneY[2];

		if (v.x > xMax) v.x = xMax;
		if (v.x < xMin) v.x = xMin;
		if (v.y > yMax) v.y = yMax;
		if (v.y < yMin) v.y = yMin;
		
		return v;

	}

/*
	float GetRatio(float y) {

		float dy = laneY[2] - laneY[0];

		float ratio = (1 / dy * y) - (laneY[0] / dy);

		return (1 + ((lenRatio-1) * ratio));

	}
*/
}
