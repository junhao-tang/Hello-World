using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    public float lifeTime;

	// Use this for initialization
	void Start () {  // every object with this script will self destruct
        Destroy(gameObject, lifeTime);
	}
}
