using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMovimiento
    {
        private GameObject prefabPlayer;
        private GameObject prefabPared;
        
        [Test]
        public void StartTest()
        {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            Movimiento objetoTest = objetoInicializado.GetComponent<Movimiento>();
            objetoTest.Start();
            Assert.AreEqual(1, objetoTest.capasDeColision);
            Assert.AreEqual(objetoTest.transform.position, objetoTest.posicionObjetivo);
            Assert.AreEqual(5f, objetoTest.runSpeed);
            Assert.AreEqual(0.35f, objetoTest.anguloRaycast);
        }

        [Test]
        public void MoveTest()
        {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            Movimiento objetoTest = objetoInicializado.GetComponent<Movimiento>();
            objetoTest.Start();
            objetoTest.posicionObjetivo = new Vector3(4, 3, 0);
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            objetoTest.Move();
            Assert.AreEqual(new Vector3(4, 3, 0), objetoTest.transform.position);
        }

        [Test]
        public void PuedeAvanzarTest()
        {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            prefabPared = (GameObject)Resources.Load("Tests/Roca");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            GameObject pared = Object.Instantiate(prefabPared, new Vector2(1, 0), Quaternion.identity);
            Movimiento objetoTest = objetoInicializado.GetComponent<Movimiento>();
            objetoTest.Start();

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MovimientoWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
