using System; 
using System.Collections.Generic;

/* Herda da Classe Composite que Herda de BTNote.
Possui uma lista de filhos e seu Execute() funciona de maneira parecida à um AND Gate, 
retorna Sucess se todos seus filhos retornarem Success. Se seu filho retornar Failure, retorna Failure. */
public class BTSequencer : BTComposite 
{       
        private int currentNode = 0; 

        public BTSequencer(BehaviorTree t, BTNode [] children): base(t, children) {
        }

        public override Result Execute() {
                if (currentNode < Children.Count) {
                    Result result = Children[currentNode].Execute();
                    
                    if (result == Result.Running)
                        return Result.Running;
                    else if (result == Result.Failure) {
                        currentNode = 0;
                        return Result.Failure;
                    }
                    else {
                        currentNode++;
                        if (currentNode < Children.Count)
                            return Result.Running;
                        else {
                            currentNode = 0;
                            return Result.Success;
                        }
                    }

                }
            return Result.Success;
        }
}