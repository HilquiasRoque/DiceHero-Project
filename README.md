DICE HERO PROJECT

Este aplicativo de console feito em .NET é um jogo de RPG em turnos criado para 
aplicar meus conhecimentos de POO em C#.

O objetivo do jogo é criar um herói e vencer batalhas até o chefão final.
O herói evolui à medida em que vence as lutas, podendo escolher entre possíveis
evoluções de classes.
A mecânica do jogo é baseada em turnos, sendo cada jogada, tanto do herói quanto
dos inimigos, decidida pelo rolar do dado.

STATUS: em desenvolvimento.

#v.1.0
- Já é possível jogar.
- É possível dar um nome ao herói.
- Herói sobe de nível ao vencer batalhas.
- O inimigo tem sempre o mesmo nome.
- O jogo só termina se o herói morrer.

#v.1.1
- Implementação de nomes diferentes para os inimigos
- Alterações no código do programa para que fique mais enxuto
 (criei funções para as mensagens de texto do jogo)
- Criação de novo método para a classe BaseModel, que irá exibir a probabilidade
  dos ataques separadamente do método de ataque.
- Há um bug que faz o herói upar facilmente após o subir para o nível 6. 
  Isso acontece o HP do inimigo só será calculado até o herói ter nível 5. Após
  este nível, os inimigos iniciam a luta com hp 0, o que faz com que o herói
  vença no primeiro turno. Será corrigido em breve.