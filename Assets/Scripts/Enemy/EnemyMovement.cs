using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        if (enemyHealth.currentHealth <= 0)
			nav.enabled = false;
		else if (playerHealth.currentHealth <= 0)
			nav.enabled = false;
		else if (enemyHealth.currentHealth != enemyHealth.startingHealth) 
			nav.SetDestination (player.position);
		else 
		{
			float x = Random.Range (-34, 34);
			float z = Random.Range (-34, 34);
			nav.SetDestination (new Vector3 (x, 0f, z));
		}
    }
}
