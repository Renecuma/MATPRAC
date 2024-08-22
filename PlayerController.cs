using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Pohyb
    public float speed;
    public float jump;
    float moveVelocity;
    private bool isFacingRight = true;
    private float horizontal;
    public GameObject Press;
    bool grounded = false;
    int jumpsRemaining = 2;  // počet povolených skoků
    public GameObject NPC;

    void Update()
    {
        // Skok
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) && (grounded || jumpsRemaining > 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);

            jumpsRemaining--;

            grounded = false;
        }

        moveVelocity = 0;

        // Pohyb vpravo / vlevo
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        // Otočit postavu
        horizontal = Input.GetAxis("Horizontal");
        Flip();
    }

    // Metoda volaná při zůstávání v kolizním objektu
    void OnTriggerStay2D(Collider2D col)
    {   
        // Zobrazení indikátoru pro interakci, pokud hráč stojí u interaktivního objektu
        if (col.gameObject.tag == "Interactable")
        {
            Press.SetActive(true);

            // Interakce po stisku klávesy E
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Test");
                col.gameObject.GetComponent<InteractableObject>().Interact();
            }
        }
    }

    // Metoda volaná při opuštění kolizního objektu
    void OnTriggerExit2D(Collider2D col)
    {
        // Skrytí indikátoru po opuštění interaktivního objektu
        if (Press == null)
        {
            return;
        }
        if (col.gameObject.tag == "Interactable")
        {
            Press.SetActive(false);
        }
    }

    // Kontrola, zda je postava na zemi
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;

            // Resetování počtu povolených skoků při dotyku s povrchem
            jumpsRemaining = 2;
        }
    }

    // Kontrola, zda postava opustila povrch
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    // Metoda pro otočení postavy
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Metoda volaná při vstupu do triggeru
    void OnTriggerEnter2D(Collider2D col)
    {
        // Pokud hráč vstoupí do triggeru s tagem "NPC"
        if (col.gameObject.tag == "NPC")
        {
            // Nastaví referenci na NPC pro možné interakce
            NPC = col.gameObject;

            // Získá komponentu DialogueManager z objektu NPC a spustí dialog
            DialogueManager npcText = col.gameObject.GetComponent<DialogueManager>();
            npcText.StartDialogue(npcText.dialogue);
        }
    }
}
