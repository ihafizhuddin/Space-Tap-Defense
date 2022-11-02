using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDetector : MonoBehaviour{
    AudioSource audios;
    // // Start is called before the first frame update
    void Start(){
        audios = GetComponent<AudioSource>();        
    }

    // // Update is called once per frame
    // void Update(){
        
    // }
    void OnTriggerExit2D(Collider2D col){
        audios.Play();
        Destroy(col.gameObject);
        GameManager.get.zombieAttack();
    }
}
