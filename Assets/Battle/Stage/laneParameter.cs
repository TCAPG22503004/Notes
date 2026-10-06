using UnityEngine;

public class laneParameter : MonoBehaviour
{
	public static laneParameter Instance;

	// lane y
	float[] laneY = new float[3];	// set in Awake()
	public float[] LaneY{ get { return laneY; } }

	// top lane length
	float topLength = 14.4f;
	public float TopLength { get { return topLength; } }

	// length ratio (= bottom / top)
	float lenRatio = 1.125f;
	public float LenRatio { get { return lenRatio; } }



	void Awake() {

		// set lane y
		for (int i = 0; i < 3; i++) {
			laneY[i] = this.transform.GetChild(i).transform.position.y;
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
		
	}
}
