using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {

    public float ShrinkRate { get { return _ShrinkRate; } set { _ShrinkRate = value; } }

    void Start()
    {
        _Players = GameObject.FindGameObjectsWithTag("Player");
        _MyRB = GetComponent<Rigidbody2D>();
        this.transform.localScale = Vector3.one * _MyRB.mass * _Scale;
    }

	// Update is called once per frame
	void Update ()
    {
        _MyRB.mass -= Time.deltaTime * ShrinkRate;
        this.transform.localScale = Vector3.one * _MyRB.mass * _Scale;
        foreach (GameObject player in _Players)
        {
            Vector2 direction = transform.position - player.transform.position;
            float sqrDistance = direction.SqrMagnitude();
            direction = Vector3.Normalize(direction);
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            Vector2 force = _GravityConstant * direction * _MyRB.mass * playerRB.mass / sqrDistance;
            if (sqrDistance < _Scale * _Scale * _MyRB.mass * _MyRB.mass)
            {
                force *= Mathf.Pow(sqrDistance, 1.5f) / Mathf.Pow(_Scale * _MyRB.mass, 3f);
            }
            playerRB.AddForce(force);
        }
	}
    [SerializeField]
    private float _Scale;
    [SerializeField]
    private float _GravityConstant;

    private GameObject[] _Players;

    private Rigidbody2D _MyRB;

    private float _ShrinkRate;
}
