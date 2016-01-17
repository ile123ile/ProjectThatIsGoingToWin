using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {
        _ObjectToActivate.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _ObjectToActivate.SetActive(false);
    }

    [SerializeField]
    private GameObject _ObjectToActivate;
}
