using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerElementos : MonoBehaviour {

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
	private GameObject prefabDefensa;
    [SerializeField]
    public float radioBusqueda;

    int finalMask;
    FabricaConsumibles fabrica;

    void Awake()
    {
        finalMask = 1 << LayerMask.NameToLayer("obstaculo") | 1 << LayerMask.NameToLayer("player") | 1 << LayerMask.NameToLayer("fruta") | 1 << LayerMask.NameToLayer("pickup");

    }
    private void Start() {
		if (radioBusqueda == 0f) {
			radioBusqueda = 0.8f;
		}

        StartCoroutine(SpawnearElemento(prefabCorazon));
        StartCoroutine(SpawnearElemento(prefabCapsula));
        StartCoroutine(SpawnearElemento(prefabDefensa));
    }

    private void Update() {
        //Para testeo
        if (Input.GetKeyDown(KeyCode.H)) SpawnearCorazon();
        if (Input.GetKeyDown(KeyCode.C)) SpawnearCapsula();
        if (Input.GetKeyDown(KeyCode.G)) SpawnearDefensa();
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

    IEnumerator SpawnearElemento(GameObject prefab)
    {
        yield return new WaitForSeconds(Random.Range(0, 60));
        Vector2 posicion = EncontrarSitioVacio();
        Instantiate(prefab, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
    }

    //Estos métodos serán elimindaos, de momento están para testeo
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
    //Hay que ver que los guardianes no se generen cerca de player
    public void SpawnearElementos(int numeroElementos, GameObject prefab)
    {
        for (int i = 0; i < numeroElementos; i++)
        {
            Vector2 posicion = EncontrarSitioVacio();
            Instantiate(prefab, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        }
    }

    public void SpawnearElementos(int numeroElementos, string consumible)
    {
        for (int i = 0; i < numeroElementos; i++)
        {
            Vector2 posicion = EncontrarSitioVacio();
            GameObject prefab = fabrica.GetConsumible(consumible);
            Instantiate(prefab, posicion, Quaternion.identity, GetComponentInParent<Grid>().gameObject.transform);
        }
    }

    //Hay que ver que no se generen cerca de player
    public void GenerarGuardianes(int numeroGuardianes, GameObject prefabGuardian)
    {
        for(int i=0; i<numeroGuardianes; i++)
        {
            bool posicionEncontrada = false;
            Vector2 posicion;
            do
            {
                posicion = EncontrarSitioVacio();
                if (Physics2D.OverlapCircle(posicion, 100f, 1 << LayerMask.NameToLayer("Player")) == null)
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
