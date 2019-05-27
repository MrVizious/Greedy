using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField]
    protected int minX = -9;
    [SerializeField]
    protected int minY = -7;
    [SerializeField]
    protected int maxX = 9;
    [SerializeField]
    protected int maxY = 7;
    [SerializeField]
    protected float radioBusqueda = 0.3f;
    [SerializeField]
    int numeroElementos;


    protected int finalMask;
    protected FabricaConsumibles fabrica;
    protected Vector2 posicion;
    protected GameObject prefab;
    Transform parentTransform;
    void Awake()
    {
        finalMask = 1 << LayerMask.NameToLayer("obstaculo") | 1 << LayerMask.NameToLayer("player") | 1 << LayerMask.NameToLayer("fruta") | 1 << LayerMask.NameToLayer("pickup");
        fabrica = GetComponent<FabricaConsumibles>();
    }

    public virtual void Start()
    {
        GenerarElementos();
    }

    void GenerarElementos()
    {
        ObtenerPosicionParent();
        ObtenerElemento();
        for (int i = 0; i < numeroElementos; i++)
        {
            EncontrarSitioVacio();
            InstanciarElemento();
        }
    }

    public virtual void EncontrarSitioVacio()
    {
        bool posicionEncontrada = false;
        do
        {
            posicion = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (Physics2D.OverlapCircle(posicion, radioBusqueda, finalMask) == null)
            {
                posicionEncontrada = true;
            }
        }
        while (!posicionEncontrada);
    }

    public void InstanciarElemento()
    {
        Instantiate(prefab, posicion, Quaternion.identity, parentTransform);
    }

    public void ObtenerPosicionParent()
    {
        parentTransform = GetComponentInParent<Grid>().gameObject.transform;
    }

    public abstract void ObtenerElemento();
}
