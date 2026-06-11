# Trabalho Final - FTC

Este repositório contém a implementação do trabalho final da disciplina de Fundamentos Teóricos da Computação. 
O projeto consiste no desenvolvimento de simuladores para três máquinas abstratas clássicas da Teoria da Computação, utilizando a **linguagem C#**.

## Descrição do Projeto

O software foi segmentado em três módulos principais, refletindo as exigências da especificação funcional:

* **Parte 1 - Autômato Finito Determinístico (AFD):** Simulador genérico de AFD focado na linguagem L1 (cadeias que terminam com "ab"). A 5-tupla formal do autômato é carregada dinamicamente através de um arquivo JSON. O módulo imprime a matriz de transições e valida um lote de cadeias a partir de um arquivo de texto, exibindo o rastro de estados percorridos e o veredito final (Aceita/Rejeitada).

* **Parte 2 - Autômato de Pilha (AP):** Implementação de um motor recursivo não-determinístico com critério de aceitação por pilha vazia. O módulo atende a duas linguagens: L2 (a^n b^n) e L3 (palíndromos pares e ímpares). O simulador exibe a configuração instantânea a cada passo, demonstrando o consumo da fita e as operações de push/pop na estrutura de dados da pilha.

* **Parte 3 - Máquina de Turing (MT):** Simulador da 7-tupla formal operando sobre uma fita dinâmica bidirecional (Dictionary). O motor resolve a linguagem sensível ao contexto L4 (a^n b^n c^n) através de marcação de símbolos, e computa a função unária aritmética f(n) = n + 1. Inclui mecanismos de proteção contra loops infinitos e exibe o rastro computacional demarcando a posição do cabeçote de leitura/escrita.

## Estrutura do Projeto
```
Estrutura/
├─ .gitignore                      // Padrão .NET (ignora bin/, obj/, etc.)
├─ ftc-20261-final.sln             
├─ Parte1/             
│  ├─ Program.cs                   // Orquestrador da Parte 1
│  ├─ Resources/                  
│  │  ├─ entradas.txt              
│  │  └─ afd.json                  
│  ├─ Domain/                     
│  │  ├─ AutomacaoDeterministica.cs 
│  ├─ Infrastructure/              
│  │  └─ AutomatonJsonLoader.cs    
│  └─ Presentation/               
│     ├─ TableVisualizer.cs        
│     └─ ConsoleTraceListener.cs
|
├─ Parte2/
│  ├─ Program.cs                   // Orquestrador da Parte 3
│  ├─ Domain/
│  │  └─ AutomatoPilha.cs
│  │  └─ ChaveTransicao.cs
│  │  └─ DestinoTransicao.cs
│  ├─ Infrastructure/
│  │  └─ ConfiguradorMt.cs
│  ├─ Presentation/
│  │  └─ VisualizadorMt.cs
│  ├─ Resources/
│  │  └─ entradas_ap.txt
|       
├─ Parte3/
│  ├─ Program.cs                   // Orquestrador da Parte 3
│  ├─ Domain/
│  │  └─ MaquinaTuring.cs
│  ├─ Infrastructure/
│  │  └─ ConfiguradorMt.cs
│  ├─ Presentation/
│  │  └─ VisualizadorMt.cs
│  ├─ Resources/
│  │  └─ entradas_ap.txt           
├─ Program.cs
```
## Pré-requisitos

Para compilar e executar o projeto, é necessário ter instalado o SDK do .NET versão 10.0 ou superior.
* [Download .NET SDK](https://dotnet.microsoft.com/download)
* [Download .NET 10.0](https://dotnet.microsoft.com/pt-br/download/dotnet/10.0)
* [Visual Studio 2026](https://visualstudio.microsoft.com/pt-br/downloads/)

## Instruções de Compilação

A execução deve ser realizada a partir da raiz do repositório, onde o orquestrador principal proverá um menu de navegação entre as partes do trabalho.

 **1. Clone o repositório**
```bash
git clone https://github.com/d4n13lx/ftc-20261-final.git
```
2. Abra o terminal (Prompt de Comando ou PowerShell).
3. Navegue até o diretório raiz do projeto (onde se encontra o arquivo principal `.csproj` e o `Program.cs` de menu).
4. Execute o comando de compilação e execução do .NET:

```bash
dotnet run
```

## Configuração de Casos de Teste
Edite os arquivos texto localizados dentro das pastas `Resources` de cada módulo:
- **AFD (Autômato Finito Determinístico)**: Edite `Parte1/Resources/entradas.txt` ou altere a topologia da máquina em `afd.json`.

- **AP (Autômato de Pilha)**: Edite as cadeias no arquivo `Parte2/Resources/entradas_ap.txt`.

- **MT (Máquina de Turing)**: Edite as cadeias nos arquivos `Parte3/Resources/entradas_L4.txt` e `entradas_funcao.txt`.


## Integrantes
* Daniel Damazo Kazimoto - Matrícula: 72500867
