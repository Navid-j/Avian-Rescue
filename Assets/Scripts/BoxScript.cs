using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxScript : MonoBehaviour
{

    public PolygonCollider2D collider;
    private SpriteRenderer spriteRenderer;

    public Sprite bombSprite;
    public Sprite bombSprite2;
    public Sprite birdSprite;
    private Animator animator;

    public AudioSource audio;
    public AudioClip clipBomb;
    public AudioClip clipBird;
    public AudioClip clipWin;
    public AudioClip clipLose;

    private Rigidbody2D rb;
    public float drag = 2f;

    private bool jump;

    public bool isBomb;

    public GameObject carFire;
    public GameObject gameOverDialog;


    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 23 || transform.position.y < -23)
        {

            gameObject.SetActive(false);

        }

        if (transform.position.x > 23 || transform.position.x < -23)
        {

            gameObject.SetActive(false);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (jump)
            {
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(4,6), ForceMode2D.Impulse);
                collider.enabled = false;
                rb.drag = drag;

                transform.parent = null;

                if (!animator.GetBool("Bomb"))
                    Player_Movment.COUNTER++;
                Debug.Log("Coounter: " + Player_Movment.COUNTER);

                StartCoroutine(birdFly());
            }

            jump = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Fire", true);
            audio.PlayOneShot(clipLose);

            carFire.SetActive(true);
            StartCoroutine(gameOverFire());


        }

    }

    IEnumerator birdFly()
    {


        // Wait for 2 seconds
        yield return new WaitForSeconds(1.5f);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        animator.enabled = true;
        if (!isBomb)
        {
            animator.SetBool("Bird", true);
            spriteRenderer.sprite = birdSprite;
            audio.PlayOneShot(clipBird);
        }
        else
        {
            animator.SetBool("Bomb", true);
            spriteRenderer.sprite = bombSprite;
            collider.enabled = true;
        }

    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        Player_Movment.COUNTER = 0;
        SceneManager.LoadScene(0);
    }

    public void nextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    IEnumerator gameOverFire()
    {

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
        audio.PlayOneShot(clipLose);

        gameOverDialog.SetActive(true);
    }
}