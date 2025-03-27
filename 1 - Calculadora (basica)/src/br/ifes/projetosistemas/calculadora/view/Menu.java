package br.ifes.projetosistemas.calculadora.view;

import br.ifes.projetosistemas.calculadora.dto.RequestDTO;
import br.ifes.projetosistemas.calculadora.dto.ResponseDTO;

import java.util.Scanner;

public class Menu {


    public RequestDTO show(){
        this.showMenu();
        return this.captureValues();
    }

    private RequestDTO captureValues (){

        Scanner input = new Scanner(System.in);
        int opcao = input.nextInt();
        System.out.println("Informe o primeiro valor:");
        int valor1 = input.nextInt();
        System.out.println("Informe o segundo valor:");
        int valor2 = input.nextInt();

        return new RequestDTO(opcao,valor1,valor2);
    }

    private void showMenu(){

        System.out.println("---->Olá Meu fi!<----");
        System.out.println("Escolha uma das opção:");
        System.out.println("1 - Somar");
        System.out.println("2 - Subtrair");
        System.out.println("3 - Multiplicar");
        System.out.println("4 - Dividir");
        System.out.println("5 - Vá embora ...");

    }

    public void showResult (ResponseDTO responseDTO){
        System.out.println("O Resultado é: "+responseDTO.getResult());
    }


}
