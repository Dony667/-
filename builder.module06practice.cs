using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string HDD/SSD { get; set;}
public string GPU { get; set; }
public string OS { get; set; }
private static ToString()
{
    Console.Writeline()
    }
}

public interface IComputerBuilder
{
    void SetCPU();
    void SetRAM();
    void SetHDD/SSD();
    void SetGPU();
    void SetOS();
}

public class OfficeComputerBuilder : IComputerBuilder
{
    private Computer computer;
    public void SetCPU()
    {
        computer.CPU = "простой процессор";
    }
}

public class ComputerDirector
{
    public void CreateComputer(IComputerBuilder computerBuilder)
    {
        computerBuilder.SetCPU("простой процессор")
    }
}