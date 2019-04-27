using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerElementos : MonoBehaviour {

	public float radioBusqueda;
	public int numeroIntentos;

	[SerializeField]
	private int minX;
	[SerializeField]
	private int minY;
	[SerializeField]
	private int maxX;
	[SerializeField]
	private int maxY;


	[SerializeField]
	private GameObject prefabCorazon;
	[SerializeField]
	private GameObject prefabCapsula;
	[SerializeField]
	private GameObject prefabGuardian;

	private void Start() {
		if (radioBusqueda == 0f) {
			radioBusqueda = 0.8f;
		}
		if (prefabCapsula == null) {
			prefabCapsula = (GameObject) Resources.Load("capsula");
		}
	}

	private void Update() {
		// Esto está por testeo, así que...
		// TODO: Eliminar este update
		if (Input.GetKeyDown(KeyCode.H)) {
			SpawnearCorazon();
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			SpawnearGuardian();
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			SpawnearCapsula();
		}


	}

	/// <summary>
	/// Busca un sitio vacío en el mapa, donde no haga colisión con nada. Hace el número de intentos indicado en el script.
	/// </summary>
	/// <returns>Vector2 con la posición, Vector2.negativeInfinity si no encuentra ninguno.</returns>
	public Vector2 EncontrarSitioVacio() {
		for (int i = 0; i < numeroIntentos; i++) {
			Vector2 returnVector = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
			if (Physics2D.OverlapCircle(returnVector, radioBusqueda) == null) {
				Debug.Log("Posicion encontrada: " + returnVector);
				return returnVector;
			}
		}
		Debug.Log("Posición NO encontrada");
		return Vector2.negativeInfinity;
	}

    /// <summary>
    /// Hace aparecer un corazón en alguna posición libre del mapa
    /// </summary>
    /// <returns>True o false según si lo consigue instanciar o no.</returns>
    /*public bool SpawnearCorazon() {
		Vector2 posicion = EncontrarSitioVacio();
		if (posicion != Vector2.negativeInfinity) {

			Instantiate(prefabCorazon, (Vector3) posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
			return true;
		}
		return false;
	}*/

    public void SpawnearCorazon() {
        bool posicionEncontrada = false;
        Vector2 posicion;
        do
        {
            posicion = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (Physics2D.OverlapCircle(posicion, radioBusqueda) == null)
            {
                Debug.Log("Posicion encontrada: " + posicion);
                posicionEncontrada = true;
            }
        }
        while (!posicionEncontrada);
        Instantiate(prefabCorazon, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
    }



    /// <summary>
    /// Hace aparecer un guardián en alguna posición libre del mapa
    /// </summary>
    /// <returns>True o false según si lo consigue instanciar o no.</returns>
    public bool SpawnearGuardian() {
		Vector2 posicion = EncontrarSitioVacio();
		if (posicion != Vector2.negativeInfinity) {

			Instantiate(prefabGuardian, (Vector3) posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Hace aparecer una cápsula en alguna posición libre del mapa
	/// </summary>
	/// <returns>True o false según si la consigue instanciar o no.</returns>
	public bool SpawnearCapsula() {
		Vector2 posicion = EncontrarSitioVacio();
		if (posicion != Vector2.negativeInfinity) {

			Instantiate(prefabCapsula, (Vector3) posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
			return true;
		}
		return false;
	}


	public int getMinX() {
		return this.minX;
	}

	public void setMinX(int minX) {
		this.minX = minX;
	}

	public int getMinY() {
		return this.minY;
	}

	public void setMinY(int minY) {
		this.minY = minY;
	}

	public int getMaxX() {
		return this.maxX;
	}

	public void setMaxX(int maxX) {
		this.maxX = maxX;
	}

	public int getMaxY() {
		return this.maxY;
	}

	public void setMaxY(int maxY) {
		this.maxY = maxY;
	}
}
