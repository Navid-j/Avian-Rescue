using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptR : MonoBehaviour
{
    private bool oneR = false;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (!oneR)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 120f);
                oneR = true;
                audio.Play();

            }
            else
                gameObject.SetActive(false);
        }
    }
}
