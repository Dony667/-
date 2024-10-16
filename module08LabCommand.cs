using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Module08Lab
{   
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Свет on");
        }

        public void Off()
        {
            Console.WriteLine("Свет off");
        }
    }


    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }


        public void Execute()
        {
            _light.On();
        }
           
        public void Undo()
        {
            _light.Off();
        }
    }
    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }
   

    public class RemoteControl
    {
        private ICommand _onCommand;
        private ICommand _offCommand;
        public void SetCommands(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void PressOnButton()
        {
            _onCommand.Execute();
        }

        public void PressOffButton()
        {
            _offCommand.Execute();
        }

        public void PressUndoButton()
        {
            _onCommand.Undo();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Light livingRoomLight = new Light();
            var lightOn = new LightOnCommand(livingRoomLight);
            var lightOff = new LightOffCommand(livingRoomLight);

            RemoteControl remote = new RemoteControl();
            remote.SetCommands(lightOn, lightOff);
            Console.WriteLine("Управление светом:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton();

        }
    }
}
