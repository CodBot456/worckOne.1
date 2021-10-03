using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayeController : MonoBehaviour
{
    public int health = 3;
    bool isLive = true;
    public int maxHealth;
    public List<Image> images;
    public GameObject spawner;
    Rigidbody2D rb; //физическое тело
    Animator animator; //контроллер анимации
    SpriteRenderer spriteRenderer; //для разворота спрайта
    [Header("Движение")] //заголовок в инспекторе
    [SerializeField] float speed = 5f; //скорость движения
    [SerializeField] float jumpDistance = 1.5f; //множитель высоты прыжка
    [SerializeField] Transform legs; //ноги персонажа, для определения касания земли
    [SerializeField] LayerMask maskGround; //название слоя
    public Sprite sprite;
    public Sprite spriteHp;
    bool isDead = false; //флаг потери жизни, для запрета управления
    public bool isJump = false; //флаг для определения прыжка
    public float radiusLegs = 0.10f; //радиус для обнаружения земли
    int score = 0;
    public GameObject s;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //получаем доступк к физике
        animator = gameObject.GetComponent<Animator>(); //получаем доступ к аниматору
        spriteRenderer = GetComponent<SpriteRenderer>(); //получаем доступ к спрайтрендереру
        maxHealth = health;
    }
    private void FixedUpdate()
    {
        //определяем, стоит ли персонаж на земле и передаем результат в метод
        OnGround(!Physics2D.OverlapCircle(legs.position, radiusLegs, maskGround));
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < health; i++)
        {
            images[i].sprite = spriteHp;
        }
        for (int i = health; i < maxHealth; i++)
        {
            images[i].sprite = sprite;
        }
        if(isJump == false)
        {
            animator.SetBool("isJump", false);
        }
        if (!isDead) //управляем пока не потеряли жизнь
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //движение влево
            {
                if (isJump == false)
                {
                    animator.SetBool("isWalk", true);
                }
                else
                {
                    animator.SetBool("isWalk", false);
                }
                rb.velocity = new Vector2(-speed, rb.velocity.y); //задаем ускорение физическому телу
                spriteRenderer.flipX = true; //отобразить по оси X
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //движенеи вправо
            {
                if (isJump == false)
                {
                    animator.SetBool("isWalk", true);
                    print("121");
                }
                else
                {
                    animator.SetBool("isWalk", false);
                }
                rb.velocity = new Vector2(speed,rb.velocity.y); //задаем ускорение физическому телу
                spriteRenderer.flipX = false; //отобразить по оси X - выключить

            }
            if (Input.GetKey(KeyCode.E))  
            {
            
                animator.SetBool("isAttack", true);
            
            }
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) //влево-вправо не двигаемся
            {
                animator.SetBool("isWalk", false);
                rb.velocity = new Vector2(0, rb.velocity.y); //убираем ускорение физического тела
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) //прыжки
            {
                animator.SetBool("isJump", true);
                Jump(jumpDistance); //вызываем метод прыжка и передаем рсстояние
            }
        }
    }
    public void attack()
    {
        animator.SetBool("isAttack", false);
    }
    //метод обработки состояния прыжка
    void OnGround(bool onGround)
    {
        isJump = onGround; //меняем состояние флага
    }
    //метод обработки прыжка
    void Jump(float distance)
    {
        if (!isJump) //если не в прыжке
        {
            rb.velocity = new Vector2(0, 0);//останавливаем движение
            rb.AddForce(Vector2.up * speed * distance, ForceMode2D.Impulse); //прикладывем импульс вверх
        }
    }


 IEnumerator coll() {

        if (isLive == true)
        {
            transform.position = spawner.transform.position + new Vector3(0, spawner.transform.localScale.y + transform.localScale.y, 0);
            health = health - 1;
        }
        isLive = false;
        yield return new WaitForSeconds(1);
        isLive = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "money")
        {
            score++;
            esc e = s.GetComponent<esc>();
            e.updateScore(score);
            Destroy(collision.gameObject);
        }
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
 
        if (collision.gameObject.tag == "Enemy" && isLive == true)
        {
            StartCoroutine(coll());
        }
        if (health == 0)
        {
            SceneManager.LoadScene("mainMenu");
        }

       
        if (collision.gameObject.tag == "bonus")
        {
            if (health < 3)
            {
                health++;
                Destroy(collision.gameObject);
            }
        }
    }
}
