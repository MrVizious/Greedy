using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /*public class TestLevelController
    {
        public GameObject prefabLevelController;
        [Test]
        public void TestComerTodo() {
            prefabLevelController = (GameObject)Resources.Load("Tests/LevelController");
            GameObject objetoInicializado = (GameObject)Object.Instantiate(prefabLevelController, new Vector2(0, 0), Quaternion.identity);
            LevelController objetoTest = objetoInicializado.GetComponent<LevelController>();

            objetoTest.Start();
            Assert.AreNotEqual(0, objetoTest.numeroFrutas);
            objetoTest.numeroFrutas = 0;
            objetoTest.NivelCompletado();
            objetoTest.Start();
            Assert.AreNotEqual(0, objetoTest.numeroFrutas);

            
        }
    }*/
}
