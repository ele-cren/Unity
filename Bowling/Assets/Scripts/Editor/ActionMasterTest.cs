//using UnityEngine;
//using UnityEditor;
//using UnityEngine.TestTools;
//using NUnit.Framework;
//using System.Collections;
//using System.Linq;
//
//public class ActionMasterTest {
//
//	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
//	private ActionMaster.Action reset = ActionMaster.Action.Reset;
//	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
//
//	[Test]
//	public void ActionMasterTestSimplePasses() {
//		// Use the Assert class to test conditions.
//	}
//
//	// A UnityTest behaves like a coroutine in PlayMode
//	// and allows you to yield null to skip a frame in EditMode
//	[UnityTest]
//	public IEnumerator ActionMasterTestWithEnumeratorPasses() {
//		// Use the Assert class to test conditions.
//		// yield to skip a frame
//		yield return null;
//	}
//
//	[Test]
//	public void Test00(){
//		int[] test = {1, 5};
//		Assert.AreEqual(endTurn, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test01(){
//		int[] test = {1};
//		Assert.AreEqual(tidy, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test02(){
//		int[] test = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
//		Assert.AreEqual(reset, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test03(){
//		int[] test = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 5};
//		Assert.AreEqual(tidy, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test04(){
//		int[] test = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 5,10};
//		Assert.AreEqual(endGame, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test05(){
//		int[] test = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
//		Assert.AreEqual(tidy, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test06(){
//		int[] test = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0, 1,1, 1,1, 10,0,10};
//		Assert.AreEqual(endGame, ActionMaster.NextAction(test.ToList()));
//	}
//
//	[Test]
//	public void Test07(){
//		int[] test = {10};
//		Assert.AreEqual(endTurn, ActionMaster.NextAction(test.ToList()));
//	}
//}
