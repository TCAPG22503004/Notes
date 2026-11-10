using UnityEngine;

public class playerAttack : MonoBehaviour
{
	public static playerAttack instance;

	public bool canAttack = true;

	void Awake() {
		instance = this;
	}

	void Update() {

		if (canAttack && Input.GetMouseButtonDown(0)) {
			canAttack = false;
			playerAnimate.instance.Attack();
		}

	}
}
