using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestAccionesNormal
    {
        private GameObject prefabPlayer;

        [Test]
        public void RecibirDañoTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            //objetoTest.Start();
            Assert.AreEqual(0, objetoTest.dañoAcumulado);
            objetoTest.RecibirDaño(30);
            Assert.AreEqual(30, objetoTest.dañoAcumulado);
        }

        [Test]
        public void ReducirDañoTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            //objetoTest.Start();
            Assert.AreEqual(100, objetoTest.caloriasParaReducir);
            Assert.AreEqual(0, objetoTest.caloriasAcumuladas);
            Assert.AreEqual(0, objetoTest.dañoAcumulado);
            Assert.AreEqual(10, objetoTest.reduccionPorCalorias);


            objetoTest.caloriasAcumuladas = 150;
            objetoTest.dañoAcumulado = 60;
            objetoTest.ReducirDaño();

            Assert.AreEqual(50, objetoTest.dañoAcumulado);
            Assert.AreEqual(50, objetoTest.caloriasAcumuladas);

            objetoTest.caloriasAcumuladas = 100;
            objetoTest.dañoAcumulado = 5;
            objetoTest.ReducirDaño();
            Assert.AreEqual(0, objetoTest.dañoAcumulado);
        }

        [Test]
        public void AumentarCaloriasTest()
        {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            //objetoTest.Start();

            objetoTest.caloriasAcumuladas = 100;
            Assert.AreEqual(100, objetoTest.caloriasAcumuladas);

            objetoTest.AumentarCalorias(50);

            Assert.AreEqual(150, objetoTest.caloriasAcumuladas);

        }

        [Test]
        public void MorirTest()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();
            //EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");

           // objetoTest.Start();
            //objetoTest.estado = new GameObject().AddComponent<AccionesNormal>();

            objetoTest.caloriasAcumuladas = 100;
            objetoTest.dañoAcumulado = 60;

            objetoTest.Morir();
            //objetoTest.Start();

            Assert.IsNull(objetoTest);
            //Assert.AreEqual(0, objetoTest.caloriasAcumuladas);
            
        }

        [Test]
        public void RestablecerACeroTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            //objetoTest.Start();
            objetoTest.dañoAcumulado = 40;
            objetoTest.RestablecerACero();
            Assert.AreEqual(0, objetoTest.dañoAcumulado);
        }

        [Test]
        public void CambiarAEstadoInvulnerable() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            //objetoTest.Start();
            //objetoTest.CambiarAEstadoInvulnerable();
            //Assert.IsTrue(objetoTest.estado = objetoTest.GetComponent<AccionesInvulnerable>());
        }

        
    }
}
