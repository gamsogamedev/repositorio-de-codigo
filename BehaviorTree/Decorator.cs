using System; 

/* Herda da Classe BTNode.
Possui um único filho e seu Execute() é o mesmo de BTNode */
public class Decorator : BTNode 
{       
    public BTNode Child {get; set;}
    public Decorator(BehaviorTree t, BTNode c): base(t) {
        Child = c;
    }
}

