using System; 
using System.Collections.Generic;

/* Herda da Classe BTNode. É o node que possibilita a complexidade da árvore.
Possui uma Lista de filhos e seu Execute() é o mesmo de BTNOde */

public class BTComposite : BTNode 
{         
    public List<BTNode> Children {get; set;}
    public BTComposite(BehaviorTree t, BTNode [] nodes): base(t) {
            Children = new List<BTNode>(nodes);
        }
    
}