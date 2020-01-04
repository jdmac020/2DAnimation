using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	Rigidbody2D rigi;
    Animator anim;
	public float speed = 0.1f;
	bool facingRight = true;

	void Awake()
	{
		rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
        float Hmove = Input.GetAxis("Horizontal");

        if (Hmove < - 0.1f)
		{
			// moving left
			if (facingRight)
				Flip();
			rigi.MovePosition(new Vector2(transform.position.x - speed, transform.position.y));
		}
        else if (Hmove > 0.1f)
		{
			// moving right
			if (!facingRight)
				Flip();
			rigi.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
		}

        anim.SetFloat("move", Mathf.Abs(Hmove));
	}

	void Flip()
	{
		Vector3 temp = transform.localScale;
		transform.localScale = new Vector3(-temp.x, temp.y, temp.z);
        facingRight = !facingRight;
	}

}
