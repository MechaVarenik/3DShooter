using UnityEngine;

public class Gathering : MonoBehaviour
{
    public int healthGain = 20;
    public int ammoGain = 10;
    public Animator anim;
    GameObject player;


    public PlayerHealth playerHealth;
    private PlayerShoot playerShoot;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerShoot = GetComponent<PlayerShoot>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("Вы подобрали патроны");
            PlayerVariable.totalAmmo[PlayerVariable.selectedWeapon] += ammoGain;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Heal"))
        {
            Debug.Log("Вы подобрали хилку");
            PlayerVariable.currentHealth = Mathf.Clamp(PlayerVariable.currentHealth + healthGain, 0, PlayerVariable.maxHealth);
            playerHealth.healthSlider.value = PlayerVariable.currentHealth;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Win"))
        {
           
            Debug.Log("Вы победили");
            anim.SetTrigger("win");
            Cursor.visible = true;
        }
    }
}

