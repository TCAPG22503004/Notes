using UnityEngine;

public class laneEffect : MonoBehaviour
{
	[SerializeField] SpriteRenderer[] sr = new SpriteRenderer[3];

	float speed = 250;

	byte r = 162;
	byte g = 255;
	byte b = 249;
	float a0 = 110;

	float[] alpha = new float[3];
	Color32 c32;

	void Awake() {

		// set alpha
		for (int i = 0; i < 3; i++) {
			alpha[i] = 0;
		}

		// set color rgb
		c32 = new Color32(r, g, b, 0);
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

				// set alpha
				alpha[i] -= speed * Time.deltaTime;
				if (alpha[i] < 0) alpha[i] = 0;
				byte a = (byte)alpha[i];

				// change color
				c32.a = a;
				sr[i].color = c32;
			}
		}

		return;

	}
}
