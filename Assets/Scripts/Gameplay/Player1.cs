using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour 
{	
	public float speed = 1;	
	public GameManager gameManager;				
	private bool _isPlaying = false;	
	
	private float _currentDirection;  
	// Update is called once per frame
//	void Update () 
//	{
//			
//		if(Input.GetAxis("Horizontal") != 0)
//		{
//			Vector3 newPos = transform.position;
//			newPos.x = Mathf.Clamp(newPos.x + (Input.GetAxis("Horizontal") * Time.deltaTime * speed), -17f, 17f);
//			transform.position = newPos;	
//			
//			_currentDirection = Input.GetAxis("Horizontal");
//			
//			//Check if is Playing already
//			if(!_isPlaying)
//			{
//				gameManager.StartGame();		
//				_isPlaying = true;
//			}					
//		}
//	}
//	
//	void OnCollisionEnter(Collision col)
//	{
//		if(col.gameObject.CompareTag("Ball") && _isPlaying)
//		{
//			//If current direction is bigger than 0, i'm going to fucking right.
//			if(_currentDirection > 0)
//			{
//				col.gameObject.GetComponent<Rigidbody>().AddForce(gameManager.ballSpeed,
//				gameManager.ballSpeed,0);	
//			}
//			else
//			{
//				col.gameObject.GetComponent<Rigidbody>().AddForce(-gameManager.ballSpeed,
//																  gameManager.ballSpeed,0);
//			}
//			
//		}
//	}
}
