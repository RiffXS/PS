using System;

using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
  public interface ITemperatureSensor
  {
    double ReadTemperature();
  }

  public class SensorA()
  {
    public double GetTemperatureInCelsius()
    {
      return 25.0;
    }
  }

  public class SensorB()
  {
    public double ObtenerTemperaturaEnCentigrados()
    {
      return 26.5;
    }
  }

  public class SensorC()
  {
    public double FetchTempC()
    {
      return 24.3;
    }
  }

  public class AdapterSensorA : ITemperatureSensor
  {
    public readonly SensorA _sensorA;

    public AdapterSensorA(SensorA sensorA)
    {
      _sensorA = sensorA;
    }

    public double ReadTemperature()
    {
      return _sensorA.GetTemperatureInCelsius();
    }
  }

  public class AdapterSensorB : ITemperatureSensor
  {
    public readonly SensorB _sensorB;

    public AdapterSensorB(SensorB sensorB)
    {
      _sensorB = sensorB;
    }

    public double ReadTemperature()
    {
      return _sensorB.ObtenerTemperaturaEnCentigrados();
    }
  }

  public class AdapterSensorC : ITemperatureSensor
  {
    public readonly SensorC _sensorC;

    public AdapterSensorC(SensorC sensorC)
    {
      _sensorC = sensorC;
    }

    public double ReadTemperature()
    {
      return _sensorC.FetchTempC();
    }
  }

  public class Program {
    public static void Main(string[] args)
    {
      var sensorA = new SensorA();
      var sensorB = new SensorB();
      var sensorC = new SensorC();

      ITemperatureSensor adapterA = new AdapterSensorA(sensorA);
      ITemperatureSensor adapterB = new AdapterSensorB(sensorB);
      ITemperatureSensor adapterC = new AdapterSensorC(sensorC);

      List<ITemperatureSensor> sensores = new List<ITemperatureSensor>
      {
        adapterA,
        adapterB,
        adapterC,
      };

      Console.WriteLine("Leitura de temperatura dos sensores:");
      char i = 'A';
      foreach (var sensor in sensores)
      {
        Console.WriteLine($"Sensor {i++}: {sensor.ReadTemperature()} ºC");
      }
    }
  }
}
