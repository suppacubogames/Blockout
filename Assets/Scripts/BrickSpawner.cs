using UnityEngine;
using System.Collections.Generic;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab; // Prefab for the brick to be spawned
    [SerializeField] private float spacingX;
    [SerializeField] private float spacingY;
    [SerializeField] private int gridYPos;

    [SerializeField] private List<GameObject> bricks; // List to keep track of spawned bricks
    [SerializeField] private LayoutData layoutData;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatedSpawning(); // Call the method to spawn bricks at the start of the game
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Brick"); // Find all bricks in the scene
        bricks.AddRange(gameObjects); // convierte el array de GameObjects en una lista y lo guarda en la variable bricks
    }

    // ============================ RESUMEN RAPIDO (TL;DR) ============================
    // Crea una cuadricula de ladrillos de cantidadX columnas por cantidadY filas.
    // El "for" de afuera (j) = filas.   El "for" de adentro (i) = columnas.
    // La X y la Y solo separan cada ladrillo; el "- mitad" y "+ mitad" del final
    // sirven UNICAMENTE para centrar todo el bloque alrededor del punto (0,0).
    // ================================================================================

    void UpdatedSpawning()
    {
        for (int i = 0; i < layoutData.Grid.Length; i++)
        {
            string fila = layoutData.Grid[i];

            for (int j = 0; j < fila.Length; j++)
            {
                char c = fila[j];
                if (c == '#')
                {
                    Instantiate(brickPrefab, new Vector2((j * spacingX) - ((fila.Length - 1) * spacingX / 2), 
                    (i * -spacingY) + ((layoutData.Grid.Length + gridYPos) * spacingY / 2)), Quaternion.identity);
                }
            }
        }
    }

    public List<GameObject> GetBricks()
    {
        return bricks; // Return the list of spawned bricks
    }
}
