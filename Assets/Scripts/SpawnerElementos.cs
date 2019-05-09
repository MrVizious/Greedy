using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerElementos : MonoBehaviour {

	public float radioBusqueda;
	public int numeroIntentos;
	int finalMask;

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
	[SerializeField]
	private GameObject prefabDefensa;
    [SerializeField]
    private GameObject prefabFruta;
    [SerializeField]
    private GameObject prefabTrampa;

    private void Start() {
		if (radioBusqueda == 0f) {
			radioBusqueda = 0.8f;
		}
		if (prefabCapsula == null) {
			prefabCapsula = (GameObject) Resources.Load("capsula");
		}
		finalMask = 1 << LayerMask.NameToLayer("obstaculo") | 1 << LayerMask.NameToLayer("player") | 1 << LayerMask.NameToLayer("fruta") | 1 << LayerMask.NameToLayer("pickup");

        Invoke("SpawnearCorazon", Random.Range(0, 60));
        Invoke("SpawnearCapsula", Random.Range(0, 60));
        Invoke("SpawnearDefensa", Random.Range(0, 60));
    }

    private void Update() {
        
    }

	/// <summary>
	/// Busca un sitio vacío en el mapa, donde no haga colisión con nada. Hace el número de intentos indicado en el script.
	/// </summary>
	/// <returns>Vector2 con la posición, Vector2.negativeInfinity si no encuentra ninguno.</returns>
	public Vector2 EncontrarSitioVacio() {
        bool posicionEncontrada = false;
        Vector2 posicion;
        do
        {
            posicion = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (Physics2D.OverlapCircle(posicion, radioBusqueda, finalMask) == null)
            {
                posicionEncontrada = true;
            }
        }
        while (!posicionEncontrada);
        return posicion;
    }

	public void SpawnearCorazon() {
        Vector2 posicion = EncontrarSitioVacio();
		Instantiate(prefabCorazon, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
	}

	public void SpawnearDefensa() {
		Vector2 posicion = EncontrarSitioVacio();
        Instantiate(prefabDefensa, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
	}

	public void SpawnearCapsula() {
		Vector2 posicion = EncontrarSitioVacio();
        Instantiate(prefabCapsula, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
	}

    public void GenerarFrutas(int numeroFrutas)
    {
        for(int i=0; i<numeroFrutas; i++)
        {
            Vector2 posicion = EncontrarSitioVacio();
            Instantiate(prefabFruta, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        }
    }

    public void GenerarTrampas(int numeroTrampas)
    {
        for (int i = 0; i < numeroTrampas; i++)
        {
            Vector2 posicion = EncontrarSitioVacio();
            Instantiate(prefabTrampa, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        }
    }

    public void GenerarGuardianes(int numeroGuardianes)
    {
        for(int i=0; i<numeroGuardianes; i++)
        {
            bool posicionEncontrada = false;
            Vector2 posicion;
            do
            {
                posicion = EncontrarSitioVacio();
                if (Physics2D.OverlapCircle(posicion, 8f, 1 << LayerMask.NameToLayer("Player")) == null)
                {
                    posicionEncontrada = true;
                }
            }
            while (!posicionEncontrada);
            Instantiate(prefabGuardian, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        }
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
