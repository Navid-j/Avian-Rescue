using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private bool one = false;
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
            if (!one)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -20f);
                one = true;
                audio.Play();
            }
            else
                gameObject.SetActive(false);
        }
    }
}
