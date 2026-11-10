using UnityEngine;

public class playerAnimate : MonoBehaviour
{
	public static playerAnimate instance;

	[SerializeField] Animator animator;

	int modeHash, attackHash;
	int nMode = 0, nAttack = 0;

	void Awake()
	{
		instance = this;

		modeHash = Animator.StringToHash("mode");
		attackHash = Animator.StringToHash("attack");
	}


	// run
	public void StartRun() {

		if (nMode != 0) return;
		nMode = 1;

		animator.SetInteger(modeHash, nMode);

		return;
	}

	public void EndRun() {
	
		if (nMode != 1) return;
		nMode = 0;

		EndAnimate();

		return;
	}


	// attack
	public void Attack() {
		
		if (nAttack == 0) {
			StartAttack();
		}

		else {
			IncrementAttack();
		}

		return;
	}

	void StartAttack() {

		nAttack = 1;
		nMode = 2;

		animator.SetInteger(modeHash, nMode);
		animator.SetInteger(attackHash, nAttack);

		playerMovement.instance.canMove = false;

		return;
	}

	void IncrementAttack() {

		nAttack++;

		animator.SetInteger(attackHash, nAttack);

		return;
	}


	// end
	void EndAnimate() {

		nMode = 0;
		nAttack = 0;

		animator.SetInteger(modeHash, nMode);
		animator.SetInteger(attackHash, nAttack);

		playerMovement.instance.canMove = true;
		playerAttack.instance.canAttack = true;

		return;
	}
}
