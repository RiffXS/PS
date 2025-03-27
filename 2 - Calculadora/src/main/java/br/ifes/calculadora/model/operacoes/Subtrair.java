package br.ifes.calculadora.model.operacoes;

public class Subtrair implements IOperacao {

    @Override
    public Integer calcular(Integer valor1, Integer valor2) {
        return valor1 - valor2;
    }

}
