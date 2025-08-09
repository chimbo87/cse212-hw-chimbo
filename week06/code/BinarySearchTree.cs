using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    public bool Contains(int value) => _root?.Contains(value) ?? false;

    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

   public IEnumerable<int> Reversed()
{
    var numbers = new List<int>();
    TraverseBackward(_root, numbers);
    return numbers;
}

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    public int GetHeight() => _root?.GetHeight() ?? 0;

    public override string ToString() => $"<Bst>{{{string.Join(", ", this)}}}";
}