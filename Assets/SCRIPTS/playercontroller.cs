using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float velocidad = 5f;       // Velocidad horizontal
    public float fuerzaSalto = 7f;     // Fuerza del salto
    private Rigidbody2D rb;            // Referencia al Rigidbody2D
    private bool enSuelo;              // Para verificar si está en el suelo

    public Transform chequeoSuelo;     // Punto de chequeo bajo el personaje
    public LayerMask capaSuelo;        // Qué capas cuentan como suelo
    public float radioChequeo = 0.2f;  // Radio del círculo de detección

    public Animator animator;          // Referencia al Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float movimiento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Actualizar parámetro de animación (velocidad absoluta)
        animator.SetFloat("Velocidad", Mathf.Abs(movimiento));

        // Voltear sprite según dirección
        if (movimiento < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (movimiento > 0)
            transform.localScale = new Vector3(1, 1, 1);

        // Verificar si está en el suelo
        enSuelo = Physics2D.OverlapCircle(chequeoSuelo.position, radioChequeo, capaSuelo);

        // Saltar
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetTrigger("Salto"); // Activar animación de salto
        }

        // Actualizar parámetro de suelo
        animator.SetBool("EnSuelo", enSuelo);
    }
}
