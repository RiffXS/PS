package br.ifes.calculadora.model;

import br.ifes.calculadora.model.factories.Factory;
import br.ifes.calculadora.model.operacoes.IOperacao;

public class Calculadora {

    public Integer calcular(String opcao, Integer valor1, Integer valor2) {

        String nomeClass = Character.toTitleCase(opcao.charAt(0)) +
                opcao.substring(1).toLowerCase();

        Factory factory = new Factory();
        IOperacao operacao = factory.create(nomeClass);

        return operacao.calcular(valor1, valor2);

    }

}
