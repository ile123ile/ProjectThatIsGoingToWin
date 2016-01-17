using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _RigidBody = GetComponent<Rigidbody2D>();
	}

    Vector2 getNormal(Collision2D col)
    {
        Vector2 total = Vector2.zero;
        foreach(ContactPoint2D vec in col.contacts)
        {
            total += vec.normal;
        }
        total /= col.contacts.Length;
        return total;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        _NormalVector = Vector3.Normalize(getNormal(col));
        _IsOnGround = .1f;
    }

    void FixedUpdate()
    {
        
        _IsOnGround -= Time.deltaTime;
        //if(_IsOnGround < 0 )
        {
            _NormalVector = new Vector2(0, 1);
        }
        int direction = Input.GetKey(_LeftKey) ? -1 : 0;
        direction = Input.GetKey(_RightKey) ? direction + 1 : direction;
        Vector2 force = _Speed * direction * _NormalVector;
        force = new Vector2(force.y, -1*force.x);
        _RigidBody.AddForce(force);
        if (_IsOnGround > 0)
        {
            if (Input.GetKeyDown(_UpKey))
            {
                _RigidBody.velocity = _RigidBody.velocity + _JumpStrength * _NormalVector;
            }
        }

    }

    [SerializeField]
    private float _Speed;
    [SerializeField]
    private float _JumpStrength;
    [SerializeField]
    private KeyCode _RightKey;
    [SerializeField]
    private KeyCode _LeftKey;
    [SerializeField]
    private KeyCode _UpKey;

    private Rigidbody2D _RigidBody;
    private float _IsOnGround;
    private Vector2 _NormalVector;
}
