package br.ifes.calculadora.view;

import br.ifes.calculadora.controller.Controller;

import java.util.Scanner;

public class Menu {

    public void imprimirOpcoes() {
        System.out.print("Menu:\n");
        System.out.print("  Somar\n");
        System.out.print("  Subtrair\n");
        System.out.print("  Multiplicar\n");
        System.out.print("  Dividir\n\n");

        Scanner s = new Scanner(System.in);

        System.out.print("Digite a opção:\n");
        String opcao = s.nextLine();

        System.out.print("Digite o valor 1:\n");
        Integer valor1 = s.nextInt();

        System.out.print("Digite o valor 2:\n");
        Integer valor2 = s.nextInt();

        Controller controller = new Controller();
        Integer resultado = controller.calcular(opcao, valor1, valor2);

        System.out.print("Resultado:\n" + resultado);
    }

}
