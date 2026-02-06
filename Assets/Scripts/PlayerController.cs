using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private InputAction moveAction;
    private Rigidbody2D rb;
    public TMP_Text textoScore;
    public int puntuacion = 173;
    public GameObject panelVictoria;
    public GameObject panelDerrota;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(input.x * speed, input.y * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto tiene la etiqueta "Enemigo"
        if (other.CompareTag("Enemigo"))
        {
            Derrota();
            return;
        }

        // Si NO es enemigo, asumimos que es un punto
        Destroy(other.gameObject);
        puntuacion--;
        textoScore.text = "Points: " + puntuacion;
        Victoria();
    }

    void Derrota()
    {
        Time.timeScale = 0;
        panelDerrota.SetActive(true);
    }


    void Victoria()
    {
        if (puntuacion <= 0)
        {
            Time.timeScale = 0;
            panelVictoria.SetActive(true);
        }
    }
    public void RecargarEscena()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
