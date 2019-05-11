using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeDaño : MonoBehaviour
{

    private GameManager gameManager;
    public Image danyoImage;
    float danyo, maxDanyo = 100f;

    // Start is called before the first frame update
    void Start()
    {
        danyo = 0f;
    }


    public void RecibirDaño(float cantidad)
    {
        danyo = Mathf.Clamp(danyo - cantidad, 0f, maxDanyo);
        danyoImage.transform.localScale = new Vector2(danyo / maxDanyo, 1);

        //player.dañoAcumulado += daño;
        //if (player.dañoAcumulado >= 100)
        //{
        //    player.dañoAcumulado = 0;
        //}
    }
}
