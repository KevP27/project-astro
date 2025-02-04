using UnityEngine;
using UnityEngine.Events;

public class BulletHealth : MonoBehaviour
{
	public float maxHealth = 20;
	public float currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}