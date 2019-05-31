using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSonidos
    {
        private GameObject prefabAudio;
        [Test]
        public void ActivarSonidoMoverTest()
        {
            prefabAudio = (GameObject)Resources.Load("Tests/AudioSonidos");
            GameObject objetoInicializado = Object.Instantiate(prefabAudio, new Vector2(0, 0), Quaternion.identity);
            AudioSource audioObjeto = objetoInicializado.GetComponent<AudioSource>();
            SonidosController objetoTest = objetoInicializado.GetComponent<SonidosController>();

            objetoTest.Start();
            objetoTest.ActivarSonidoMover();
            Assert.AreEqual(objetoTest.getMover(), audioObjeto.clip);
            
        }

        [Test]
        public void ActivarSonidoComerTest()
        {
            prefabAudio = (GameObject)Resources.Load("Tests/AudioSonidos");
            GameObject objetoInicializado = Object.Instantiate(prefabAudio, new Vector2(0, 0), Quaternion.identity);
            AudioSource audioObjeto = objetoInicializado.GetComponent<AudioSource>();
            SonidosController objetoTest = objetoInicializado.GetComponent<SonidosController>();

            objetoTest.Start();
            objetoTest.ActivarSonidoComer();
            Assert.AreEqual(objetoTest.getComer(), audioObjeto.clip);
        }

        [Test]
        public void ActivarSonidoSufrirDanyoTest()
        {
            prefabAudio = (GameObject)Resources.Load("Tests/AudioSonidos");
            GameObject objetoInicializado = Object.Instantiate(prefabAudio, new Vector2(0, 0), Quaternion.identity);
            AudioSource audioObjeto = objetoInicializado.GetComponent<AudioSource>();
            SonidosController objetoTest = objetoInicializado.GetComponent<SonidosController>();

            objetoTest.Start();
            objetoTest.ActivarSonidoSufrirDanyo();
            Assert.AreEqual(objetoTest.getPerderVida(), audioObjeto.clip);
        }

        [Test]
        public void ActivarSonidoGanarVidaTest()
        {
            prefabAudio = (GameObject)Resources.Load("Tests/AudioSonidos");
            GameObject objetoInicializado = Object.Instantiate(prefabAudio, new Vector2(0, 0), Quaternion.identity);
            AudioSource audioObjeto = objetoInicializado.GetComponent<AudioSource>();
            SonidosController objetoTest = objetoInicializado.GetComponent<SonidosController>();

            objetoTest.Start();
            objetoTest.ActivarSonidoGanarVida();
            Assert.AreEqual(objetoTest.getGanarVida(), audioObjeto.clip);
        }

        [Test]
        public void ActivarSonidoLimitesTest()
        {
            prefabAudio = (GameObject)Resources.Load("Tests/AudioSonidos");
            GameObject objetoInicializado = Object.Instantiate(prefabAudio, new Vector2(0, 0), Quaternion.identity);
            AudioSource audioObjeto = objetoInicializado.GetComponent<AudioSource>();
            SonidosController objetoTest = objetoInicializado.GetComponent<SonidosController>();

            objetoTest.Start();
            objetoTest.ActivarSonidoLimites();
            Assert.AreEqual(objetoTest.getLimite(), audioObjeto.clip);
        }
    }
}
