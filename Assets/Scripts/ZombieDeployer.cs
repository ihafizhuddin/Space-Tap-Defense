using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeployer : MonoBehaviour{

    public Zombie zombiePrefabs;
    public Transform[] spawnTransform;
    public float spawnDuration = 5f;
    private float timer = 5.0f;
    // Start is called before the first frame update
    // void Start(){
        
    // }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        if(timer <=0){
            SpawnZombie();
            timer = Random.Range(1,spawnDuration);
        }
    }

    void SpawnZombie(){
        // float spawnXPos = Random.Range(-5,5);
        if(GameManager.get.score >50){
            int spawnXtime = GameManager.get.score/15;
            int spawned = 0;
            for (int i = 0; i < spawnXtime; i++){
                Transform neoSpawnTransform = spawnTransform[Random.Range(0,spawnTransform.Length)];
                Zombie neoZombie = Instantiate(zombiePrefabs, neoSpawnTransform.position, transform.rotation);
                neoZombie.speed = Random.Range(1,10);
                
            }
        }else{
            
            Transform newSpawnTransform = spawnTransform[Random.Range(0,spawnTransform.Length)];
            // Vector3 spawnPos = transform.position;
            // spawnPos.x = spawnXPos;
            Zombie newZombie = Instantiate(zombiePrefabs, newSpawnTransform.position, transform.rotation);
            newZombie.speed = Random.Range(1,10);
            if(GameManager.get.score >10){
                Transform newSpawnTransform2 = spawnTransform[Random.Range(0,spawnTransform.Length)];
                Zombie newZombie2 = Instantiate(zombiePrefabs, newSpawnTransform2.position, transform.rotation);
                newZombie2.speed = Random.Range(1,8);
            }
            if(GameManager.get.score >25){
                Transform newSpawnTransform3 = spawnTransform[Random.Range(0,spawnTransform.Length)];
                Zombie newZombie3 = Instantiate(zombiePrefabs, newSpawnTransform3.position, transform.rotation);
                newZombie3.speed = Random.Range(1,6);
            }
            if(GameManager.get.score >40){
                Transform newSpawnTransform4 = spawnTransform[Random.Range(0,spawnTransform.Length)];
                Zombie newZombie4 = Instantiate(zombiePrefabs, newSpawnTransform4.position, transform.rotation);
                newZombie4.speed = Random.Range(1,4);
            }
        
        }
        
    }


}
