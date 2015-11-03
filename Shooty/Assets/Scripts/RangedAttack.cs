using UnityEngine;
using System.Collections;

public class RangedAttack : Attack
{
	//prefab bullet related to this 'bit' -> lots of prefab bits with prefab bullets.
	public GameObject bulletPrefab;

	[SerializeField]
	private float bulletLifetime = 5.0f;
	[SerializeField]
	private float shotSpeed = 25.0f;
	
	public override void BeginAttack() 
	{
		if(bulletPrefab != null && canAttack)
		{
			StartCoroutine(ShootProjectile());
		}
	}

	private IEnumerator ShootProjectile()
	{
		canAttack = false;

		GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) as GameObject;	
		bullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * shotSpeed;
		Destroy(bullet, bulletLifetime);

		yield return StartCoroutine(ToggleCanShoot());
	}

	private IEnumerator ToggleCanShoot()
	{
		yield return new WaitForSeconds(attackRate);
		canAttack = true;
	}
}
