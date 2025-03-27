package br.ifes.calculadora.model.factories;

import br.ifes.calculadora.model.operacoes.IOperacao;

import java.lang.reflect.InvocationTargetException;

public class Factory {

    protected String basePackage = "br.ifes.calculadora.model.operacoes.";

    public IOperacao create(String nomeClasse) {

        Object result = null;

        try {
            String basePackage = this.basePackage + nomeClasse;

            result = Class.forName(basePackage).getDeclaredConstructor().newInstance();

        } catch (ClassNotFoundException | NoSuchMethodException | InstantiationException | IllegalAccessException |
                 InvocationTargetException e) {
            System.out.print("Erro na factory.\n");
        }

        return (IOperacao) result;

    }

}
