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


    private void Start()
    {
        InitiatizeWayPoints();

        _agent = GetComponent<NavMeshAgent>();

        MoveToNextWaypoint();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador detectado");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Jugador ha escapado");
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
