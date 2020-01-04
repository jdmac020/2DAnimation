using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	Rigidbody2D rigi;
	public float speed = 0.1f;
	bool facingRight = true;

	void Awake()
	{
		rigi = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (Input.GetAxis("Horizontal") < - 0.1f)
		{
			// moving left
			if (facingRight)
				Flip();
			rigi.MovePosition(new Vector2(transform.position.x - speed, transform.position.y));
		}
		else if (Input.GetAxis("Horizontal") > 0.1f)
		{
			// moving right
			if (!facingRight)
				Flip();
			rigi.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
		}
	}

	void Flip()
	{
		Vector3 temp = transform.localScale;
		transform.localScale = new Vector3(-temp.x, temp.y, temp.z);
        facingRight = !facingRight;
	}

}
