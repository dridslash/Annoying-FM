
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelManager Data", menuName = "Scriptable Objects/Level Manager Data", order = 20)]
public class LevelManagerData : ScriptableObject
{
	[SerializeField] GameObject[] prefabs;

	public GameObject[] Prefabs
	{
		get => prefabs;
		set => prefabs = value;
	}
}