using UnityEngine;

public class stageParameter : MonoBehaviour
{
	public static stageParameter Instance;

	// lane y
	float[] y = new float[3];	// set in Awake()

	public float Y(int n) {

		if (n < 0) n = 0;
		if (n > 2) n = 2;

		return y[n];
	}

	// lane height
	float height;	// set in Awake()
	public float Height { get { return height; } }

	// top lane length
	float topLength = 14.4f;
	public float TopLength { get { return topLength; } }

	// length ratio (= bottom / top)
	float lenRatio = 1.125f;
	public float LenRatio { get { return lenRatio; } }



	void Awake() {

		// set lane y
		for (int i = 0; i < 3; i++) {
			y[i] = this.transform.GetChild(i).transform.position.y;
		}

		// set lane height
		height = y[2] - y[0];

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
		
	}

}
