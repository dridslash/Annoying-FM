using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : ExtendedMonoBehaviour
{
	#region Singletone

	public static LevelManager instance { get; private set; }

	#endregion

	public int Level
	{
		get
		{
			return GameData.instance.Level;
		}

		set
		{
			GameData.instance.Level = value;
		}
	}

	[Header("Settings")]
	public LevelManagerData levelData;
	public bool buildOnInitialized = false;
	public bool spawnAsChild = false;
	public bool ShowOnConsole = false;

	void Awake()
	{
		if (instance == null) { instance = this; }
		else { Destroy(this.gameObject); }
	}

	IEnumerator Start()
	{
		while (!GameData.instance.initialized) //Wait for data to load
			yield return null;

		GameDataOnInitialized();
	}

	public virtual void GameDataOnInitialized()
	{
		if (buildOnInitialized)
		{
			SpawnLevel();
		}
	}

	void Update()
	{
		ONLY_EDITOR();
	}

	void ONLY_EDITOR()
	{
		if (Input.GetKeyDown(KeyCode.N))
			NextLvl();

		if (Input.GetKeyDown(KeyCode.B))
			PreviousLvl();
	}

	public void NextLvl()
	{
		Level++;
		LoadLevel();
	}

	public void PreviousLvl()
	{
		Level--;
		LoadLevel();
	}

	void SpawnLevel()
	{
		var prefab = null as GameObject;

		if (Level > levelData.Prefabs.Length - 1)
		{
			Level = 0;
		}
		else if (Level < 0)
		{
			Level = levelData.Prefabs.Length - 1;
		}

		if (ShowOnConsole)
		{
			Debug.Log("Loading Level " + Level);
		}

		prefab = levelData.Prefabs[Level];

		Instantiate(prefab, Vector3.zero, Quaternion.identity, spawnAsChild ? transform : null);
	}

	public void RestartLevel()
	{
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadLevel()
	{
		// SceneManager.LoadScene(0);
		LoadScene(0);
	}
}