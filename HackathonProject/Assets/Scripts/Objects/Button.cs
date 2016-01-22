using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {
        _ObjectToActivate.SetActive(!_ObjectToActivate.active);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _ObjectToActivate.SetActive(!_ObjectToActivate.active);
    }

    [SerializeField]
    private GameObject _ObjectToActivate;
}
