using UnityEngine;
using System.Collections;

public class WinOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (_ToTouch == col.gameObject)
        {
            Application.LoadLevel(_LevelToLoad);
        }
    }

    [SerializeField]
    private GameObject _ToTouch;
    [SerializeField]
    private string _LevelToLoad;
}


