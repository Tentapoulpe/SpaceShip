using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage
{

    public float MaxSpeed = 100f;
    public float ForwardAcceleration = 20f;

    public float StraffMaxSpeed = 100f;
    public float StraffTime = 0.1f;

    private Rigidbody _rigidbody;
    private float _smoothXVelocity;

    private float _currentHealth = 3;

    public Projectile ProjectilePrefab;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		Assert.IsNotNull(_rigidbody);

        Assert.IsNotNull(ProjectilePrefab);
	}
	

	private void Update ()
    {
		if(Input.GetKeyDown("Fire1"))
        {
            SpawnProjectile();
        }
	}

    private void SpawnProjectile()
    {
        Projectile projectile = (Projectile)Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
        Vector3 initialVelocity = _rigidbody.velocity;
        initialVelocity.x = 0f;
        initialVelocity.y = 0f;
        projectile.Fire(_rigidbody.velocity);
    }



    private void FixedUpdate()
	{
		Vector3 newVelocity = _rigidbody.velocity;
		if(newVelocity.z > MaxSpeed)
			{
				newVelocity.z = MaxSpeed;
			}
			else 
			{
				newVelocity.z += ForwardAcceleration * Time.fixedDeltaTime;
			}

			float targetVelocity = Input.GetAxis("Horizontal") * StraffMaxSpeed;

			newVelocity.x = Mathf.SmoothDamp(newVelocity.x,targetVelocity, ref _smoothXVelocity, StraffTime);


			_rigidbody.velocity = newVelocity;
	}

	private void LateUpdate()
	{
		
	}

    public void Kill()
    {
        _currentHealth--;

        if ( _currentHealth == 0)
        {
            LevelManager.Instance.PlayerDeath();
        }
    }

    public void TakeDamage(float damage, GameObject instigator)
    {
    _currentHealth -= damage;
        if(_currentHealth <- 0f)
        {
        Kill();
        }

    }

}
