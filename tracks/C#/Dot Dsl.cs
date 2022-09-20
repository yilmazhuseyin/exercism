using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public abstract class HasAttributes : IEnumerable<Attr>
{
    protected List<Attr> attributes = new List<Attr>();
    public void Add(string key, string value) => attributes.Add(new Attr(key, value));
    public IEnumerator<Attr> GetEnumerator() => attributes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
public class Node : HasAttributes
{
    public string name;
    public void Add(string property, string value) => attributes.Add(new Attr(property, value));

    public Node(string name)
    {
        attributes = new List<Attr>();
        this.name = name;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        if (obj is Node)
        {
            Node other = obj as Node;
            return this.name == other.name;
        }
        return false;
    }
    public override int GetHashCode() => name.GetHashCode();

}
public class Edge : HasAttributes
{
    public string vtx1;
    public string vtx2;
    public void Add(string property, string value) => attributes.Add(new Attr(property, value));
    public Edge(string name1, string name2)
    {
        attributes = new List<Attr>();
        vtx1 = name1;
        vtx2 = name2;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        if (obj is Edge)
        {
            Edge other = obj as Edge;
            return this.vtx1 == other.vtx1 && this.vtx2 == other.vtx2;
        }
        return false;
    }
    public override int GetHashCode() => vtx1.GetHashCode() ^ vtx2.GetHashCode();
}
public class Attr
{
    public string property;
    public string value;
    public Attr(string property, string value)
    {
        this.property = property;
        this.value = value;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        if (obj is Attr)
        {
            Attr other = obj as Attr;
            return this.property == other.property && this.value == other.value;
        }
        return false;
    }
    public override int GetHashCode() => property.GetHashCode() ^ value.GetHashCode();
}
public class Graph : HasAttributes
{
    private List<Node> _Nodes = new List<Node>();
    private List<Edge> _Edges = new List<Edge>();

    public Node[] Nodes { get => _Nodes.OrderBy(e => e.name).ToArray(); }
    public Edge[] Edges { get => _Edges.OrderBy(e => e.vtx1).ThenBy(e => e.vtx2).ToArray(); }
    public Attr[] Attrs { get => attributes.OrderBy(e => e.property).ToArray(); }
    public void Add(string property, string value) => attributes.Add(new Attr(property, value));
    public void Add(Edge edge) => _Edges.Add(edge);
    public void Add(Node node) => _Nodes.Add(node); 
}
