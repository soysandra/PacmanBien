using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public GameObject enemyPrefab;      // Prefab del enemigo
    public Transform[] spawnPoints;     // Array de posiciones donde aparecerán
    public int cantidadEnemigos = 4;    // Número de enemigos a generar

    void Start()
    {
        GenerarEnemigos();
    }

    void GenerarEnemigos()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            // Si hay menos spawnPoints que enemigos, se repiten
            Transform punto = spawnPoints[i % spawnPoints.Length];

            Instantiate(enemyPrefab, punto.position, Quaternion.identity);
        }
    }
}


