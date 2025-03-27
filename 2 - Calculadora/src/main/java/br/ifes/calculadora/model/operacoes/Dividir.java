package br.ifes.calculadora.model.operacoes;

public class Dividir implements IOperacao {

    @Override
    public Integer calcular(Integer valor1, Integer valor2) {
        if (valor2 == 0) {
            throw new ArithmeticException("Divisão por zero!");
        }

        return valor1 / valor2;
    }

}
