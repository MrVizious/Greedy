using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	[SerializeField]
	public float runSpeed;
	[SerializeField]
	[RangeAttribute(0f, 1f)]
	public float anguloRaycast;
	public Vector3 posicionObjetivo;
	public Vector3 direccion;
	public int capasDeColision;
    public bool arriba, abajo, derecha, izquierda;
    public PlayerController player;
    private SonidosController controladorSonido;
    public Animator animacionActual;

    public RuntimeAnimatorController GreedyUp;
    public RuntimeAnimatorController GreedyDown;
    public RuntimeAnimatorController GreedyLeft;
    public RuntimeAnimatorController GreedyRight;

    public RuntimeAnimatorController GreedyIddleUp;
    public RuntimeAnimatorController GreedyIddleDown;
    public RuntimeAnimatorController GreedyIddleLeft;
    public RuntimeAnimatorController GreedyIddleRight;


    public void Start() {
        animacionActual = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
		capasDeColision = 1 << LayerMask.NameToLayer("obstaculo");
		posicionObjetivo = transform.position;
        arriba = abajo = derecha = izquierda = false;
        if (runSpeed == 0f) runSpeed = 5f;
		if (anguloRaycast == 0) anguloRaycast = 0.35f;
        controladorSonido = GameObject.Find("AudioSonidos").GetComponent<SonidosController>();
    }

    void Update()
    {
        if (arriba)
        {
            direccion = Vector2.up;
            animacionActual.runtimeAnimatorController = GreedyUp;
            SetRumbo(direccion);
            if (ChocaConLimite(direccion))
            {
                controladorSonido.ActivarSonidoLimites();
            }
            else controladorSonido.ActivarSonidoMover();
        }
        else if (abajo)
        {
            direccion = Vector2.down;
            animacionActual.runtimeAnimatorController = GreedyDown;
            SetRumbo(direccion);
            if (ChocaConLimite(direccion))
            {
                controladorSonido.ActivarSonidoLimites();
            }
            else controladorSonido.ActivarSonidoMover();
        }
        else if (derecha)
        {
            direccion = Vector2.right;
            animacionActual.runtimeAnimatorController = GreedyRight;
            SetRumbo(direccion);
            if (ChocaConLimite(direccion))
            {
                controladorSonido.ActivarSonidoLimites();
            }
            else controladorSonido.ActivarSonidoMover();
        }
        else if (izquierda)
        {
            direccion = Vector2.left;
            animacionActual.runtimeAnimatorController = GreedyLeft;
            SetRumbo(direccion);
            if (ChocaConLimite(direccion))
            {
                controladorSonido.ActivarSonidoLimites();
            }
            else controladorSonido.ActivarSonidoMover();
        }

        if (EstaEnObjetivo())
        {
            if (animacionActual.runtimeAnimatorController == GreedyUp)
            {
                animacionActual.runtimeAnimatorController = GreedyIddleUp;
            }
            else if (animacionActual.runtimeAnimatorController == GreedyDown)
            {
                animacionActual.runtimeAnimatorController = GreedyIddleDown;
            }
            else if (animacionActual.runtimeAnimatorController == GreedyRight)
            {
                animacionActual.runtimeAnimatorController = GreedyIddleRight;
            }
            else if (animacionActual.runtimeAnimatorController == GreedyLeft)
            {
                animacionActual.runtimeAnimatorController = GreedyIddleLeft;
            }
        }

        arriba = false;
        abajo = false;
        derecha = false;
        izquierda = false;
    }

	public void FixedUpdate() {
		Move();

	}

	public void Move() {
		transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, Time.deltaTime * runSpeed);

	}


	void IddleAnimation() {
		if (arriba) {
			player.GetComponent<Animator>().runtimeAnimatorController = GreedyIddleUp;
		}
		if (abajo) {
			player.GetComponent<Animator>().runtimeAnimatorController = GreedyIddleDown;
		} else if (derecha) {
			player.GetComponent<Animator>().runtimeAnimatorController = GreedyIddleRight;
		} else if (izquierda) {
			player.GetComponent<Animator>().runtimeAnimatorController = GreedyIddleLeft;
		}
	}


	/// <summary>
	/// Este método se encarga de comprobar con 3 raycasts que se pueda avanzar en una determinada dirección
	/// </summary>
	/// <param name="direccion">Vector2.up, down, left o right</param>
	/// <returns>True si no hay colisión con obstáculo, false si la hay y por tanto no se puede avanzar</returns>
	public bool PuedeAvanzar(Vector3 direccion) {
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, direccion, 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, direccion, Color.blue, 1.2f);
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? -anguloRaycast : direccion.x, direccion.y == 0 ? -anguloRaycast : direccion.y), 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, new Vector2(direccion.x == 0 ? -anguloRaycast : direccion.x, direccion.y == 0 ? -anguloRaycast : direccion.y), Color.red, 1.2f);
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? anguloRaycast : direccion.x, direccion.y == 0 ? anguloRaycast : direccion.y), 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, new Vector2(direccion.x == 0 ? anguloRaycast : direccion.x, direccion.y == 0 ? anguloRaycast : direccion.y), Color.green, 1.2f);

		if ((hit1.collider != null && (hit1.collider.tag.Equals("obstaculo") || hit1.collider.tag.Equals("limite"))) ||
			(hit2.collider != null && (hit2.collider.tag.Equals("obstaculo") || hit2.collider.tag.Equals("limite"))) ||
			(hit3.collider != null && (hit3.collider.tag.Equals("obstaculo") || hit3.collider.tag.Equals("limite")))) {


			return false;
		}
		return true;

	}


	public bool ChocaConLimite(Vector3 direccion) {
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, direccion, 1.2f, capasDeColision);
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? -anguloRaycast : direccion.x, direccion.y == 0 ? -anguloRaycast : direccion.y), 1.2f, capasDeColision);
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? anguloRaycast : direccion.x, direccion.y == 0 ? anguloRaycast : direccion.y), 1.2f, capasDeColision);

		if ((hit1.collider != null && hit1.collider.tag.Equals("limite")) ||
			(hit2.collider != null && hit2.collider.tag.Equals("limite")) ||
			(hit3.collider != null && hit3.collider.tag.Equals("limite"))) {
			return true;
		}
		return false;
	}


	/// <summary>
	/// Comprueba que en la dirección en la que se quiere mover no haya ningún obstáculo, y si es así, cambia el rumbo a esa casilla
	/// </summary>
	/// <param name="direccion">Vector2.up, down, right o left</param>
	public void SetRumbo(Vector2 direccion){
		if (Vector2.Distance(transform.position, posicionObjetivo) <= 0.1 && PuedeAvanzar(direccion)) {
			//TODO: Comprobar que está a poca distancia de su goal para poder meter otro input
			posicionObjetivo = new Vector2(Mathf.Round(transform.position.x + direccion.x),
				Mathf.Round(transform.position.y + direccion.y));
		}
	}

	public bool EstaEnObjetivo() {
		return Vector2.Distance(transform.position, posicionObjetivo) <= 0.05f;
	}

    public void SetIzquierdaTrue()
    {
        izquierda = true;
    }
    public void SetDerechaTrue()
    {
        derecha = true;
    }
    public void SetArribaTrue()
    {
        arriba = true;
    }
    public void SetAbajoTrue()
    {
        abajo = true;
    }
}
