using UnityEngine;

public class playerMovement : MonoBehaviour
{
	[SerializeField] float speed;

	Rigidbody2D rb;

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
			velocity.y += MoveY();
		}

		if (
			Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.LeftArrow)
		) {
			velocity.x -= MoveX();
		}

		if (
			Input.GetKey(KeyCode.S) ||
			Input.GetKey(KeyCode.DownArrow)
		) {
			velocity.y -= MoveY();
		}

		if (
			Input.GetKey(KeyCode.D) ||
			Input.GetKey(KeyCode.RightArrow)
		) {
			velocity.x += MoveX();
		}


		// fit lane
		if (velocity.y == 0) velocity.y += ResetY();


		// move
		rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

		return;
	}


	float MoveX() {

		return speed;

	}

	float MoveY() {

		return speed;

	}

	float ResetY() {

		int sign = 0;

		float y = rb.position.y - (-4.4f);

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
}
