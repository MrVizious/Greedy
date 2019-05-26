using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestPlayer
    {
        private GameObject prefabPlayer;
        private GameObject prefabFruta;

        [Test]
        public void ComerFrutaAlPulsarTest()
        {

        }

        [Test]
        public void ComerFruta()
        {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            prefabFruta = (GameObject)Resources.Load("Tests/Fruta");
            GameObject frutaInicializada = Object.Instantiate(prefabFruta, new Vector2(0, 0), Quaternion.identity);
            Comestible frutaTest = frutaInicializada.GetComponent<Comestible>();

            //objetoTest.Start();
            //frutaTest.Start();  ¿¿Por que no funciona?
            objetoTest.caloriasAcumuladas = 100;


        }
    }
}
