using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 

{

	public float speed; //set speed for the player
	Animator anim; 
	public Image[] hearts;
	public int maxHealth;
	int currentHealth;
	public gameObject sword;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		currentHealth = maxHealth;
		getHealth();
	
	}

	void getHealth()
	{
		for (int i = 0; i <= hearts.Length - 1; i++)
		{
			hearts [i].gameObject.SetActive (false);
		}
		for (int i = 0; i <= currentHealth - 1; i++) 
		{
			hearts [i].gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	
	}
	void Attack()
	{
		GameObject newSword = Instantiate (sword, transform.position, sword.transform.rotation);
		int swordDir = anim.GetInteger ("dir");
		if (swordDir == 0)
			newSword.transform.Rotate (0,0,0);
		else if (swordDir == 1)
			newSword.transform.Rotate (0,0,180);
		else if (swordDir == 2)
			newSword.transform.Rotate (0,0,90);
		else if (swordDir == 3)
			newSword.transform.Rotate (0,0,-90);
		
		 
	}
	void Movement()
	{
		if (Input.GetKey (KeyCode.W)) 
		{ transform.Translate(0,speed * Time.deltaTime,0);anim.SetInteger ("dir",0);  anim.speed = 1;  }//move foward
		else if (Input.GetKey (KeyCode.S)) 
		{ transform.Translate(0,-speed * Time.deltaTime,0);anim.SetInteger ("dir",1); anim.speed = 1;  }//move backward
		else if (Input.GetKey (KeyCode.A)) 
		{ transform.Translate(-speed * Time.deltaTime,0,0);anim.SetInteger ("dir",2); anim.speed = 1;  }//move left
		else if (Input.GetKey (KeyCode.D)) 
		{ transform.Translate(speed * Time.deltaTime,0,0);anim.SetInteger ("dir",3);  anim.speed = 1;  }//move rightt
		else
			anim.speed = 0;

			
	}
}
