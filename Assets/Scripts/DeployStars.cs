using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployStars : Chest
{

    public GameObject starPrefab;
    public float respawnTime = 1.0f;
    public float speed = 10.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
 
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-9, 13);
        StartCoroutine(starWave());
    }

    public void spawnStars()
    {
        GameObject s = Instantiate(starPrefab) as GameObject;
        s.transform.position = new Vector2(-9, 10.5f);
    }

    IEnumerator starWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnStars();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
