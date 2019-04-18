using UnityEngine;
using UnityEngine.AI;

public class PatrolOfTerritory : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public bool isPatrol;
    GameObject player;

    EnemyHealth enemyHealth;


    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        isPatrol = true;
        agent.speed = 1;
        agent.destination = points[destPoint].position;
        destPoint = Random.Range(0, points.Length);
    }


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player = null)
        {
            Destroy(gameObject);
        }
        if (enemyHealth.isDead == true)
            return;
        else if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
