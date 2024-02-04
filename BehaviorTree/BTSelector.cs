using System; 
using System.Collections.Generic;
/* Herda da Classe Composite que Herda de BTNote.
Possui uma lista de filhos e seu Execute() funciona de maneira parecida à um OR Gate, 
retorna Sucess se um de seus filhos retornar Success. Se seu filho retornar Failure, passa para o próximo filho. */
public class BTSelector : BTComposite 
{       
    private int currentNode = 0; 

    public BTSelector(BehaviorTree t, BTNode [] children): base(t, children) {
    }

    public override Result Execute() {
            if (currentNode < Children.Count) {
                Result result = Children[currentNode].Execute();
                
                if (result == Result.Running)
                    return Result.Running;
                else if (result == Result.Failure) {
                    currentNode++;
                    return Result.Running;
                }
                else {
                    currentNode++;
                    if (result == Result.Success)
                        return Result.Success;
                }
            }
            currentNode = 0;
            return Result.Failure;  
    }
}