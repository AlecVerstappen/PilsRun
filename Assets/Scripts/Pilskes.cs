using UnityEngine;
using System.Collections;

public class Pilskes : MonoBehaviour {

    private Controls player;
    public AudioSource bling;

    void Start () {
        player = FindObjectOfType<Controls>();
    }
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bling.Play();
            player.pilskes++;
            Destroy(gameObject);
            
        }
    }
}
