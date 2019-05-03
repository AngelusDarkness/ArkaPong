using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	public GameManager gameManager;
	private GameObject _particleEffect;
	
	
	void Start()
	{
		_particleEffect = transform.GetChild(0).gameObject;
		_particleEffect.SetActive(false);
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.CompareTag("Ball"))
		{
			col.gameObject.GetComponent<Rigidbody>().AddForce(gameManager.ballSpeed,
			gameManager.ballSpeed,0);
			_particleEffect.SetActive(true);
			GetComponent<Renderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
			Invoke("DestroyMe",1f);
		}
	}
	
	void DestroyMe()
	{
		gameManager.AddScore(1);
		Destroy(gameObject);
	}
	
	
}
