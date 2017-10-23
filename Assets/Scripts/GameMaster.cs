using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	// Timer
	public float timeLimit = 60;
	public Text timeText;

	// Score
	public static int score = 0;
	public Text scoreText;

	// GameOver Panel
	public GameObject gameOverP;

	// Player
	GameObject player;

	// Enemy
	public GameObject enemy;
	public Transform[] spawnPos;
	public int maxEnemyNum = 5;
	public float enemySpwanTime = 3;
	public static int enemyNum = 0;
	float spwanTimer = 0;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		gameOverP.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			
			// Enemy Spawn
			spwanTimer += Time.deltaTime;
			if (enemyNum < maxEnemyNum && spwanTimer > enemySpwanTime) {
				spwanTimer = 0;
				enemyNum++;
				Instantiate (enemy, spawnPos [Random.Range (0, spawnPos.Length - 1)].position, Quaternion.identity);
			}

			// Timer & Score Text
			timeLimit -= Time.deltaTime;
			timeText.text = "Time: " + (int)timeLimit;
			scoreText.text = "Score: " + score;
		} else {

			gameOverP.SetActive (true);
		}
	}

	public void Retry()
	{
		SceneManager.LoadScene ("Game_Demo", LoadSceneMode.Single);
	}
}
