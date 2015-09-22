using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour 
{
	//prefab bullet related to this 'bit' -> lots of prefab bits with prefab bullets.
	public GameObject bulletPrefab;

	[SerializeField]
	private float bulletLifetime = 5.0f;
	[SerializeField]
	private float shotSpeed = 25.0f;
	[SerializeField]
	private float fireRate = 1.0f;

	private bool canShoot = true;
	
	private void StartShooting() 
	{
		if(bulletPrefab != null && canShoot)
		{
			StartCoroutine(ShootProjectile());
		}
	}

	private IEnumerator ShootProjectile()
	{
		canShoot = false;

		GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) as GameObject;	
		bullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * shotSpeed;
		Destroy(bullet, bulletLifetime);

		yield return StartCoroutine(ToggleCanShoot());
	}

	private IEnumerator ToggleCanShoot()
	{
		yield return new WaitForSeconds(fireRate);
		canShoot = true;
	}
}
