using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Sprite spriteW;
    public Sprite spriteA;
    public Sprite spriteS;
    public Sprite spriteD;

    private SpriteRenderer spriteRenderer;
    private Rigidbody rb;
    public float velocidad = 5f;
    public float fuerzaDeSalto = 7f;
    public float gravedadAdicional = 10f;
    private bool estaEnElSuelo = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Vector3 movimiento = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movimiento += Vector3.forward;
            spriteRenderer.sprite = spriteW;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimiento += Vector3.left;
            spriteRenderer.sprite = spriteA;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimiento += Vector3.back;
            spriteRenderer.sprite = spriteS;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimiento += Vector3.right;
            spriteRenderer.sprite = spriteD;
        }

        movimiento.Normalize();
        movimiento *= velocidad;

        if (estaEnElSuelo)
        {
            Vector3 nuevoMovimiento = new Vector3(movimiento.x, rb.velocity.y, movimiento.z);
            rb.velocity = Vector3.Lerp(rb.velocity, nuevoMovimiento, Time.deltaTime * 10f);
        }
        else
        {
            rb.velocity = new Vector3(movimiento.x, rb.velocity.y, movimiento.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && estaEnElSuelo)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            estaEnElSuelo = false;
        }
    }

    private void FixedUpdate()
    {
        if (!estaEnElSuelo)
        {
            rb.AddForce(Vector3.down * gravedadAdicional, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Plane"))
        {
            estaEnElSuelo = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recolectable"))
        {

            Debug.Log("Objeto ingresó al triggerhnmshgmsg.");
            ContadorMonedas coinCounter = FindObjectOfType<ContadorMonedas>();
            if (coinCounter != null)
            {
                Debug.Log("Monedaaaaaaaaa");
                coinCounter.CollectCoin();
            }
            Debug.Log("absorcioooon");
            Destroy(other.gameObject);
        }
    }
}






