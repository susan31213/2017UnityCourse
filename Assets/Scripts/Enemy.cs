using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	GameObject player;

	public float speed = 5;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void Update () {
		if(player != null)
			transform.Translate ((player.transform.position - transform.position).normalized * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.GetComponent<Collider>().tag == "Sword") 
		{
			GameMaster.enemyNum--;
			GameMaster.score += 10;
			Destroy (gameObject);
		}
	}
}
