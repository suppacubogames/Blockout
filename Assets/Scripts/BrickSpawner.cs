using UnityEngine;
using System.Collections.Generic;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab; // Prefab for the brick to be spawned
    [SerializeField] private float spacingX;
    [SerializeField] private float spacingY;
    [SerializeField] private int cantidadX; // Number of bricks to spawn in a row
    [SerializeField] private int cantidadY; // Number of bricks to spawn in a column

    [SerializeField] private List<GameObject> bricks; // List to keep track of spawned bricks


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBricks(); // Call the method to spawn bricks at the start of the game
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Brick"); // Find all bricks in the scene
        bricks.AddRange(gameObjects); // convierte el array de GameObjects en una lista y lo guarda en la variable bricks
    }

    // ============================ RESUMEN RAPIDO (TL;DR) ============================
    // Crea una cuadricula de ladrillos de cantidadX columnas por cantidadY filas.
    // El "for" de afuera (j) = filas.   El "for" de adentro (i) = columnas.
    // La X y la Y solo separan cada ladrillo; el "- mitad" y "+ mitad" del final
    // sirven UNICAMENTE para centrar todo el bloque alrededor del punto (0,0).
    // ================================================================================
    void SpawnBricks()
    {
        // Este "for" cuenta las FILAS (las hileras de arriba hacia abajo).
        // "j" es el numero de la fila en la que estamos.
        // Empieza en 0 y sube de 1 en 1 hasta llegar a "cantidadY".
        // Si cantidadY es 3, entonces j vale: 0, luego 1, luego 2. (3 filas)
        for (int j = 0; j < cantidadY; j++)
        {

            // Este "for" de adentro cuenta las COLUMNAS (los ladrillos de izquierda a derecha)
            // dentro de UNA sola fila.
            // "i" es el numero de la columna en la que estamos.
            // Empieza en 0 y sube de 1 en 1 hasta llegar a "cantidadX".
            // Si cantidadX es 5, entonces i vale: 0,1,2,3,4. (5 ladrillos en la fila)
            //
            // IMPORTANTE: este "for" de adentro se ejecuta COMPLETO por cada vuelta del "for" de afuera.
            // O sea: pone toda la fila 0 entera, luego toda la fila 1 entera, luego toda la fila 2 entera.
            for (int i = 0; i < cantidadX; i++)
            {
                // Aqui se CREA un ladrillo (Instantiate = "fabricar una copia del prefab").
                // El segundo dato (el Vector2) es la POSICION donde aparece el ladrillo: (x, y).
                // Quaternion.identity solo significa "sin rotacion" (el ladrillo aparece derecho).

                // ----- CALCULO DE LA X (posicion horizontal: izquierda <-> derecha) -----
                // (i * spacingX)  -> separa cada ladrillo del anterior.
                //                    spacingX es el espacio entre ladrillos.
                //                    columna 0 -> 0 ;  columna 1 -> 1 espacio ;  columna 2 -> 2 espacios ...
                //
                // - ((cantidadX - 1) * spacingX / 2)  -> esto es para CENTRAR la fila.
                //                    Sin esto, los ladrillos empezarian en el centro y se irian solo hacia la derecha.
                //                    Esta resta corre toda la fila hacia la izquierda justo la mitad de su ancho,
                //                    asi queda centrada respecto al punto 0.

                // ----- CALCULO DE LA Y (posicion vertical: abajo <-> arriba) -----
                // (j * spacingY)  -> sube cada fila respecto a la anterior.
                //                    spacingY es el espacio entre filas.
                //                    fila 0 -> 0 ;  fila 1 -> 1 espacio mas arriba ;  fila 2 -> 2 espacios ...
                //
                // + ((cantidadY - 1) * spacingY / 2)  -> empuja TODAS las filas hacia arriba,
                //                    la mitad del alto total, para que el bloque quede mas arriba en la pantalla.
                Instantiate(brickPrefab, new Vector2((i * spacingX) - ((cantidadX - 1) * spacingX / 2),
                (j * spacingY) + ((cantidadY - 1) * spacingY / 2)), Quaternion.identity);
            }
        }
    }
}
