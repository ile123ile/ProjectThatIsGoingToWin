using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	void Update () {
        Vector3 position = _FollowTarget.position;
        position.z = -10;
        this.transform.position = position;
	}

    [SerializeField]
    private Transform _FollowTarget;
}
