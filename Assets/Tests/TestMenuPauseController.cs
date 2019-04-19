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
            prefabPauseMenu = (GameObject)Resources.Load("Test/MenuPausa");
            GameObject objetoInicializado = Object.Instantiate(prefabPauseMenu, new Vector2(0, 0), Quaternion.identity);
            PauseMenuController objetoTest = objetoInicializado.GetComponent<PauseMenuController>();
            objetoTest.PauseGame();
            Assert.IsTrue(objetoTest.IsGamePaused());
        }

        [Test]
        public void PauseGameTest()
        {
            prefabPauseMenu = (GameObject)Resources.Load("Test/MenuPausa");
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
            prefabPauseMenu = (GameObject)Resources.Load("Test/MenuPausa");
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
            objetoTest.PauseGame();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestMenuPauseControllerWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
