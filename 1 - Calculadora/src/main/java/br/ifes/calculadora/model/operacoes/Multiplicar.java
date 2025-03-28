package br.ifes.calculadora.model.operacoes;

public class Multiplicar implements IOperacao {

    @Override
    public Integer calcular(Integer valor1, Integer valor2) {
        return valor1 * valor2;
    }

}
