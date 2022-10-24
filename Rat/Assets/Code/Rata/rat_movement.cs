using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rat_movement : MonoBehaviour
{
    public rat_holes r_hole;
    public rat_raycast r_cast;
    Rigidbody2D rb_rat;
    public int speed; //Velocidad maxima que puede alcanzar la rata
    public int jumpforce; //La fuerza del salto de la rata
    public float fall; //La velocidad de caida, para que caiga mas rapido que sube
    public float gravity; //Lo que le afecta la gravedad
    public float slowdown; //Numero que se multiplica a la velocidad para realentizarla, varia con la situacion
    public float slowdownjump; //Cuanto se realentiza en el aire
    public float moveAxisX; //El input de izquierda y derecha
    public float moveAxisY; //El input de arriba y abajo
    public float acc_rate; //Cuanto mas alto, mas rapido acelera
    public float decc_rate;  //Cuanto mas alto, mas rapido desacelera
    public float movepow; //La aceleracion se eleva a este numero, para que tarde menos en llegar a velocidades mas altas
    public bool grounded; //Si esta tocando el suelo o no
    public KeyCode jump_key; //La tecla de salto
    public KeyCode action_key; //La tecla de interactuar (cadenas, agujeros)
    public bool visible; //Si la pueden ver los enemigos o no
    public float PressTimeSet; //Cuanto tiempo tiene para saltar desde que se da al boton
    float PressTime;
    public float GroundTimeSet; //Cuanto tiempo tiene para saltar desde que deja de tocar el suelo (coyote time)
    float GroundTime;
    public bool hidden; //Si esta escondida en un agujero o no
    public bool Grabbed; //Si esta agarrada a una cadena
    public bool JustGrabbed; //Sirve para que tengas que volver a darle a alguna tecla para moverte despues de agarrate a una cadena
    public float slopeAngle;
    public bool onSlope;
    public int negativeslope;
    public Vector2 RespawnPoint;
    Vector2 forceangle;
    Animator _anim;
    SpriteRenderer _renderer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            slowdown = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            Die();
        }
        if(collision.gameObject.tag == "End")
        {
            FinishClass.finished = true;
            SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        rb_rat = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        Grabbed = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(jump_key))
        {
            PressTime = PressTimeSet;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            JustGrabbed = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveAxisX = Input.GetAxisRaw("Horizontal");
        moveAxisY = Input.GetAxisRaw("Vertical");
        if(moveAxisX > 0)
        {
            _renderer.flipX = true;
            _anim.SetInteger("Move", 1);
        } else if(moveAxisX < 0)
        {
            _renderer.flipX = false;
            _anim.SetInteger("Move", 1);
        }
        else { 
            _anim.SetInteger("Move", 0);
        }
        if (!hidden)
        {
            float sptrg = speed * moveAxisX;
            float spdf = sptrg - rb_rat.velocity.x;
            float rate = (Mathf.Abs(spdf) > 0.01) ? acc_rate : decc_rate;
            float move = Mathf.Pow(Mathf.Abs(spdf) * rate , movepow) * Mathf.Sign(spdf);
            //float move = spdf * rate;
            forceangle = new Vector2( negativeslope * Mathf.Cos(slopeAngle * Mathf.PI / 180), Mathf.Sin(slopeAngle * Mathf.PI / 180));
            if (moveAxisX > 0 && r_cast.rightwall && !onSlope|| JustGrabbed|| moveAxisX < 0 && r_cast.leftwall && !onSlope)
            {
                print("waka");
            }
            else
            {
                Vector2 daforce = new Vector2(forceangle.x * negativeslope, forceangle.y);
                Debug.DrawRay(transform.position, forceangle, Color.blue);
                rb_rat.AddForce(forceangle * move * slowdown);
            }
            if (r_cast.grounded && rb_rat.velocity.y <= 0.5 || r_cast.grounded && onSlope)
            {
                _anim.SetBool("Jump", false);
                GroundTime = GroundTimeSet;
            }
            if (PressTime > 0 && GroundTime > 0)
            {
                rb_rat.velocity = new Vector2(rb_rat.velocity.x, 0);
                print("jump");
                _anim.SetBool("Jump", true);
                rb_rat.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                slowdown = slowdownjump;
                GroundTime = 0;
                PressTime = 0;
            }
            if (slopeAngle != 0 && negativeslope == 1)
            {
                rb_rat.gravityScale = 0;
                Vector2 normalangle = new Vector2(forceangle.y * negativeslope, -forceangle.x * negativeslope);
                Debug.DrawRay(transform.position, normalangle, Color.green);
                rb_rat.AddForce(normalangle * gravity * 14);
            }
            else
            {
                if (rb_rat.velocity.y < 0)
                {
                    rb_rat.gravityScale = gravity * fall;
                }
                else
                {
                    rb_rat.gravityScale = gravity;
                }
            }
            GroundTime -= Time.deltaTime;
            PressTime -= Time.deltaTime;
        }
        if (Grabbed)
        {
            if (moveAxisY != 0)
            {
                rb_rat.AddForce(Vector2.up * moveAxisY * speed);
            }
            else
            {
                rb_rat.velocity = new Vector2(rb_rat.velocity.x, 0);
            }
        }
        if (onSlope)
        {
           rb_rat.freezeRotation = false;
        }
        else
        {
            rb_rat.freezeRotation = true;
            transform.eulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
    }
    public void Die()
    {
        transform.position = RespawnPoint;
    }
    

}
