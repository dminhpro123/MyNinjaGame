using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Totem : MonoBehaviour
{
    public Player player;
    public GateToLvl2 gate;
    
    public int maxHealth = 20, health;
    public bool isAttacking = false;
    Animator anim;
    Rigidbody2D r2;
    Object bulletRef1;
    

    float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r2 = GetComponent<Rigidbody2D>();
        bulletRef1 = Resources.Load("BulletTotem");       
        health = maxHealth;
        nextFire = Time.time;
        gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateToLvl2>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Invoke("ChangeLV", 5f);
            
            KillSelf();
            
        }
        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }
    
    void FixedUpdate() {
        
        if (isAttacking)
        {
            
            
            if(health > maxHealth/2)
            {
                if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef1);
                    bullet.transform.position = new Vector3(r2.transform.position.x - 0.4f, r2.transform.position.y - .2f, -1);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, -1);
                    nextFire = Time.time + 0.75f;
                }
                
            }
        }
    }
   
    private void KillSelf()
    {
        Destroy(this.gameObject);
        
    }

    

    public void Damage(int damage)
    {
        //luong mau mat = damage
        health -= damage;
    }


    
}
