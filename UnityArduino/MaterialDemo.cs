using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDemo : MonoBehaviour
{
    Renderer capsuleColor;
    // Start is called before the first frame update
    void Start()
    {
        capsuleColor = gameObject.GetComponent<Renderer>();
    }
//
    // Update is called once per frame
    void Update()
    {
        capsuleColor.material.color = Color.blue;
        capsuleColor.material.color = Color.red;
    }
}
