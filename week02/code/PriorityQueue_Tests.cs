using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priorities: Bob (2), Tim (5), George (3), Sue (3)
    // Run until the queue is empty
    // Expected Result: Tim, George, Sue, Bob
    // Defect(s) Found: Doesn't actual dequeue the person with the highest priority
    // 1. Added _queue.RemoveAt(highPriorityIndex); to remove the item with the highest priority to PriorityQueue.cs
    // 2. Changed the comparison of Priority to be > instead of >= in PriorityQueue.cs
    // 3. Changed _queue.Count -1 to _queue.Count in PriorityQueue.cs
    public void TestPriorityQueue_1()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var george = new PriorityItem("George", 3);
        var sue = new PriorityItem("Sue", 3);
        PriorityItem[] expectedResult = [tim, george, sue, bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("George", 3);
        priorityQueue.Enqueue("Sue", 3);


        int i = 0;
        for (i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();

            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: Add customer to queue and try to dequeue a customer when the queue is empty
    // Expected Result: "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "The queue is empty.");
    }

    // Add more test cases as needed below.
}