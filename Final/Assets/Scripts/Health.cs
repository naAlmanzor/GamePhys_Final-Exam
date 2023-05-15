using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image healthBar, hurtLayer;
    public float maxHealth = 100f;
    private float currentHealth;
    private bool onSpike = false, damageCd = false;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update() {
        if(hurtLayer.color.a > 0) {
            var color = hurtLayer.color;
            color.a -= 0.01f;
            hurtLayer.color = color;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        AudioManager.instance.Play("Hurt");

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        var color = hurtLayer.color;
        color.a = 0.7f;
        hurtLayer.color = color;

        if (currentHealth <= 0f)
        {
            // Health is depleted, handle the death or game over logic here
            SceneManager.LoadScene("FailedScene");
        }
    }

    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
    }

    IEnumerator Damage() {
        while(onSpike) {
            damageCd = true;
            TakeDamage(25);
            // var color = hurtLayer.color;
            // color.a = 0.7f;
            yield return new WaitForSeconds(1.5f);
            damageCd = false;
        }
        yield return new WaitForSeconds(1.5f);
        damageCd = false;
        // yield break;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Spike")) {
            // TakeDamage(25);
            onSpike = true;
            if(!damageCd) {
                StartCoroutine(Damage());
            }
            
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.transform.CompareTag("Spike")) {
            // TakeDamage(25);
            onSpike = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Boundary")) {
            TakeDamage(currentHealth);
        }

        if(other.CompareTag("Door")) {
            SceneManager.LoadScene("StageClearScene");
        }
    }
}
