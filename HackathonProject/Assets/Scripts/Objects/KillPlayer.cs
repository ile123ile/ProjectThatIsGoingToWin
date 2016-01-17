using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
