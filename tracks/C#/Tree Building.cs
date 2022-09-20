using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
    public bool IsRoot => RecordId == 0;
}

public class Tree
{
    public readonly int Id;
    public List<Tree> Children { get; }
    public bool IsLeaf => Children.Count == 0;
    public Tree(int id)
    {
        Id = id;
        Children = new List<Tree>();
    }
}
public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var orderedRecords = records.OrderBy(record => record.RecordId).ToList();

        if (orderedRecords.Count == 0) throw new ArgumentException();

        var nodes = new Dictionary<int, Tree>();

        var previousRecordId = -1;

        foreach (var item in orderedRecords)
        {
            if (item.IsRoot && item.ParentId != 0) throw new ArgumentException();
            else if (!item.IsRoot && item.ParentId >= item.RecordId) throw new ArgumentException();
            else if (!item.IsRoot && item.RecordId != previousRecordId + 1) throw new ArgumentException();

            nodes[item.RecordId] = new Tree(item.RecordId);
            if (!item.IsRoot) nodes[item.ParentId].Children.Add(nodes[item.RecordId]);
            previousRecordId++;
        }
        return nodes[0];
    }
}
