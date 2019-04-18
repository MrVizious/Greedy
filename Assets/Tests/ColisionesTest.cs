using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Nombre;


// Método para encontrar Scripts
// https://stackoverflow.com/questions/50223866/how-to-set-up-unit-tests-in-unity-and-fix-missing-assembly-reference-error

namespace Tests {

	public class ColisionesTest {
		private GameObject prefabPlayer;
		private GameObject prefabPared;

		// A Test behaves as an ordinary method
		[Test]
		public void ColisionesTestSimplePasses() {
			prefabPlayer = (GameObject) Resources.Load("Tests/Player");
			prefabPared = (GameObject) Resources.Load("Tests/Roca");
			GameObject player = Object.Instantiate(prefabPlayer, new Vector2(0, 0), Quaternion.identity);
			GameObject pared = Object.Instantiate(prefabPared, new Vector2(1, 0), Quaternion.identity);
			Assert.IsFalse(player.GetComponent<Movimiento>().PuedeAvanzar(new Vector3(1, 0, 0)));
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
		public IEnumerator ColisionesTestWithEnumeratorPasses() {
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			yield return null;
		}
	}
}
