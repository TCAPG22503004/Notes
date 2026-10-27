using UnityEngine;

public class Init : MonoBehaviour
{
	[SerializeField] laneParameter lane;

	void Awake() {
		Common.Init(lane);
	}
}
