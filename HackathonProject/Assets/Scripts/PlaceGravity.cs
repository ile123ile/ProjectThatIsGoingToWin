using UnityEngine;
using System.Collections;

public class PlaceGravity : MonoBehaviour {

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Test");
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mouse);
            spawnPos.z = 0;
            _SpawnedWell = ((GameObject)Instantiate(_GravityWell, spawnPos, Quaternion.Euler(0, 0, 0))).GetComponent<Rigidbody2D>();
            _SpawnedWell.mass = 0;
            _SpawnedWell.GetComponent<GravityWell>().ShrinkRate = 0;
        }
        if(Input.GetMouseButton(0))
        {
            if (_SpawnedWell.mass < _MaxSize)
            {
                _SpawnedWell.mass += Time.deltaTime * _MassPerSecond;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            _SpawnedWell.GetComponent<GravityWell>().ShrinkRate = _MassPerSecond;
        }
    }

    [SerializeField]
    private GameObject _GravityWell;
    [SerializeField]
    private float _MassPerSecond;
    [SerializeField]
    private float _MaxSize;

    private Rigidbody2D _SpawnedWell;
}
