using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestFabrica
    {
        private GameObject prefabFabrica;
        private GameObject devuelto;

        [Test]
        public void GetConsumibleTest()
        {
            prefabFabrica = (GameObject)Resources.Load("Tests/SpawnerElementos");
            GameObject objetoInicializado = Object.Instantiate(prefabFabrica, new Vector2(0, 0), Quaternion.identity);
            FabricaConsumibles objetoTest = objetoInicializado.GetComponent<FabricaConsumibles>();

            devuelto = objetoTest.GetConsumible("fresa");
            Assert.AreEqual("Fresa", devuelto.name);

            devuelto = objetoTest.GetConsumible("uva");
            Assert.AreEqual("Uva", devuelto.name);

            devuelto = objetoTest.GetConsumible("pimiento");
            Assert.AreEqual("Pimiento", devuelto.name);

            devuelto = objetoTest.GetConsumible("zanahoria");
            Assert.AreEqual("Zanahoria", devuelto.name);

            devuelto = objetoTest.GetConsumible("guardian");
            Assert.AreEqual("Guardian", devuelto.name);

            devuelto = objetoTest.GetConsumible("guardianRapido");
            Assert.AreEqual("GuardianRapido", devuelto.name);

            devuelto = objetoTest.GetConsumible("corazon");
            Assert.AreEqual("corazon", devuelto.name);

            devuelto = objetoTest.GetConsumible("capsula");
            Assert.AreEqual("capsula", devuelto.name);

            devuelto = objetoTest.GetConsumible("defensa");
            Assert.AreEqual("defensa", devuelto.name);

            devuelto = objetoTest.GetConsumible("trampa");
            Assert.AreEqual("trampacepo", devuelto.name);

            devuelto = objetoTest.GetConsumible("hola");
            Assert.IsNull(devuelto);
        }

    }
}
