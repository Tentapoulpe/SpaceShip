using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class AddForce2 : MonoBehaviour {


public float MaxSpeed = 100f;
public float ForwardAcceleration = 20f;

public float StraffMaxSpeed = 100f;
public float StraffTime = 0.1f;

private Rigidbody _rigidbody;
private float _smoothXVelocity;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		Assert.IsNotNull(_rigidbody);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		Debug.Log(_rigidbody.velocity.z);
	}

	private void OnCollisionEnter(Collision collision)
	{
		 if (collision.gameObject.CompareTag("MurDeath"))
        
        	{
        	    SceneManager.LoadScene("MainScene");
        	}
	}
}
