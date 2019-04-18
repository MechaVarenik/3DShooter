using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    GameObject player;
    public Animator anim;

    bool damaged;
    public static bool playerIsDead;

    void Start()
    {
        healthSlider.value = PlayerVariable.currentHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        //currentHealth = maxPlayerHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        PlayerVariable.currentHealth -= amount;
        healthSlider.value = PlayerVariable.currentHealth;
        
        if(PlayerVariable.currentHealth <= 0 && playerIsDead != true)
        {
            Death();
        }
    }

    void Death()
    {
        anim.SetTrigger("lose");
       // Destroy(gameObject);
        playerIsDead = true; 
    }
}
