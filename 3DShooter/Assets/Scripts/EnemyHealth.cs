using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 0.2f;
    public int scoreValue = 10;

    Animator anim;
    private new CapsuleCollider collider;
    public bool isDead;
    public bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)) Destroy(gameObject);
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void Damage(int damageAmount)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= damageAmount;
        Debug.Log("Новое хп врага составляет" + currentHealth);

        if (currentHealth <= 0)
        {
            Death();
            StartSinking();
        }
    }

    void Death()
    {
        isDead = true;
        collider.isTrigger = true;
        anim.SetTrigger("death");
        Cursor.visible = true;
    }

    void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        PlayerVariable.score += scoreValue;
        Destroy(gameObject, 10f);
    }
}
