using UnityEngine;

public class playerParameter : MonoBehaviour
{
	public static playerParameter Instance;

	int lane = 1;
	public int Lane {
		get {
			return lane;
		}
		set {
			int result = value;
			if (result < 0) result = 0;
			if (result > 2) result = 2;
			lane = result;
		}
	}

	void Awake() {

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
