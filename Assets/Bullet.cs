using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 15;

	void Update () 
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy") 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
			GameMaster.enemyNum--;
			GameMaster.score += 10;
		}
		if (col.tag == "Clear")
			Destroy (gameObject);
	}
}
