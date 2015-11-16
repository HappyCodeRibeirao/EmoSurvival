using UnityEngine;
using System.Collections;

public class PlayerLighting : MonoBehaviour {
    Transform player;
    public Light light;

    PlayerEmotions playerEmotions;

    void Start ()
    {
        light = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerEmotions = player.GetComponent<PlayerEmotions>();
    }
	
	void Update ()
    {
        if (playerEmotions != null)
            light.range = playerEmotions.currentValence;
    }
}