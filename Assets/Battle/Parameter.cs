using UnityEngine;

[CreateAssetMenu(fileName = "Parameter", menuName = "Scriptable Objects/Parameter")]
public class Parameter : ScriptableObject
{ 
	[Range(0, 10)] public float speed;
	[Range(0,  2)] public int lane;
	[Range(0, 14)] public float attackRange;
}
