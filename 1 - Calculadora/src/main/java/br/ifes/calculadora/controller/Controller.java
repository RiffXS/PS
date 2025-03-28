package br.ifes.calculadora.controller;

import br.ifes.calculadora.model.Calculadora;

public class Controller {

    public Integer calcular(String opcao, Integer valor1, Integer valor2) throws ArithmeticException {

        Calculadora calculadora = new Calculadora();

        return calculadora.calcular(opcao, valor1, valor2);

    }
}
