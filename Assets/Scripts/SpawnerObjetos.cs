using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjetos : MonoBehaviour {

	public float radioBusqueda;
	public int numeroIntentos;

    public bool posicionEncontrada;
    Vector2 vectorCapsula;

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
    public GameObject prefabCapsula;

	private void Start() {
		if (radioBusqueda == 0f) {
			radioBusqueda = 0.8f;
		}
        if (prefabCapsula == null)
        {
            prefabCapsula = (GameObject)Resources.Load("capsula");
        }
        Invoke("SpawnearCapsula", Random.Range(5, 10));
	}

	private void Update() {
		// Esto está por testeo, así que...
		// TODO: Eliminar este update
		if (Input.GetKeyDown(KeyCode.H)) {
			SpawnearCorazon();
		}
        

	}

	/// <summary>
	/// Busca un sitio vacío en el mapa, donde no haga colisión con nada. Hace el número de intentos indicado en el script.
	/// </summary>
	/// <returns>Vector2 con la posición, Vector2.negativeInfinity si no encuentra ninguno.</returns>
	public Vector2 EncontrarSitioVacio() {
		for (int i = 0; i < numeroIntentos; i++) {
			Vector2 returnVector = new Vector2((int) Random.Range(minX, maxX), (int) Random.Range(minY, maxY));
			if (Physics2D.OverlapCircle(returnVector, radioBusqueda) == null) {
				Debug.Log("Posicion encontrada: " + returnVector);
				return returnVector;
			}
		}
		Debug.Log("Posición NO encontrada");
		return Vector2.negativeInfinity;
	}

	/// <summary>
	/// Hace aparecer un corazón en alguna posicion libre del mapa
	/// </summary>
	/// <returns>True o false según si lo consigue instanciar o no.</returns>
	public bool SpawnearCorazon() {
		Vector2 posicion = EncontrarSitioVacio();
		if (posicion != Vector2.negativeInfinity) {

			Instantiate(prefabCorazon, (Vector3) posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
			return true;
		}
		return false;
	}

    public void SpawnearCapsula()
    {
        while (!posicionEncontrada)
        {
            Vector2 vectorCapsula = new Vector2((int)Random.Range(minX, maxX), (int)Random.Range(minY, maxY));
            if (Physics2D.OverlapCircle(vectorCapsula, radioBusqueda) == null)
            {
                Debug.Log("Posicion encontrada: " + vectorCapsula);
                posicionEncontrada = true;
            }
        }
        Instantiate(prefabCapsula, (Vector3)vectorCapsula, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        //prefabCapsula.transform.position = vectorCapsula;
        //Instantiate(prefabCapsula, GetComponentInParent<Grid>().gameObject.transform, false);
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
