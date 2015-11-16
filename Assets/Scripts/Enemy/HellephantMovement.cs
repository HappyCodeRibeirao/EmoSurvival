using UnityEngine;

public class HellephantMovement : MonoBehaviour
{
    public AudioClip smellsFearClip;

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    AudioSource enemyAudio;
    NavMeshAgent nav;
    PlayerEmotions playerEmotions;
    bool isAttacking;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyAudio = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
        playerEmotions = player.GetComponent<PlayerEmotions>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (enemyHealth.currentHealth <= 0)
            nav.enabled = false;
        else if (playerHealth.currentHealth <= 0)
            nav.enabled = false;
        else if (playerEmotions != null && playerEmotions.currentFear > 5)
        {
            nav.SetDestination(player.position);
            isAttacking = true;
            enemyAudio.clip = smellsFearClip;
            enemyAudio.Play();
        }
        else if (isAttacking)
            nav.SetDestination(player.position);
        else if (enemyHealth.currentHealth != enemyHealth.startingHealth)
        {
            isAttacking = true;
            nav.SetDestination(player.position);
        }
        else if (playerEmotions != null && playerEmotions.currentContempt > 20)
        {
            nav.SetDestination(player.position);
            isAttacking = true;
        }
        else if (playerEmotions != null && playerEmotions.currentAnger > 20)
        {
            nav.SetDestination(player.position);
            isAttacking = true;
        }
        else if (playerEmotions != null && playerEmotions.currentDisgust > 20)
        {
            nav.SetDestination(player.position);
            isAttacking = true;
        }
        else
        {
            float x = Random.Range(-34, 34);
            float z = Random.Range(-34, 34);
            nav.SetDestination(new Vector3(x, 0f, z));
        }
    }
}
