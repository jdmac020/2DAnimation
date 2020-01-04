using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

namespace Tests
{
    public class ControllerShould
    {
        // A Test behaves as an ordinary method
        [Test]
        public void HaveRigidBody2D()
        {
            var controller = new GameObject().AddComponent<Controller>();
            
            Assert.IsInstanceOf<Rigidbody2D>(controller.RigidBody);
        }

        [Test]
        public void StartFacingRight()
        {
            var controller = new GameObject().AddComponent<Controller>();
            
            Assert.IsTrue(controller.IsFacingRight);
        }

        [Test]
        public void FlipWhenMovingLeft()
        {
            var controller = new GameObject().AddComponent<Controller>();

            controller.MoveLeft();

            Assert.IsFalse(controller.IsFacingRight);
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
