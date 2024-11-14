using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    Animator anim;
    public GameObject Pause;
    public GameObject Skor;

    public GameObject Projectile; // object peluru
    public Vector2 projectileVelocity; // kecepatan peluru
    public Vector2 projectileOffset; // jarak posisi peluru dari posisi pla yer
    public float cooldown = 0.5f; // jeda waktu untuk menembak
    bool isCanShoot = true; // memastikan untuk kapan dapat menembak

    void Start()
    {
        anim = GetComponent<Animator>();
        isCanShoot = false;
        Pause.SetActive(false);
        Skor.SetActive(false);
        EnemyController.EnemyKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }
        Move();
        Dead();

        if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        //nyentuh tanah
        if (isJump)
        {
            anim.ResetTrigger("jump");
            if (idMove == 0) anim.SetTrigger("idle");
            isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Peluru"))
        {
            isCanShoot = true;
        }
        if (collision.transform.tag.Equals("Enemy"))
        {
            SceneManager.LoadScene("Game Over");
            isDead = true;
            Debug.Log("DED");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // nyentuh tanah
        anim.SetTrigger("jump");
        anim.SetTrigger("run");
        anim.SetTrigger("idle");
        isJump = true;
    }

    public void MoveRight()
    {
        idMove = 1;
    }

    public void MoveLeft()
    {
        idMove = 2;
    }

    private void Move()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan 83.
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            if (!isJump) anim.SetTrigger("run");
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat 
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bum"))
        {
            isDead = true;
            SceneManager.LoadScene("Game Over");
        }
        
        if (collision.transform.tag.Equals("Kacang"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Ayam"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Kecap"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Gula"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Cabe"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Ikan"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Belimbing"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Jahe"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Kunyit"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Kemiri"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Kemangi"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Garam"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Sapi"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("BPutih"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("BMerah"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag.Equals("Kelapa"))
        {
            Data.score += 1;
            Destroy(collision.gameObject);
        }

        ////////////////////////////////////////////////////////////////////
        if (collision.CompareTag("Kacang"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Ayam"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }        
        if (collision.CompareTag("Cabe"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }    
        if (collision.CompareTag("Kecap"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Gula"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Ikan"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Belimbing"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Jahe"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Kunyit"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Kemiri"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Kemangi"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Garam"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Sapi"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("BMerah"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("BPutih"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Kelapa"))
        {
            // Asumsikan item di-attach ke Collider sebagai komponen
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Inventory.Instance.AddItem(item.itemType, item.amount);
                Destroy(collision.gameObject);
            }
        }
    }

    public void Idle()
    {
        // kondisi ketika idle/diam 
        if (!isJump)
        {
            anim.ResetTrigger("jump");
            anim.ResetTrigger("run");
            anim.SetTrigger("idle");
        }
        idMove = 0;
    }

    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -6f)
            {
                // kondisi ketika jatuh 
                isDead = true;
                SceneManager.LoadScene("Game Over");
            }

            

        }
    }

    void PlayerControllerOnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bum"))
        {
            isDead = true;
            SceneManager.LoadScene("Game Over");
        }
    }

    void Fire()
    {
        if (isCanShoot)
        {
            //buat projectile baru
            GameObject bullet = Instantiate(Projectile, 
                (Vector2)transform.position - projectileOffset * transform.localScale.x, 
                Quaternion.identity);

            //kecepatan projectile
            Vector2 velocity = new Vector2(projectileVelocity.x * transform.localScale.x, projectileVelocity.y);
            bullet.GetComponent<Rigidbody2D>().velocity = velocity * -1;

            //scale projectile
            Vector3 scale = transform.localScale;
            bullet.transform.localScale = scale * -1;

            StartCoroutine(CanShoot());
            anim.ResetTrigger("shoot");

        }
    }

    IEnumerator CanShoot()
    {
        //anim.ResetTrigger("shoot");
        isCanShoot = false;
        yield return new WaitForSeconds(cooldown);
        anim.ResetTrigger("shoot");
        isCanShoot = true;

    }

   public void Continuu()
    {
        Time.timeScale = 1.0f;
        Pause.SetActive(false);
    }



    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Bakar()
    {
        SceneManager.LoadScene("Baka");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Level2()
    {
        SceneManager.LoadScene("GameplayLevel2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("GameplayLevel3");
    }
}

