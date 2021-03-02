using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour
{
	public float Speed = 3.0f;
	public float angel = 90, rayrange = 4;
	public int numberofrays = 30;
	private Vector3 startPos;
	public Vector3 endPos;



	private void Update()
	{
		Vector3 dir = (endPos - transform.position).normalized;

		transform.position = transform.position + dir * Time.deltaTime *6* Speed;

		// if raft is close to end point, reset
		if (Vector3.Distance(endPos, transform.position) <= (dir * Time.deltaTime *6* Speed).magnitude)
		{
			ResetCube();
		}


		if (transform.position.z > -15 && transform.position.z<14 )
			transform.rotation= Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( dir), Time.deltaTime * 50);


		// check for surroundings
		var delatpos = Vector3.zero;
		for (int i = 0; i < numberofrays; i++)
		{
			var rotation = this.transform.rotation;
			var rotationmod = Quaternion.AngleAxis((i / ((float)numberofrays - 1)) * angel * 4 - angel, this.transform.up);
			var direction = rotation * rotationmod * Vector3.forward ;

			var ray = new Ray(this.transform.position+  Vector3.forward, direction*3);
			RaycastHit hitinfo;
			if (Physics.Raycast(ray, out hitinfo, rayrange))
			{
				delatpos -= (1.0f / numberofrays) *Speed * direction*10;
			}
			else
			{
				delatpos += (1.0f / numberofrays) * Speed * direction*10;
			}

		}
		//this.transform.position += delatpos * Time.deltaTime;


		//this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + (Vector3.back*4)  , Time.deltaTime);

		if (transform.position.z > -12 && transform.position.z <-2)
			transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation(delatpos*5 +this.transform.position), Time.deltaTime *8 );

		this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position  + delatpos , Time.deltaTime*2);

	}
	private void OnDrawGizmos()
	{
		for (int i = 0; i < numberofrays; i++)
		{ 
			var rotation = this.transform.rotation;
			var rotationmod = Quaternion.AngleAxis((i / ((float)numberofrays - 1)) * angel * 4 - angel, this.transform.up);
			var direction = rotation * rotationmod * Vector3.forward ;
			Gizmos.DrawRay(this.transform.position +  Vector3.forward, direction * 4);

		}
	}
	private void ResetCube()
	{
		startPos = new Vector3(Random.Range(-15f, 15f), 0.0f, -15f);
		endPos = startPos;
		endPos.x = Random.Range(-15f, 15f);
		endPos.z *= -1.0f;
		transform.position = startPos;
	}

	private void Start()
	{
		ResetCube();
	}


}