# 2º Projeto de Linguagens de Programação I 2019/2020

## Autoria

**Diogo Heriques (a21802132)**

- Fez a estrutura inicial do programa. Trabalhou na classe `ConsoleUI`,
`ConsoleMenu` (que foi adicionado a `ConsoleUI`)  e `Player`.
Trabalhou na documentação do projeto, como o `README`, o UML e o ficheiro
*doxygen*.

**Inácio Amerio (a21803493)**

- Início o projeto, organizou a estrutura do trabalho, discutiu com os colegas e
ajudou os outros. Trabalhou nas classes `Board`, `ConsoleGame`,
`Piece`, `Position` e `Player`.

**João Dias (a21803573)**

- Trabalhou com o Inácio Amerio em várias partes do código, nomeadamente
`Board`, em que focou na parte de trabalhar na mecânica de saltar sobre
peças, em termos de verificar quando era possível fazer isso ou não.
Adicionalmente trabalhou na classe `WinChecker`.

[Repositório Git público.](https://github.com/FPTheFluffyPawed/Project2_LP2019)

## Arquitetura da solução

### Descrição da solução

O programa foi organizado de forma que possa-se utilizar o código não só em
consola, mas também em Unity. A classe `ConsoleGame` é utilizada para ligar
ao `Program`, depois `ConsoleUI` é utilizado para fazer o desenho do tabuleiro
do jogo para consola. A partir das classes mencionadas, estas vão utilizar as
classes `Board`, `Piece`, `State`, `Position`, `Player` e `WinChecker`, em que
estas classes mencionadas são o jogo próprio.

`Position`, `Piece` e `State` são classes de dados. `Position` é utilizado para
guardar a posição da peça em `Piece`, que depois são utilizados para o `Board`.

`Board` têm a maioria do jogo e métodos relevantes ao funcionamento do jogo.

O primeira ecrã do jogo vêm do `ConsoleUI` que é chamado através do
`ConsoleGame` que o utilizador vê e daqui pode escolher para jogar, ver as
instruções ou sair.

Para a verificação de posições no tabuleiro, criamos dois métodos:
`IsOutOfBounds()`, que verifica se a posição passada está fora do tabuleiro, e
`IsOccupied()`, que verifica se a posição têm uma peça ou não. Com estes dois
métodos, podemos ver exatamente os estados das posições durante as jogadas do
utilizador.

### Diagrama UML

![<UML>](images/UML.png)

### Referências

* O projeto
[Tic Tac Toe](http://starboundsoftware.com/books/c-sharp/try-it-out/tic-tac-toe)
do livro _The C# Player’s Guide 3rd Edition_, escrito por RB Witaker.

* O primeiro projeto entregue por nós, que se pode encontrar
[aqui](https://github.com/FPTheFluffyPawed/Project1_LP12019).
