using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int health = 10;
	public float speed = 10;

	int weapon = 0;			// 0: gun, 1:sword 
	public GameObject gun, sword;

	public GameObject bullet;
	public Transform bulletPos;
	public Image hpBar;
	public Animator swordAnim;

	void Start () {
	}

	void Update () {

		// Die
		if (health <= 0)
			Destroy (gameObject);

//		// Movement
//		float horizontal = Input.GetAxis("Horizontal");
//		float vertical = Input.GetAxis("Vertical");
//
//		transform.Translate (Vector3.forward * vertical * speed * Time.deltaTime);
//		transform.Translate (Vector3.right * horizontal * speed * Time.deltaTime);


		// Attack
		if (Input.GetButtonDown ("Fire1")) 
		{	
			// Sword
			if (weapon == 0) 
			{
				swordAnim.SetTrigger ("attack");
			} 
			// Gun
			else if (weapon == 1) 
			{
				Instantiate (bullet, bulletPos.position, bulletPos.rotation);
			}
		}

		// Switch weapon
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (weapon == 1) {
				weapon = 0;
			} else {
				weapon = 1;
			}
		}
		if (weapon == 1) {
			sword.SetActive (false);
			gun.SetActive (true);
		} else {
			sword.SetActive (true);
			gun.SetActive (false);
		}

		// Update HP bar
		hpBar.fillAmount = (float)health/10;

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Enemy") 
		{
			health--;
		}
	}
}
