using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class ScoreMasterTest {

	[Test]
	public void ScoreMasterTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ScoreMasterTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	[Test]
	public void Test00(){
		int[] rolls = {10,0, 2,5, 6,2, 10,0, 1,2};
		int[] res = {17, 24, 32, 45, 48};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test00Strike19(){
		int[] rolls = {4,5, 4,4, 10,0, 8,2, 1,4, 5,5, 10,0, 7,3, 2,2, 10,7,2};
		int[] res = {9, 17, 37, 48, 53, 73, 93, 105, 109, 128};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test01Not21(){
		int[] rolls = {2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,5};
		int[] res = {4, 8, 12, 16, 20, 24, 28, 32, 36, 43};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test02Spare20(){
		int[] rolls = {2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,8,6};
		int[] res = {4, 8, 12, 16, 20, 24, 28, 32, 36, 52};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test03Strike19(){
		int[] rolls = {2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 10,6,3};
		int[] res = {4, 8, 12, 16, 20, 24, 28, 32, 36, 55};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test04trike17(){
		int[] rolls = {2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 10,0, 6,4,2};
		int[] res = {4, 8, 12, 16, 20, 24, 28, 32, 52, 64};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test05pare18(){
		int[] rolls = {2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 7,3, 3,7,6};
		int[] res = {4, 8, 12, 16, 20, 24, 28, 32, 45, 61};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test06DoubleStrike(){
		int[] rolls = {10,0, 10,0, 3,2};
		int[] res = {23, 38, 43};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test06FullStrikesEnd(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0, 10,0, 10,10,10};
		int[] res = {2, 4, 6, 8, 10, 12, 14, 44, 74, 104};

		Assert.AreEqual(res.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test07GutterBallThenStrike()
	{
		int[] rolls = { 0,10, 3 };
		int[] totalS = { 13 };
		Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreFrame(rolls.ToList()));
	}

	[Test]
	public void Test08StrikeEndOfFrame () {
		int[] rolls = { 1,1, 0,10, 3,4};
		int[] totalS = {  2,   15, 22};
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] //http://bowlinganalyse.fr/comment-compter-les-points/
	[Category ("Verification")]
	public void GoldenTest00 ()
	{
		int[] rolls = { 10,0, 10,0, 10,0, 7,2, 4,6, 0,9, 10,0, 7,3, 9,0, 10,10,8 };
		int[] totalS = { 30,57,76,85,95,104,124,143,152,180 };
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] //http://slocums.homestead.com/gamescore.html
	[Category ("Verification")]
	public void GoldenTest01 ()
	{
		int[] rolls = { 10,0, 7,3, 9,0, 10,0, 0,8, 8,2, 0,6, 10,0, 10,0, 10,8,1 };
		int[] totalS = { 20, 39, 48, 66, 74, 84, 90, 120, 148, 167 };
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] //https://www.thoughtco.com/bowling-scoring-420895
	[Category ("Verification")]
	public void GoldenTest02 ()
	{
		int[] rolls = { 10,0, 7,3, 7,2, 9,1, 10,0, 10,0, 10,0, 2,3, 6,4, 7,3,3};
		int[] totalS = { 20, 37, 46, 66, 96, 118, 133, 138, 155, 168 };
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] 
	public void TestError ()
	{
		int[] rolls = { 10,0};
		int[] totalS = {};
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] 
	public void TestError01 ()
	{
		int[] rolls = { 10,0, 10,0,};
		int[] totalS = {};
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}

	[Test] 
	public void TestError02 ()
	{
		int[] rolls = { 10,0, 10,0, 4,6};
		int[] totalS = {24, 44};
		Assert.AreEqual (totalS.ToList(), ScoreMaster.ScoreFrame (rolls.ToList()));
	}
}