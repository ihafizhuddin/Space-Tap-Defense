using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour{
    public GameObject explosion;
    public float speed;
    public Sprite[] image;
    SpriteRenderer rd;
    BoxCollider2D cd;
    // Start is called before the first frame update
    void Start(){
        int spriteIndex = Random.Range(0,image.Length);
        rd = GetComponent<SpriteRenderer>();
        cd = GetComponent<BoxCollider2D>();
        rd.sprite = image[spriteIndex];
        // audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update(){
        // transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnMouseDown(){
        if(GameManager.get.isPause)return;
        GameManager.get.increaseScore();
        AudioManager.ins.playPlaneShooted();
        // audioSource.Play();
        rd.enabled = false;
        cd.enabled = false;
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject,5f);
        Destroy(newExplosion,5f);
        // this.gameObject.SetActive(false);
    }
}
