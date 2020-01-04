using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ControllerTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ControllerTestSimplePasses()
        {
            var controller = new GameObject().AddComponent<Controller>();
            // Use the Assert class to test conditions
            Assert.IsInstanceOf<Rigidbody2D>(controller.RigidBody);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        [Ignore("This ain't a real thing yet")]
        public IEnumerator ControllerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
