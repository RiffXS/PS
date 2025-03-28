package br.ifes.calculadora.view;

import br.ifes.calculadora.controller.Controller;
import br.ifes.calculadora.model.operacoes.IOperacao;
import org.reflections.Reflections;

import java.util.Scanner;
import java.util.Set;

public class Menu {

    public void imprimirOpcoes() {
        Reflections reflections = new Reflections("br.ifes.calculadora.model.operacoes");

        Set<Class<? extends IOperacao>> opClasses = reflections.getSubTypesOf(IOperacao.class);

        System.out.print("Menu:\n");
        for (Class<?> opClass : opClasses) {
            System.out.print("  " + opClass.getSimpleName() + "\n");
        }

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
