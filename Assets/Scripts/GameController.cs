using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 HazardPosition;
	public int HazardCount;
	public float SpawnWait;
	public float StartWait;
	public float WaveSpawnWait;

	public GUIText scoreText;
	public GUIText startGameText;
	public GUIText gameOverText;
	private int score;

	private bool gameOver;
	private bool restart;
	void Start()
	{
		gameOver = false;
		restart = false;
		startGameText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnHazard ());
	}

	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator spawnHazard()
	{
		yield return new WaitForSeconds (StartWait);
		while (true) {
			for (int i = 0; i < HazardCount; i++) 
			{
				GameObject hazard=hazards[Random.Range(0,hazards.Length)];
				Vector3 SpawnHazardposition = new Vector3 (Random.Range (-HazardPosition.x, HazardPosition.x), HazardPosition.y, HazardPosition.z);
				Quaternion SpawnHazardrotation = Quaternion.identity;
				Instantiate (hazard, SpawnHazardposition, SpawnHazardrotation);
				yield return new WaitForSeconds (SpawnWait);
			}
			yield return new WaitForSeconds (WaveSpawnWait);

			if (gameOver)
			{
				startGameText.text="Press 'R' to restart the game";
				restart = true;
			}
		}
	}

	public void AddScore(int newScore)
	{
		score += newScore;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text="Game Over!";
		gameOver = true;
	}
}

