﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementCamera : MonoBehaviour {

	public GameObject CameraFPS;
	public GameObject CameraTOP;
	public GameObject CameraTPS;
	private int activeCamera = 0;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	void ChangeCamera()
	{
		if (Input.GetKeyDown("c"))
		{
			if (activeCamera == 0)
			{

				CameraTOP.SetActive(false);
				CameraTPS.SetActive(true);
				activeCamera += 1;
				return;

			}
			if (activeCamera == 1)
			{

				CameraTPS.SetActive(false);
				CameraFPS.SetActive(true);
				activeCamera += 1;
				return;

			}
			if (activeCamera == 2)
			{

				CameraFPS.SetActive(false);
				CameraTOP.SetActive(true);
				activeCamera = 0;
				return;

			}	
		}
	}
	// Update is called once per frame
	void Update () 
	{
		ChangeCamera();
	}
}
