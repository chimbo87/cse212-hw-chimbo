using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them to verify highest priority comes first
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: The original dequeue loop condition was "index < _queue.Count - 1" which missed the last item.
    // Also, the item was not being removed from the queue after dequeuing.
    public void TestPriorityQueue_BasicPriorityOrdering()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and verify FIFO ordering for same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: The condition used >= instead of >, which would pick the last item with highest priority
    // instead of the first one (FIFO behavior).
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of different and same priorities
    // Expected Result: Higher priority items first, then FIFO for same priority
    // Defect(s) Found: Same as above - loop condition and removal issues, plus FIFO ordering issue.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Medium1", 3);
        priorityQueue.Enqueue("High2", 5);
        priorityQueue.Enqueue("Medium2", 3);
        
        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Medium1", priorityQueue.Dequeue());
        Assert.AreEqual("Medium2", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: InvalidOperationException should be thrown
    // Defect(s) Found: None - this should work correctly with the original implementation.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue single item
    // Expected Result: Should be able to enqueue and dequeue single item successfully
    // Defect(s) Found: The loop condition issue would cause problems even with single items.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Only", 1);
        
        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test with negative priorities
    // Expected Result: Higher (less negative) priorities should come first
    // Defect(s) Found: Same defects as above would affect this test too.
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("VeryLow", -5);
        priorityQueue.Enqueue("Low", -1);
        priorityQueue.Enqueue("High", 3);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("VeryLow", priorityQueue.Dequeue());
    }
}