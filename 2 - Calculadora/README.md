# Aplicação Calculadora

## Visão Geral
Esta é uma aplicação de calculadora simples desenvolvida em Java que suporta operações aritméticas básicas. O projeto demonstra o uso de padrões de design como o Método Factory e segue uma arquitetura modular e limpa.

## Funcionalidades
- Adição
- Subtração
- Multiplicação
- Divisão
- Interface de linha de comando interativa
- Tratamento de erros para divisão por zero

## Arquitetura
A aplicação segue uma arquitetura em camadas:
- **Camada de Visualização**: Gerencia a interação e entrada do usuário
- **Camada de Controle**: Gerencia a comunicação entre visualização e modelo
- **Camada de Modelo**: Implementa a lógica central de cálculo
- **Padrão Factory**: Cria objetos de operação dinamicamente

## Tecnologias Utilizadas
- Java 23
- Maven para gerenciamento de projeto

## Estrutura do Projeto
```
src/main/java/br/ifes/calculadora/
├── Application.java         # Ponto de entrada principal
├── controller/
│   └── Controller.java      # Coordena os cálculos
├── model/
│   ├── Calculadora.java     # Lógica central de cálculo
│   ├── factories/
│   │   └── Factory.java     # Cria objetos de operação
│   └── operacoes/
│       ├── IOperacao.java   # Interface de operação
│       ├── Somar.java       # Implementação de adição
│       ├── Subtrair.java    # Implementação de subtração
│       ├── Multiplicar.java # Implementação de multiplicação
│       └── Dividir.java     # Implementação de divisão
└── view/
    └── Menu.java            # Interface de usuário
```

## Como Usar
1. Execute a classe `Application`
2. Escolha uma operação no menu:
   - Somar
   - Subtrair
   - Multiplicar
   - Dividir
3. Digite dois valores inteiros
4. Visualize o resultado

## Tratamento de Erros
- Divisão por zero irá gerar uma `ArithmeticException`

## Construindo o Projeto
```bash
mvn clean install
```

## Executando a Aplicação
```bash
mvn exec:java
```

## Melhorias Futuras
- Adicionar suporte para números de ponto flutuante
- Implementar operações matemáticas mais complexas
- Criar uma interface gráfica do usuário (GUI)

## Licença
[Especifique sua licença aqui]

## Contribuidores
[Adicione nomes ou informações dos contribuidores]
