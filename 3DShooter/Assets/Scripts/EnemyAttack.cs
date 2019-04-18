using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform weapon;
    Animator anim;
    NavMeshAgent agent;
    GameObject player;
    public Transform sphere;
    PlayerHealth playerHealth = null;
    public ParticleSystem muzzleFlash;
    private PatrolOfTerritory patrolOfTerritory;
    
    public float timeBetweenShoots = 7f;
    public int attackDamage = 10;
    public float angleV = 120f;
    public float visible = 100f;
    public float shootDistance = 30.0f;
    public float enemySpeed = 3.0f;
    public float fireRate = 1.0f;
    private float fireDelay  = 0.0f;
    public float distance;
    private bool isShoot ;
    private bool isFollow;
    private bool isCheck;
    private float timer;
    private float enemyRotateSpeed = 120;
    private bool isActive = false;

    [Range(0.0f, 1.0f)]
    public float attackProbability = 0.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        patrolOfTerritory = GetComponent<PatrolOfTerritory>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.DrawRay(weapon.position, weapon.forward * 10f);
            Debug.DrawRay(sphere.position, player.transform.position - sphere.position);
            Animation();
            if (patrolOfTerritory.isPatrol == false)
            {
                RotationOfTheEnemy();
            }
            if (isActive || (isActive = AngleOfView() && CollidersCheck(sphere, player, visible)))
            {
                if (distance <= shootDistance && CollidersCheck(sphere, player, visible))
                {
                    patrolOfTerritory.isPatrol = false;
                    isFollow = false;
                    isShoot = true;
                    agent.speed = 0;
                    Fire();
                }
                else
                {
                    patrolOfTerritory.isPatrol = false;
                    isShoot = false;
                    isFollow = true;
                    Follow();
                    agent.speed = 3;
                }

            }
        }
    }

    public void Fire()
    {
        if (CollidersCheck(weapon, player, shootDistance))
        {
            Debug.Log("Рейкаст прошел");
            Quaternion look = Quaternion.LookRotation(player.transform.position - weapon.position);
            if (fireDelay >= fireRate)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - attackProbability))
                {                  
                    muzzleFlash.Play();
                    playerHealth.TakeDamage(attackDamage);
                    Debug.Log("Здоровье игрока: " + PlayerVariable.currentHealth);
                }
                fireDelay = 0;
            }
            else fireDelay += Time.deltaTime;
        }
    }
    public bool AngleOfView()
    {
        if (distance < visible)
        {
           // Debug.Log("Вы в зоне видимости");
            Quaternion look = Quaternion.LookRotation(player.transform.position - transform.position);
            float angle = Quaternion.Angle(transform.rotation, look);
            if (angle < angleV)
            {
               // Debug.Log("Угол подходящий");
                return true;
            }
        }
        return false;
    }

    public bool CollidersCheck(Transform from, GameObject to, float distance)
    {
        RaycastHit hit;
        Ray ray = new Ray(from.position, to.transform.position - from.position);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.transform.gameObject == to)
            {
               // Debug.Log("Враг должен приблизиться2");
                return true;
            }
        }
        return false;
    }

    public void Follow()
    {
        if (GetComponent<NavMeshAgent>().enabled == true)
        {
            agent.destination = player.transform.position;

        }
    }

    public void Animation()
    {
        if (patrolOfTerritory.isPatrol)
        {
            anim.SetBool("walk", true);
        }
        if (isFollow)
        {
            anim.SetBool("run", true);
        }
        else anim.SetBool("run", false);
        if (isShoot)
        {
            anim.SetBool("shoot", true);
        }
        else anim.SetBool("shoot", false);
    }

    public void RotationOfTheEnemy()
    {
        Quaternion look = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, look, enemyRotateSpeed * Time.deltaTime);
    }
}
