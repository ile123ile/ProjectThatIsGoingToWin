using UnityEngine;
using System.Collections;

public class ConveyerBelt : MonoBehaviour {

	void OnCollisionStay2D(Collision2D col)
    {
        foreach(ContactPoint2D contact in col.contacts)
        {
            Rigidbody2D rb = contact.collider.gameObject.GetComponent<Rigidbody2D>();
            if(rb)
            {
                Vector2 force = contact.normal;
                force = new Vector2(-1*force.y, -1 * force.x);
                rb.AddForce(force*_Strength);
            }
        }
    }

    [SerializeField]
    private float _Strength;
}
