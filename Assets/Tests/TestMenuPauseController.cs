using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMenuPauseController
    {
        private GameObject prefabPauseMenu;
        [Test]
        public void IsGamePausedTest()
        {
            prefabPauseMenu = (GameObject)Resources.Load("Tests/PauseMenu");
            GameObject objetoInicializado = (GameObject) Object.Instantiate(prefabPauseMenu, new Vector2(0, 0), Quaternion.identity);
            PauseMenuController objetoTest = objetoInicializado.GetComponent<PauseMenuController>();
            Assert.IsFalse(objetoTest.IsGamePaused());
            objetoTest.PauseGame();
            Assert.IsTrue(objetoTest.IsGamePaused());
            objetoTest.ResumeGame();
            Assert.IsFalse(objetoTest.IsGamePaused());
        }

        [Test]
        public void PauseGameTest()
        {
            prefabPauseMenu = (GameObject)Resources.Load("Tests/PauseMenu");
            GameObject objetoInicializado = Object.Instantiate(prefabPauseMenu, new Vector2(0, 0), Quaternion.identity);
            PauseMenuController objetoTest = objetoInicializado.GetComponent<PauseMenuController>();
            objetoTest.PauseGame();
            Assert.AreEqual(0f, Time.timeScale);
            Assert.IsTrue(objetoTest.PauseMenu.active);
            Assert.IsTrue(objetoTest.isPaused);
            objetoTest.ResumeGame();
            objetoTest.PauseGame();
            Assert.AreEqual(0f, Time.timeScale);
            Assert.IsTrue(objetoTest.PauseMenu.active);
            Assert.IsTrue(objetoTest.isPaused);
        }

        [Test]
        public void ResumeGameTest()
        {
            prefabPauseMenu = (GameObject)Resources.Load("Tests/PauseMenu");
            GameObject objetoInicializado = Object.Instantiate(prefabPauseMenu, new Vector2(0, 0), Quaternion.identity);
            PauseMenuController objetoTest = objetoInicializado.GetComponent<PauseMenuController>();
            objetoTest.ResumeGame();
            Assert.AreEqual(1f, Time.timeScale);
            Assert.IsFalse(objetoTest.PauseMenu.active);
            Assert.IsFalse(objetoTest.isPaused);
            objetoTest.PauseGame();
            objetoTest.ResumeGame();
            Assert.AreEqual(1f, Time.timeScale);
            Assert.IsFalse(objetoTest.PauseMenu.active);
            Assert.IsFalse(objetoTest.isPaused);
        }
    }
}
