using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class Light_Material_Script : MonoBehaviour {

    private SpriteRenderer SR;
    private Vector3 LastPosition;
	// Use this for initialization
	void Awake () {
        SR = GetComponent<SpriteRenderer>();
        SR.sharedMaterial.SetVector("_WorldPosition", transform.position);
        LastPosition = transform.position;
	}

    // Update is called once per frame
    void Update () {
		if(LastPosition != transform.position)
        {
            LastPosition = transform.position;
            SR.material.SetVector("_WorldPosition", transform.position);
        }
	}
}
