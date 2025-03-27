package br.ifes.projetosistemas.calculadora.controller;

import br.ifes.projetosistemas.calculadora.dto.RequestDTO;
import br.ifes.projetosistemas.calculadora.dto.ResponseDTO;
import br.ifes.projetosistemas.calculadora.model.Calc;
import br.ifes.projetosistemas.calculadora.model.CalcX;
import br.ifes.projetosistemas.calculadora.model.ICalc;
import br.ifes.projetosistemas.calculadora.model.operation.*;

public class ControllerCalc {

    public ResponseDTO calc(RequestDTO requestDTO){
        int result = 0;
        ICalc calc = null;
        if (requestDTO.getOpcao() == 1){
            calc = new Calc();

        }else {
            calc = new CalcX();
        }


        IOperation operation = null;
        switch (requestDTO.getOpcao()) {
            case 1:
                operation = new Somar();
                break;
            case 2:
                operation = new Subtrair();
                break;
            case 3:
                operation = new Multiplicar();
                break;
            case 4:
                operation = new Dividir();
                break;
        }
        result = calc.calculation(operation,requestDTO.getValor1(),requestDTO.getValor2());
        return new ResponseDTO(result);

    }
}

