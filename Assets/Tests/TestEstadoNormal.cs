﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestEstadoNormal
    {
        private GameObject prefabPlayer;

        [Test]
        public void RecibirDañoTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            objetoTest.Start();

            Assert.AreEqual(0, objetoTest.dañoAcumulado);
            objetoTest.RecibirDaño(30);
            Assert.AreEqual(30, objetoTest.dañoAcumulado);
        }

        [Test]
        public void ReducirDañoTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            objetoTest.Start();
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

            objetoTest.Start();

            objetoTest.caloriasTotal = 100;
            Assert.AreEqual(100, objetoTest.caloriasTotal);

            objetoTest.AumentarCalorias(50);

            Assert.AreEqual(150, objetoTest.caloriasTotal);

        }

        [Test]
        public void RestablecerACeroTest() {
            prefabPlayer = (GameObject)Resources.Load("Tests/Player");
            GameObject objetoInicializado = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
            PlayerController objetoTest = objetoInicializado.GetComponent<PlayerController>();

            objetoTest.Start();
            objetoTest.dañoAcumulado = 40;
            objetoTest.RestablecerACero();
            Assert.AreEqual(0, objetoTest.dañoAcumulado);
        }
        
    }
}
