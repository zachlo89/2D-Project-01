using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private int maxHealth;
    public int currentHealth;
    private Animator animator;
    private PlayerControllerRigidbody playerController;
    private Collider collider;
    private Rigidbody rb;
    private bool damagable;

    private Renderer renderer;
    private Color defaultColor;
    private Color redFeedback;


    private void Start()
    {
        damagable = true;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        currentHealth = maxHealth;
        healthManager.SetHealthBar(maxHealth);
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerControllerRigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        defaultColor = renderer.material.color;
        redFeedback = new Color(1, 0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && damagable)
        {
            --currentHealth;
            healthManager.RemoveHealth();
            StartCoroutine("Blink");
        }

        if(currentHealth <= 0)
        {
            animator.SetFloat("runningVertically", 0);
            animator.SetFloat("runningHorizontaly", 0);
            rb.useGravity = false;
            collider.enabled = false;
            playerController.enabled = false;
            animator.SetBool("isDead", true);
            Debug.Log("You died");
        }

        if (other.CompareTag("Killable"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") && damagable)
        {
            --currentHealth;
            healthManager.RemoveHealth();
            StartCoroutine("Blink");
        }

        if (currentHealth <= 0)
        {
            animator.SetFloat("runningVertically", 0);
            animator.SetFloat("runningHorizontaly", 0);
            rb.useGravity = false;
            collider.enabled = false;
            playerController.enabled = false;
            animator.SetBool("isDead", true);
            Debug.Log("You died");
        }

        if (collision.collider.CompareTag("Killable"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator Blink()
    {
        damagable = false;
        for(int i = 0; i < 4; i++)
        {
            renderer.material.color = redFeedback;
            yield return new WaitForSeconds(.1f);
            renderer.material.color = defaultColor;
            yield return new WaitForSeconds(.1f);
        }
        damagable = true;
    }
}
