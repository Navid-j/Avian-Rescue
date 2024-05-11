using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Road_Movment : MonoBehaviour
{
    public Renderer meshRenderer;

    public float speed = 0.5f;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Offset = meshRenderer.material.mainTextureOffset;
        Offset = Offset + new Vector2(0, speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = Offset;
        
        /*meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);*/
    }

    
}
