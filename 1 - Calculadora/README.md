# Calculadora Java

## 📝 Descrição do Projeto
Uma aplicação de calculadora simples desenvolvida em Java, oferecendo operações aritméticas básicas com uma interface de linha de comando interativa. O projeto demonstra o uso de padrões de design como o Método Factory e segue uma arquitetura modular e limpa.

## ✨ Funcionalidades
- Adição de números inteiros
- Subtração de números inteiros
- Multiplicação de números inteiros
- Divisão de números inteiros
- Interface de linha de comando intuitiva
- Tratamento de erros para divisão por zero

## 🏗️ Arquitetura do Projeto
A aplicação é estruturada em camadas para promover modularidade e manutenibilidade:
- **Camada de Visualização**: Gerencia a interação e entrada do usuário
- **Camada de Controle**: Coordena a comunicação entre visualização e modelo
- **Camada de Modelo**: Implementa a lógica central de cálculo
- **Padrão Factory**: Permite a criação dinâmica de objetos de operação

## 🛠️ Tecnologias Utilizadas
- Java 23
- Maven para gerenciamento de dependências e build
- Biblioteca Reflections para descoberta dinâmica de classes
- SLF4J para logging

## 📂 Estrutura de Diretórios
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

## 🚀 Como Usar
1. Clone o repositório
2. Tenha o Maven instalado em sua máquina
3. Execute a aplicação:
   ```bash
   mvn clean install
   mvn exec:java
   ```
4. Siga as instruções no menu:
   - Escolha uma operação (Somar, Subtrair, Multiplicar, Dividir)
   - Digite dois valores inteiros
   - Veja o resultado

## ⚠️ Tratamento de Erros
- Tentativa de divisão por zero resultará em uma `ArithmeticException`

## 🔜 Melhorias Futuras
- Suporte para números de ponto flutuante
- Implementação de operações matemáticas mais complexas
- Desenvolvimento de interface gráfica (GUI)
- Adição de testes unitários
- Melhor tratamento de exceções

## 🤝 Como Contribuir
1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## 📌 Requisitos
- JDK 23
- Maven 3.x
