using UnityEngine;

public class enemyMovement : MonoBehaviour 
{
	Transform player;

	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
	}
}
