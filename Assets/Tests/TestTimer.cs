using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestTimer
    {
     /* private GameObject prefabTimer;
        [Test]
        public void StartTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            Assert.AreEqual(1, objetoTest.GetComponent<Timer>().escaladaDeTiempoAlIniciar);
            Assert.IsNotNull(objetoTest.myText);
            Assert.AreEqual(0, objetoTest.tiempoEnSegundos);
        }

        [Test]
        public void UpdateTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            objetoTest.Update();
            Assert.AreEqual(1 * Time.deltaTime, objetoTest.tiempoFrame);
            Assert.AreEqual(1 * Time.deltaTime, objetoTest.tiempoEnSegundos);
            objetoTest.Update();
            Assert.AreEqual(1 * Time.deltaTime, objetoTest.tiempoFrame);
            Assert.AreEqual(2 * Time.deltaTime, objetoTest.tiempoEnSegundos);
        }

        [Test]
        public void ActualizarRelojTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            objetoTest.ActualizarReloj(30);
            Assert.AreEqual(0, objetoTest.minutos);
            Assert.AreEqual(30, objetoTest.segundos);
            Assert.AreEqual("00:30", objetoTest.textoDelReloj);
            Assert.AreEqual("00:30", objetoTest.myText.text);
            objetoTest.ActualizarReloj(120);
            Assert.AreEqual(2, objetoTest.minutos);
            Assert.AreEqual(0, objetoTest.segundos);
            Assert.AreEqual("02:00", objetoTest.textoDelReloj);
            Assert.AreEqual("02:00", objetoTest.myText.text);
        }

        [Test]
        public void PausarTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            objetoTest.Pausar();
            Assert.IsTrue(objetoTest.estaPausado);
            Assert.AreEqual(1, objetoTest.escaladaDeTiempoAlPausar);
            Assert.AreEqual(0, objetoTest.aumentarTiempo);
            objetoTest.Pausar();
            Assert.IsTrue(objetoTest.estaPausado);
            objetoTest.Continuar();
            objetoTest.Pausar();
            Assert.IsTrue(objetoTest.estaPausado);
        }

        [Test]
        public void ContinuarTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            objetoTest.Continuar();
            Assert.IsFalse(objetoTest.estaPausado);
            Assert.AreEqual(0, objetoTest.escaladaDeTiempoAlPausar);
            objetoTest.Continuar();
            Assert.IsFalse(objetoTest.estaPausado);
            objetoTest.Pausar();
            objetoTest.Continuar();
            Assert.AreEqual(1, objetoTest.escaladaDeTiempoAlPausar);
        }

        [Test]
        public void ResetTimerTest()
        {
            prefabTimer = (GameObject)Resources.Load("Tests/Text");
            GameObject objetoInicializado = Object.Instantiate(prefabTimer, new Vector2(0, 0), Quaternion.identity);
            Timer objetoTest = objetoInicializado.GetComponent<Timer>();
            objetoTest.Start();
            objetoTest.ResetTimer();
            Assert.IsFalse(objetoTest.estaPausado);
            Assert.AreEqual(1, objetoTest.escaladaDeTiempoAlIniciar);
            Assert.AreEqual(0, objetoTest.tiempoEnSegundos);
        }     */
    }     
}
