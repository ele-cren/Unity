using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage = 70;

	public int GetDamages ()
	{
		return damage;
	}

	public void Hit ()
	{
		Destroy (gameObject);
	}
}
