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
    public float radioBusqueda;

    int finalMask;
    FabricaConsumibles fabrica;
    Transform parentTransform;

    void Awake()
    {
        finalMask = 1 << LayerMask.NameToLayer("obstaculo") | 1 << LayerMask.NameToLayer("player") | 1 << LayerMask.NameToLayer("fruta") | 1 << LayerMask.NameToLayer("pickup");

        fabrica = GetComponent<FabricaConsumibles>();
    }
    private void Start() {
        StartCoroutine(SpawnearElemento("corazon"));
        StartCoroutine(SpawnearElemento("capsula"));
        StartCoroutine(SpawnearElemento("defensa"));
        parentTransform = GetComponentInParent<Grid>().gameObject.transform;
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

    IEnumerator SpawnearElemento(string nombre)
    {
        yield return new WaitForSeconds(Random.Range(0, 60));
        Vector2 posicion = EncontrarSitioVacio();
        GameObject prefab = fabrica.GetConsumible(nombre);
        Instantiate(prefab, posicion, Quaternion.identity, parentTransform);
    }

    public void SpawnearElementos(int numeroElementos, string nombre)
    {
        for (int i = 0; i < numeroElementos; i++)
        {
            Vector2 posicion = EncontrarSitioVacio();
            GameObject prefab = fabrica.GetConsumible(nombre);
            Instantiate(prefab, posicion, Quaternion.identity, parentTransform);
        }
    }

    public void GenerarGuardianes(int numeroGuardianes, string nombre)
    {
        for(int i=0; i<numeroGuardianes; i++)
        {
            bool posicionEncontrada = false;
            Vector2 posicion;
            GameObject prefab = fabrica.GetConsumible(nombre);
            do
            {
                posicion = EncontrarSitioVacio();
                if (Physics2D.OverlapCircle(posicion, 5f, 1 << LayerMask.NameToLayer("player")) == null)
                {
                    posicionEncontrada = true;
                }
            }
            while (!posicionEncontrada);
            Instantiate(prefab, posicion, Quaternion.identity, parentTransform);
        }
    }

}
