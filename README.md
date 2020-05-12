# 2º Projeto de Linguagens de Programação I 2019/2020

## Autoria
**Diogo Heriques (a21802132)**

- Fez a estrutura inicial do programa. Trabalhou na classe `ConsoleRender.cs`,
`ConsoleMenu.cs`  e `Player.cs`. Trabalhou na documentação do projeto, como o
`README.md`, o UML e o ficheiro doxygen.

**Inácio Amerio (a21803493)**

- Início o projeto, organizou a estrutura do trabalho, discutiu com os colegas e
ajudou aos outros. Trabalhou nas classes `Board.cs`, `ConsoleGame.cs`,
`Piece.cs`, `Position.cs` e `Player.cs`.

**João Dias (a21803573)**

- Trabalhou com o Inácio Amerio em várias partes do código, nomeadamente `Board.cs`, em que focou na parte de trabalhar na mecânica de saltar sobre peças, em termos de verificar quando era possível fazer isso ou não. Adicionalmente trabalhou na classe `WinChecker.cs`.

[Repositório Git público.](https://github.com/FPTheFluffyPawed/Project2_LP2019)

## Arquitetura da solução

### Descrição da solução

O programa foi organizado de forma que possa-se utilizar o código não só em consola, mas também em Unity. As classes `ConsoleMenu.cs`, `ConsoleGame.cs` e `ConsoleRenderer.cs` são utilizadas para ligar ao `Program.cs`. A partir das classes mencionadas, estas vão utilizar as classes `Board.cs`, `Piece.cs`, `State.cs`, `Position.cs`, `Player.cs` e `WinChecker.cs`, em que estas classes mencionadas são o jogo próprio.

`Position.cs`, `Piece.cs` e `State.cs` são classes de dados. `Position.cs` é utilizado para guardar a posição da peça em `Piece.cs`, que depois são utilizados para o `Board.cs`.

`Board.cs` têm a maioria do jogo e métodos relevantes ao funcionamento do jogo.

`ConsoleMenu.cs` é o primeira ecrã do jogo que o utilizador vê e daqui pode escolher para jogar, ver as instruções ou sair.

Para a verificação de posições no tabuleiro, criamos dois métodos: `IsOutOfBounds`, que verifica se a posição passada está fora do tabuleiro, e `IsOccupied`, que verifica se a posição têm uma peça ou não. Com estes dois métodos, podemos ver exatamente os estados das posições durante as jogadas do utilizador.

### Diagrama UML

![<UML>](images/UML.png)

### Referências

* O projeto
[Tic Tac Toe](http://starboundsoftware.com/books/c-sharp/try-it-out/tic-tac-toe) do livro _The C# Player’s Guide 3rd Edition_, escrito por RB Witaker.
