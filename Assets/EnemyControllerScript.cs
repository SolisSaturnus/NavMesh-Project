using UnityEngine.AI;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyControllerScript : MonoBehaviour
{

    public NavMeshAgent enemyAgent;

    public GameObject player;

    void Start()
    {
        enemyAgent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        enemyAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            PlayerController.lives--;
        }
    }
}
