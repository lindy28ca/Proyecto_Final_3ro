using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class GuardPatroller : MonoBehaviour
{
    #region Variables

    public PatrolGraphInitializer graphInitializer;
    public int startNodeIndex = 0;
    public float attackRange = 2f;

    [SerializeField] private List<int> customPath = new List<int>();

    private Animator alex;
    private NavMeshAgent agent;
    private List<int> patrolPath;
    private int currentTargetIndex = 0;

    private StateEnemy state;
    private Transform transformsPlayer;
    [SerializeField] private Collider puño;

    private enum StateEnemy
    {
        Patrol,
        Follow,
        Attack
    }

    #endregion

    #region Unity Methods

    private void Awake()
    {
        alex = GetComponent<Animator>();
    }

    private void Start()
    {
        state = StateEnemy.Patrol;
        agent = GetComponent<NavMeshAgent>();

        if (customPath != null && customPath.Count > 0)
        {
            patrolPath = customPath;
        }
        else
        {
            patrolPath = graphInitializer.graph.BFS(startNodeIndex);
        }

        if (patrolPath.Count > 0)
        {
            GoToNextNode();
        }
    }

    private void Update()
    {
        UpdateState();
    }

    #endregion

    #region Estado Enemigo

    private void UpdateState()
    {
        switch (state)
        {
            case StateEnemy.Patrol:
                alex.SetTrigger("Caminar");

                if (!agent.pathPending && agent.remainingDistance < 0.2f)
                {
                    currentTargetIndex = (currentTargetIndex + 1) % patrolPath.Count;
                    GoToNextNode();
                }
                break;

            case StateEnemy.Follow:
                if (transformsPlayer != null)
                {
                    float distance = Vector3.Distance(transform.position, transformsPlayer.position);

                    LookAtPlayer();

                    if (distance <= attackRange)
                    {
                        state = StateEnemy.Attack;
                    }
                    else
                    {
                        agent.SetDestination(transformsPlayer.position);
                        alex.SetTrigger("Caminar");
                    }
                }
                break;

            case StateEnemy.Attack:
                if (transformsPlayer != null)
                {
                    float distance = Vector3.Distance(transform.position, transformsPlayer.position);

                    LookAtPlayer();

                    if (distance > attackRange)
                    {
                        state = StateEnemy.Follow;
                    }
                    else
                    {
                        agent.ResetPath();
                        alex.SetTrigger("Atacar");
                    }
                }
                break;
        }
    }

    #endregion

    #region Comportamiento

    private void LookAtPlayer()
    {
        Vector3 lookDirection = transformsPlayer.position - transform.position;
        lookDirection.y = 0f;

        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * 5f);
        }
    }

    private void GoToNextNode()
    {
        int nodeId = patrolPath[currentTargetIndex];
        Transform targetTransform = graphInitializer.graph.NodeGraphs[nodeId].Value;
        agent.SetDestination(targetTransform.position);
    }

    public void ActivarPuño()
    {
        puño.enabled = true;
    }

    public void DesactivarPuño()
    {
        puño.enabled = false;
    }

    #endregion

    #region Trigger Events

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transformsPlayer = other.transform;
            state = StateEnemy.Follow;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transformsPlayer = null;
            state = StateEnemy.Patrol;
            GoToNextNode();
        }
    }

    #endregion
}
