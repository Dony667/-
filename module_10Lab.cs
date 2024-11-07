using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    //FACADE
    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("");
        }
        public void SetVolume(int level)
        {
            Console.WriteLine($"");
        }
        public void TurnOff()
        {
            Console.WriteLine("");
        }
    }
    public class VideoProjector
    {
        public void TurnOn()
        {
            Console.WriteLine("");
        }
        public void SetResolution(string resolution)
        {
            Console.WriteLine("");
        }
        public void TurnOff()
        {
            Console.WriteLine("");
        }
    }
    public class LightingSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("");
        }
        public void SetBrightness(int level)
        {
            Console.WriteLine("");
        }
        public void TurnOff()
        {
            Console.WriteLine("");
        }
    }
    
    public class HomeTheaterFacade
    {
        private AudioSystem _audioSystem;
        private VideoProjector _videoProjector;
        private LightingSystem _lightingSystem;

        public HomeTheaterFacade(AudioSystem audioSystem, VideoProjector videoProjector,
            LightingSystem lightingSystem)
        {
            _audioSystem = audioSystem;
            _videoProjector = videoProjector;
            _lightingSystem = lightingSystem;
        }

        public void StartMovie()
        {
            _lightingSystem.TurnOn();
            _lightingSystem.SetBrightness(5);
            _audioSystem.TurnOn();
            _audioSystem.SetVolume(15);
            _videoProjector.TurnOn();
            _videoProjector.SetResolution("UHD 4K");
        }

        public void EndMovie()
        {
            _videoProjector.TurnOff();
            _audioSystem.TurnOff();
            _lightingSystem.TurnOff();
        }
    }

    public abstract class FileSystemComponent
    {
        protected string _name;

        public FileSystemComponent(string name)
        {
            _name = name;
        }
        public abstract void Display(int depth);
        public virtual void Add(FileSystemComponent component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(FileSystemComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual FileSystemComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + "File: " + _name);
        }
    }
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _children = new List<FileSystemComponent>();
        public Directory(string name) : base(name) { }
        public override void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }
        public override void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }
        public override FileSystemComponent GetChild(int index)
        {
            return _children[index];
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Directory: " + _name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            AudioSystem audio = new AudioSystem();
            VideoProjector video = new VideoProjector();
            LightingSystem light = new LightingSystem();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(audio, video, light);

            homeTheater.StartMovie();
            Console.WriteLine();
            homeTheater.EndMovie();
            Console.WriteLine();

            Directory root = new Directory("Root");
            File file1 = new File("First_file.txt");
            File file2 = new File("Second_file.txt");

            Directory subDir = new Directory("SubDirectory");
            File subFile1 = new File("SubFile1.txt");

            root.Add(file1);
            root.Add(file2);
            subDir.Add(subFile1);
            root.Add(subDir);

            root.Display(1);

        }
    }
}
