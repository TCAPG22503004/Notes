using UnityEngine;

public class Init : MonoBehaviour
{
	[SerializeField] laneParameter lane;

	void Awake() {
		Common.Init(lane);
	}


	# if UNITY_EDITOR
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
	# endif
}
