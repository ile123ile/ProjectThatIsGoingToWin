using UnityEngine;
using System.Collections;

public class LoseOnTooLow : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y < _MinHeight)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    [SerializeField]
    private float _MinHeight;
}
