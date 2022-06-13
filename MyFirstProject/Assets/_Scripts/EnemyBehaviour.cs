using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class EnemyBehaviour : MonoBehaviour
{
    public Transform patrolRoute;//Objeto vacío en la escena que contiene los waypoints
    [SerializeField] private List<Transform> waypoints;//Lista de waypoints

    private int locationIndex = 0;//Siguiente waypoint al que se dirigirá el enemigo

    private NavMeshAgent _agent;//Agente de navegación

    private Transform player;//Player al que perseguir cuando sea detectado

    //Vida del enemigo
    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }

        private set
        {
            _lives = value;

            if(_lives <= 0)//Cuando el enemigo se quede sin vidas
            {
                Debug.Log("Enemigo eliminado");
                Destroy(gameObject);
            }
        }
    }


    private void Start()
    {
        InitiatizeWayPoints();

        _agent = GetComponent<NavMeshAgent>();

        MoveToNextWaypoint();

        player = GameObject.Find("Player").transform;
    }


    /// <summary>
    /// Inicializa la lista de waypoints con los que existen en la escena
    /// </summary>
    private void InitiatizeWayPoints()
    {
        foreach(Transform wp in patrolRoute)
        {
            waypoints.Add(wp);
        }
    }


    private void MoveToNextWaypoint()
    {
        if (waypoints.Count <= 0)
            return;


        _agent.SetDestination(waypoints[locationIndex].position);//Establece que el enemigo ha de moverse al actual waypoint

        locationIndex = (locationIndex + 1) % waypoints.Count;//Y cambia el waypoint para la siguiente vez que sea llamado
    }

    /// <summary>
    /// Cuando el jugador esté en el área de detección del enemigo le perseguirá utilizando el navmesh agent
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador detectado");
            _agent.SetDestination(player.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador ha escapado");
        }
    }

    /// <summary>
    /// Si una bala colisiona con el enemigo le restará una vida
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemigo alcanzado");
            EnemyLives--;
        }
    }


    private void Update()
    {
        if(_agent.remainingDistance < 0.5f && !_agent.pathPending)//Cuando el agente esté alcanzando su actual destino y mientras tenga una ruta asignada
        {
            MoveToNextWaypoint();
        }
    }

}
