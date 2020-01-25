using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

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
        public void HaveAnimator()
        {
            var controller = new GameObject().AddComponent<Controller>();

            Assert.IsInstanceOf<Animator>(controller.Animator);
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

            controller.LeftMovement();

            Assert.IsFalse(controller.IsFacingRight);
        }

        [Test]
        public void FlipWhenMovingRight()
        {
            var controller = new GameObject().AddComponent<Controller>();

            Assert.IsTrue(controller.IsFacingRight);
            controller.LeftMovement();
            Assert.IsFalse(controller.IsFacingRight);
            controller.RightMovement();
            Assert.IsTrue(controller.IsFacingRight);
        }

        [Test]
        public void NotFlipWhenMovingRight()
        {
            var controller = new GameObject().AddComponent<Controller>();

            controller.RightMovement();

            Assert.IsTrue(controller.IsFacingRight);
        }

        [Test]
        public void FlipOnceThenStayLeft()
        {
            var controller = new GameObject().AddComponent<Controller>();
            controller.RigidBody = new Rigidbody2D();
            
            controller.LeftMovement();
            controller.LeftMovement();

            Assert.IsFalse(controller.IsFacingRight);
        }

        [Test]
        public void IncreaseHorizontalAxisWhenMovingRight()
        {
            var controller = new GameObject().AddComponent<Controller>();
            var startX = controller.transform.position.x;

            var result = controller.RightMovement();

            Assert.Less(startX, result.x);
        }

        [Test]
        public void DecreaseHorizontalAxisWhenMovingLeft()
        {
            var controller = new GameObject().AddComponent<Controller>();
            var startX = controller.transform.position.x;

            Assert.IsNotNull(controller.transform.position.x);
            Assert.IsNotNull(controller.transform.position.y);

            var result = controller.LeftMovement();

            Assert.Greater(startX, result.x);
        }

        [Test]
        public void FaceLeftWhileMovingLeft()
        {
            var controller = new GameObject().AddComponent<Controller>();

            Assert.Greater(controller.transform.localScale.x, 0);

            _ = controller.LeftMovement();

            Assert.Less(controller.transform.localScale.x, 0);
        }

        [Test]
        public void FaceRightWhileMovingRight()
        {
            var controller = new GameObject().AddComponent<Controller>();

            Assert.Greater(controller.transform.localScale.x, 0);

            _ = controller.RightMovement();

            Assert.Greater(controller.transform.localScale.x, 0);
        }

        [Test]
        public void FaceLeftThenRightWhileMovingBackAndForth()
        {
            var controller = new GameObject().AddComponent<Controller>();

            Assert.Greater(controller.transform.localScale.x, 0);

            _ = controller.LeftMovement();
            Assert.Less(controller.transform.localScale.x, 0);
            _ = controller.RightMovement();

            Assert.Greater(controller.transform.localScale.x, 0);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        [Ignore("Maybe not a valuable test? Maybe how to test unclear?")]
        public IEnumerator UpdateAnimatorMoveValue()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var parentObject = new GameObject("Test Dude").AddComponent<Controller>();
            parentObject.Animator = new GameObject().AddComponent<Animator>();
            var value = parentObject.IsWalking;

            //var keyboard = InputSystem.AddDevice<Keyboard>();
            //keyboard.leftArrowKey.QueueValueChange(.5f);
           // InputSystem.Update();
            yield return new WaitForFixedUpdate();

            value = parentObject.IsWalking;
            Debug.Log($"In test IsWalking Is {value}");

            Assert.IsTrue(value);
            
        }
    }
}
