using UnityEngine;

public class laneEffect : MonoBehaviour
{
	public static laneEffect Instance;

	[SerializeField] SpriteRenderer[] sr = new SpriteRenderer[3];

	float speed = 250;

	byte r = 162;
	byte g = 255;
	byte b = 249;
	float a0 = 110;

	float[] alpha = new float[3];

	void Awake() {

		// set alpha
		for (int i = 0; i < 3; i++) {
			alpha[i] = 0;
		}

		// set instance
		Instance = this;

	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		Flash();
	}


	public void StartFlash(int n) {

		if (n >= 0 && n < 3) alpha[n] = a0;

		return;

	}

	void Flash() {

		for (int i = 0; i < 3; i++) {

			if (alpha[i] > 0) {

				alpha[i] -= speed * Time.deltaTime;

				byte a = (byte)alpha[i];

				sr[i].color = new Color32(r, g, b, a);

			}

		}

		return;

	}
}
